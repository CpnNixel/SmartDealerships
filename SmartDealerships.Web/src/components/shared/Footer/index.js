import React from 'react';
import './Footer.css';
import { Navbar, Nav } from 'react-bootstrap';
import Logo from './logo.jpg';
import { useTranslation } from 'react-i18next';

const Footer = () => {
  const { t } = useTranslation();
  return (
    <div className="container footer">
      <Navbar collapseOnSelect expand="sm"  >
        <Navbar.Collapse id="responsive-navbar-nav">
          <img
            src={Logo}
            id="logoCut"
            alt="Smart.Dealerships logo"
          />
          <span>
            © 2018–2022 Smart Dealerships
          </span>
          <Nav className="mr-auto" />
          <Nav>
            <Nav.Link className="navButton" href="#About-us">{t('aboutus')}</Nav.Link>
            <Nav.Link className="navButton" href="#Contact-us">{t('contactus')}</Nav.Link>
            <Nav.Link className="navButton" href="#Privacy">{t('privacy')}</Nav.Link>
          </Nav>

        </Navbar.Collapse>
      </Navbar>
    </div>
  );
};

export default Footer;
