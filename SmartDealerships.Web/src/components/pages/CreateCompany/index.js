import React from 'react';
import { Form, Formik } from 'formik';
import TextInput from '../../inputs/TextInput';
import { useTranslation } from 'react-i18next';

const initialState = {
  name: '',
  desccription: '',
  logo: '',
};

export default function CreateCompany(props) {
  const { t } = useTranslation();
  return (
    <Formik
      initialValues={initialState}
      // validationSchema={validationRules}
      onSubmit={props.onSubmit}>
      {() => (
        <Form className="sign-form">
          <TextInput
            label="Company Name"
            name="companyname"
            type="text"
            placeholder="Enter your company name"
          />
          <TextInput
            label={t('description')}
            name="companydescr"
            type="text"
            placeholder="Tell us about your company"
          />
          <TextInput
            label="Logo"
            name="logo"
            type="text"
            placeholder="Upload logo of your company"
          />
          <div className="form-buttons">
            <div className="form-buttons">
              <button className="btn btn-outline-danger" type="submit">{t('createcompany')}</button>
            </div>
          </div>
        </Form>
      )}
    </Formik>
  );
}
