import React from 'react';
import './HomeAuthorized.css';
import HomePageContent from '../../shared/HomePageContent';
import { useTranslation } from 'react-i18next';

const HomeAuthorized = () => {
  const { t } = useTranslation();
  return (
    <div className="content">
      <div className="home-container">
        <div className="overlay">
          <div className="container home-content">
            <h2>
              {t('welcome')}, <span>{localStorage.userName}</span>
            </h2>
            <p>
              {t('landing-text')}
            </p>
          </div>
        </div>
      </div>
      <HomePageContent />
    </div>
  );
};


export default HomeAuthorized;
