import React from 'react';
import { Form, Formik } from 'formik';
import * as Yup from 'yup';
import TextInput from '../../../inputs/TextInput';
import { NavLink } from 'react-router-dom';
import { useTranslation } from 'react-i18next';

const LoginForm = (props) => {
  const { t } = useTranslation();
  const initialState = {
    email: '',
    password: ''
  };

  const validationRules = Yup.object({
    email: Yup.string()
      .email('Invalid email address')
      .required('Required'),
    password: Yup.string()
      .required('Required')
  });
  return (
    <Formik
      initialValues={initialState}
      validationSchema={validationRules}
      onSubmit={props.onSubmit}>
      <Form className="sign-form">
        <TextInput
          label={t('email')}
          name="email"
          type="email"
          placeholder={t('enteremail')}
        />
        <TextInput
          label={t('password')}
          name="password"
          type="password"
          placeholder={t('enterpassword')}
        />
        <div className="form-buttons">
          <button className="btn btn-outline-danger" type="submit">{t('signin')}</button>
          <NavLink className='btn btn-outline-dark ml-4' to="/account/registration">{t('signup')}</NavLink>
        </div>
      </Form>
    </Formik>
  );
};

export default LoginForm;