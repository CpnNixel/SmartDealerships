import React, { useEffect } from 'react';
import { Route, Switch } from 'react-router-dom';
import { accountService } from '../services';
import Login from '../components/pages/Login';
import Registration from '../components/pages/Registration';
import UnauthorizedLayout from '../components/layouts/UnauthorizedLayout';
import HomeUnauthorized from '../components/pages/HomeUnauthorized';
import ProductsHandler from '../components/pages/HomeAuthorized/Handlers';

const UnauthorizedUserRouter = ({ history, match }) => {
  const { path } = match;

  useEffect(() => {
    // redirect to home if already logged in
    if (accountService.tokenValue) {
      history.push('/');
    }
  }, [history]);

  return (
    <div className="row">
      <div className="col">
        <Switch>
          <Route path={`${path}/registration`}>
            <UnauthorizedLayout component={Registration} />
          </Route>
          <Route path={`${path}/login`}>
            <UnauthorizedLayout component={Login} />
          </Route>
          <Route path={`${path}/home`}>
            <UnauthorizedLayout component={HomeUnauthorized} />
          </Route>
          <Route path={`${path}/products`}>
            <UnauthorizedLayout component={ProductsHandler} />
          </Route>
          <Route path={`${path}/products/search/:name`}>
            <UnauthorizedLayout component={ProductsHandler} />
          </Route>
        </Switch>
      </div>
    </div>
  );
};

export default UnauthorizedUserRouter;