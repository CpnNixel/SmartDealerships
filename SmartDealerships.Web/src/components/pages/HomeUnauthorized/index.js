import React from 'react';
import './HomeUnauthorized.css';
import { Button } from 'react-bootstrap';
import HomePageContent from '../../shared/HomePageContent';
import { useTranslation } from 'react-i18next';

const HomeUnauthorized = () => {
  const { t } = useTranslation();

  return (
    <div className="content">
      <div className="home-container-unauthorized">
        <div className="overlay">
          <div className="container home-content">
            <h2>
              {t('title.title1')} <span>{t('title.title2')}</span>
            </h2>
            <p>
              {t('landing-text')}
            </p>
            <div className="buttons-container">
              <Button variant="outline-light" className="navButton">{t('getstarted')}</Button>{' '}
              <Button variant="outline-light" className="navButton" href="#1">{t('howdoistart')}</Button>{' '}
            </div>
          </div>
        </div>
      </div>
      <HomePageContent />
    </div>
  );
};


export default HomeUnauthorized;
