import React from 'react';
import { Route, Switch, Redirect, useLocation } from 'react-router-dom';
import PrivateRoute from './routers/PrivateRoute';
import './App.css';
import UnauthorizedUserRouter from './routers/UnauthorizedUserRouter';
import HomeAuthorized from './components/pages/HomeAuthorized';
import UserProfile from './components/pages/UserProfile';
import MyCompanies from './components/pages/MyCompanies';
import CartHandler from './components/pages/Cart/CartHandler';
import ProductDetailsHandler from './components/pages/ProductDetails/ProductDetailsHandler';
import CreateCompanyHandler from './components/pages/CreateCompany/CreateCompanyHandler';
import CreateProduct from './components/pages/CreateProduct';
import ProductsHandler from './components/pages/HomeAuthorized/Handlers';
import './components/shared/i18n';

const App = () => {

  const { pathname } = useLocation();

  return (
    <div className="app">
      <Switch>
        <Redirect from="/:url*(/+)" to={pathname.slice(0, -1)} />
        <PrivateRoute exact path="/"
          component={HomeAuthorized} />
        <PrivateRoute exact path="/profile/:id?"
          component={UserProfile} />
        <PrivateRoute exact path="/mycompanies"
          component={MyCompanies} />
        <PrivateRoute exact path="/products"
          component={ProductsHandler} />
        <PrivateRoute exact path="/products/search/:searchName"
          component={ProductsHandler} />
        <PrivateRoute exact path="/products/:id"
          component={ProductDetailsHandler} />
        <PrivateRoute exact path="/cart"
          component={CartHandler} />
        <PrivateRoute exact path="/createcompany"
          component={CreateCompanyHandler} />
        <PrivateRoute exact path="/createproduct"
          component={CreateProduct} />
        <Route path="/account" component={UnauthorizedUserRouter} />
        <Redirect from="*" to="/" />
      </Switch>
    </div>
  );
};
export default App;