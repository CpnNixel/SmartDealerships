import React, { useEffect, useState } from 'react';
import './UserProfile.css';
import Loader from './loader.svg';
import BadRequest from './error.svg';
import { accountService, alertService, companiesService } from '../../../services';
import Orders from '../MyCompanies/Orders';
import UserContacts from './UserContacts/';
import { useTranslation } from 'react-i18next';

const UserProfile = () => {
  const [userProfile, setUserProfile] = useState(null);
  const [orders, setOrders] = useState(null);
  const [isUserProfileLoading, setIsUserProfileLoading] = useState(true);
  const { t } = useTranslation();

  useEffect(() => {
    let cleanupFunction = false;

    const getUserData = async () => {
      try {
        let user = await accountService.getUserProfile();
        let orders = await companiesService.getOrders();
        if (!cleanupFunction) {
          setUserProfile(user);
          setOrders(orders.data.orders);
          setIsUserProfileLoading(false);
        }
      } catch (error) {
        console.log(error);
        if (!cleanupFunction) {
          setIsUserProfileLoading(false);
        }
        alertService.error(error);
      }
    };
    getUserData();
    return () => cleanupFunction = true;
  }, []);

  return (
    <div className="container fullscreen-component">
      {userProfile &&
        <div id="main">
          <h2 className="text-center">{t('myprofile')}</h2>
          <hr />
          <div className="row">
            <UserContacts userProfile={userProfile} />
            <Orders orders={orders} />
          </div>
        </div>
      }
      {isUserProfileLoading && <img className="preloader" src={Loader} alt='loading' />}
      {!isUserProfileLoading && !userProfile &&
        <>
          <img className="preloader" src={BadRequest} alt='loading' />
          <h3 className="text-center">{t('servererror')}</h3>
        </>}
    </div>
  );
};

export default UserProfile;