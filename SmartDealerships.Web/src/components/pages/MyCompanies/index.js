import React from 'react';
import { useTranslation } from 'react-i18next';
import MyCompaniesHandler from './MyCompaniesHandler';


const MyCompanies = () => {
  const { t } = useTranslation();

  return (
    <div className="container content">
      <h3>
        {t('yourcompanies')}
      </h3>
      <div className="longdiv"></div>
      <MyCompaniesHandler />
    </div>
  );
};

export default MyCompanies;
