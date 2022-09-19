import React from 'react';
import './UnauthorizedHeader.css';
import { Navbar, Nav } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';
import Logo from './logo.jpg';
import { useTranslation } from 'react-i18next';

const UnauthorizedHeader = () => {
  const { t, i18n } = useTranslation();

  const changeLanguage = (language) => {
    i18n.changeLanguage(language);
  };

  return (
    <div className="container header-container">
      <Navbar collapseOnSelect expand="sm"  >
        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
        <Navbar.Collapse id="responsive-navbar-nav">
          <NavLink to='/home'>
            <img
              src={Logo}
              id="logo"
              alt="SmartDealerships logo"
            />
          </NavLink>
          <Nav className="mr-auto">
            {/* <NavLink className="navButton" to="/products" >Products</NavLink> */}
          </Nav>
          <Nav>
            <NavLink to='/account/login' className="navButton" >{t('signin')}</NavLink>
          </Nav>
          <button className='navButton' onClick={() => changeLanguage('en')}>EN</button>
          <button className='navButton' onClick={() => changeLanguage('ua')}>UA</button>
        </Navbar.Collapse>
      </Navbar>
    </div>
  );
};

export default UnauthorizedHeader;
