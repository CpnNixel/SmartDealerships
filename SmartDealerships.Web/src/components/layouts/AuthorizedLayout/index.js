import React from 'react';
import Footer from './../../shared/Footer';
import AuthorizedHeader from './AuthorizedHeader/';
import './AuthorizedLayout.css';
import Alert from '../../shared/Alert';


const AuthorizedLayout = ({component:Component}) => {
  return (
    <div className="fullscreen-container">
      <AuthorizedHeader />
      <Alert />
      <Component />
      <Footer />
    </div>
  );
};


export default AuthorizedLayout;