import React from 'react';
import Footer from './../../shared/Footer';
import UnauthorizedHeader from './UnauthorizedHeader';
import './UnauthorizedLayout.css';
import Alert from '../../shared/Alert';


const UnauthorizedLayout = ({ component: Component }) => {
  return (
    <div className="fullscreen-container">
      <UnauthorizedHeader />
      <Alert />
      <Component />
      <Footer />
    </div>
  );
};

export default UnauthorizedLayout;
