import React from 'react';
import RegistrationForm from './RegistrationForm';
import { accountService, alertService } from '../../../services';
import { useHistory, useLocation } from 'react-router';
import './Registration.css';
import { useTranslation } from 'react-i18next';

const Registration = function () {
  const { t } = useTranslation();
  const history = useHistory();
  const location = useLocation();

  const handleSubmit = async (values, { setStatus, setSubmitting }) => {

    let newUser = {
      firstName: values.firstName,
      lastName: values.lastName,
      phoneNumber: values.phone,
      email: values.email,
      password: values.password
    };

    setStatus();
    try {
      const response = await accountService.register(newUser);
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
    <div className="container sign-container">
      <h3 className="text-center">{t('signup')}</h3>
      <RegistrationForm onSubmit={handleSubmit} />
    </div>
  );
};

export default Registration;