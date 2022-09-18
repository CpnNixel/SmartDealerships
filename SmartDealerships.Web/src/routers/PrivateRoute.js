import React from 'react';
import { Route, Redirect } from 'react-router-dom';

import { accountService } from '../services';
import AuthorizedLayout from '../components/layouts/AuthorizedLayout';

const PrivateRoute = ({ component: Component, ...rest }) => {
  return (
    <Route {...rest} render={props => {
      const token = accountService.tokenValue;
      if (!token) {
        // not logged in so redirect to login page with the return url
        return <Redirect to={{pathname: '/account/home', state: {from: props.location}}}/>;
      }

      // authorized so return component
      return <AuthorizedLayout component={Component}/>;
    }}/>
  );
};

export default PrivateRoute ;