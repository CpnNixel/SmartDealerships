import React from 'react';
import { useHistory } from 'react-router';
import { accountService, alertService } from '../../../../services';
import Header from './Header';

const AuthorizedHeader = () => {

  const history = useHistory();

  const logoutHandle = async () => {

    try {
      await accountService.logout();
      history.push('account/login');
    } catch (error) {
      alertService.error(error);
    }
  };

  return (
    <Header logoutHandle={logoutHandle} />
  );
};

export default AuthorizedHeader;
