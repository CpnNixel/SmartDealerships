import React from 'react';
import { Nav, Navbar } from 'react-bootstrap';
import { useTranslation } from 'react-i18next';
import { NavLink } from 'react-router-dom';
import './AuthorizedHeader.css';
import Logo from './logo.jpg';

const Header = (props) => {
  const { t, i18n } = useTranslation();

  const changeLanguage = (language) => {
    i18n.changeLanguage(language);
  };

  const { logoutHandle } = props;
  return (
    <div className="container header-container">
      <Navbar collapseOnSelect expand="sm"  >
        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
        <Navbar.Collapse id="responsive-navbar-nav">
          <NavLink to="/home">
            <img
              src={Logo}
              id="logo"
              alt="SmartDealerhips logo"
            />
          </NavLink>
          <Nav className="mr-auto">
            <NavLink className="navButton" to="/products">  {t('market')}</NavLink>
          </Nav>
          <Nav className="">
            <NavLink className="navButton" to="/mycompanies">  {t('mycompanies')}</NavLink>
          </Nav>
          <Nav>
            <NavLink className="navButton" to="/profile">  {t('cabinet')}</NavLink>
          </Nav>
          <Nav>
            <NavLink className="navButton" to="/cart">  {t('cart')}</NavLink>
          </Nav>
          <Nav>
            <button className="navButton" onClick={logoutHandle}>
              {t('logout')}
              {/* <Trans i18nKey="logout">logout</Trans> */}
            </button>
          </Nav>

          <button className='navButton' onClick={() => changeLanguage('en')}>EN</button>
          <button className='navButton' onClick={() => changeLanguage('ua')}>UA</button>
        </Navbar.Collapse>
      </Navbar>
    </div>
  );
};

export default Header;