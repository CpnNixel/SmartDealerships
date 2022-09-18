import React from 'react';
import TextInput from '../../../inputs/TextInput';
import { Form, Formik } from 'formik';
import * as Yup from 'yup';
import { NavLink } from 'react-router-dom';
import { useTranslation } from 'react-i18next';

const initialState = {
  firstName: '',
  lastName: '',
  phone: '',
  email: '',
  password: '',
  passwordConfirmation: ''
};

const validationRules = Yup.object({
  firstName: Yup.string()
    .max(15, 'Must be 15 characters or less')
    .required('Required'),
  lastName: Yup.string()
    .max(20, 'Must be 20 characters or less')
    .required('Required'),
  phone: Yup.string()
    .matches(/\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/,
      'Invalid phone number')
    .required('Required'),
  email: Yup.string()
    .email('Invalid email address')
    .required('Required'),
  password: Yup.string()
    .matches(/^(?=.*[\d])(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%^&*])[\w!@#$%^&*]{6,18}$/,
      'Passwords must be \n' +
      ' - Between 6 and 18 characters long\n' +
      ' - Include at least 1 lowercase letter\n' +
      ' - 1 capital letter\n' +
      ' - 1 number\n' +
      ' - 1 special character => !@#$%^&*')
    .required('Required'),
  passwordConfirmation: Yup.string()
    .oneOf([Yup.ref('password'), null], 'Passwords must match')
    .required('Required!'),
});

const RegistrationForm = (props) => {
  const { t } = useTranslation();
  return (
    <Formik
      initialValues={initialState}
      validationSchema={validationRules}
      onSubmit={props.onSubmit}>
      {() => (
        <Form className="sign-form">
          <TextInput
            label={t('firstname')}
            name="First Name"
            type="text"
            placeholder={t('enterfn')}
          />
          <TextInput
            label={t('firstname')}
            name="lastName"
            type="text"
            placeholder={t('enterln')}
          />
          <TextInput
            label={t('phone')}
            name="phone"
            type="text"
            placeholder={t('enterphone')}
          />
          <TextInput
            label={t('email')}
            name="email"
            type="email"
            placeholder={t('enteryouremail')}
          />
          <TextInput
            label={t('password')}
            name="password"
            type="password"
            placeholder={t('enterpassword')}
          />
          <TextInput
            label={t('confirmpassword')}
            name="passwordConfirmation"
            type="password"
            placeholder={t('confirmpassword')}
          />
          <div className="form-buttons">
            <button className="btn btn-outline-danger" type="submit">{t('signup')}</button>
            <NavLink className='btn btn-outline-dark ml-4' to="/account/login">{t('signin')}</NavLink>
          </div>
        </Form>
      )}
    </Formik>
  );
};

export default RegistrationForm;