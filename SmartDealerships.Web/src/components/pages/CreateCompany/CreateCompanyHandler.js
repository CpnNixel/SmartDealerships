import React from 'react';
import { useHistory, useLocation } from 'react-router-dom/cjs/react-router-dom';
import CreateCompany from '.';
import { alertService, companiesService } from '../../../services';


export default function CreateCompanyHandler() {
  const history = useHistory();
  const location = useLocation();

  const handleSubmit = async (values, { setStatus, setSubmitting }) => {
    const newCompany = {
      name: values.name,
      desccription: values.desccription,
      logo: values.logo
    };

    setStatus();
    try {
      const response = await companiesService.createCompany(newCompany.name, newCompany.desccription, newCompany.logo);
      if (response.data.isSuccessful) {
        localStorage.setItem('authorizationToken', response.data.token);
        const { from } = location.state || { from: { pathname: '/' } };
        history.push(from);
      }
    } catch (error) {
      setSubmitting(false);
      alertService.error(error);
    }
  };

  return (
    <div>
      <h2 className='content' style={{ textAlign: 'center' }}>Create company</h2>
      <CreateCompany onSubmit={handleSubmit} />
    </div >
  );
}
