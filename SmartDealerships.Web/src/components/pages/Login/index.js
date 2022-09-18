import React from 'react';
import LoginForm from './LoginForm';
import { accountService, alertService } from '../../../services';
import { useHistory, useLocation } from 'react-router';
import './Login.css';
import { useTranslation } from 'react-i18next';

const Login = () => {
  const { t } = useTranslation();
  const history = useHistory();
  const location = useLocation();

  const handleSubmit = async (values, { setSubmitting, setStatus }) => {
    let newLoginUser = {
      email: values.email,
      password: values.password
    };

    setStatus();

    try {
      const response = await accountService.login(newLoginUser);
      if (response.data.isSuccessful) {
        localStorage.userName = response.data.user.firstName;
        const { from } = location.state || { from: { pathname: '/' } };
        history.push(from);
      } else {
        setSubmitting(false);
        alertService.error('Invalid login or password');
      }
    } catch (error) {
      setSubmitting(false);
      alertService.error(error);
    }
  };

  return (
    <div className="container sign-container">
      <h3 className="text-center">{t('signin')}</h3>
      <LoginForm onSubmit={handleSubmit} />
    </div>
  );
};

export default Login;