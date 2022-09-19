import i18n from 'i18next';
// import Backend from 'i18next-http-backend';
// import LanguageDetector from 'i18next-browser-languagedetector';
import { initReactI18next } from 'react-i18next';
import translationsUa from '../../locales/ua/translation.json';
import translationsEn from '../../locales/en/translation.json';

i18n.use(initReactI18next).init({
  fallbackLng: 'en',
  debug: true,
  detection: {
    order: ['queryString', 'cookie'],
    cache: ['cookie']
  },
  interpolation: {
    escapeValue: false
  },
  resources: {
    en: { translation: translationsEn },
    ua: { translation: translationsUa }
  }
});

export default i18n;