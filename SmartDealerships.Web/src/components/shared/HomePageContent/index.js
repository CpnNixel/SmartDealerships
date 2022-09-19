import Card from '../Card';
import React from 'react';
import { useTranslation } from 'react-i18next';

const HomePageContent = () => {
  const { t } = useTranslation();
  return (
    <div id="1" className="container cards-container">
      <Card
        ImgPath="https://www.flaticon.com/svg/static/icons/svg/825/825250.svg"
        CardTitle={t('cardtitle')}
        CardText={t('cartdetails')}
      />
      <Card
        ImgPath="https://www.flaticon.com/svg/static/icons/svg/825/825250.svg"
        CardTitle={t('cardtitle')}
        CardText={t('cartdetails')}
      />
      <Card
        ImgPath="https://www.flaticon.com/svg/static/icons/svg/825/825250.svg"
        CardTitle={t('cardtitle')}
        CardText={t('cartdetails')}
      />
      <Card
        ImgPath="https://www.flaticon.com/svg/static/icons/svg/825/825250.svg"
        CardTitle={t('cardtitle')}
        CardText={t('cartdetails')}
      />
      <Card
        ImgPath="https://www.flaticon.com/svg/static/icons/svg/825/825250.svg"
        CardTitle={t('cardtitle')}
        CardText={t('cartdetails')}
      />
      <Card
        ImgPath="https://www.flaticon.com/svg/static/icons/svg/825/825250.svg"
        CardTitle={t('cardtitle')}
        CardText={t('cartdetails')}
      />
    </div>
  );
};

export default HomePageContent;