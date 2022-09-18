import React from 'react';
import { useTranslation } from 'react-i18next';
import UserPhoto from '../user-placeholder.png';

const UserContacts = (props) => {
  const { t } = useTranslation();
  const userProfile = props.userProfile;
  return (
    <div className="col-lg-4 col-md-4 col-xs-12">
      <div className="panel-body">
        <div className="text-center" id="author">
          <div className="profile-photo">
            <img src={UserPhoto} alt="User's face" />
          </div>
          <h5>{userProfile && userProfile.firstName} {userProfile && userProfile.lastName}</h5>
          <p><b>{t('email')}:</b> <i>{userProfile && userProfile.email}</i></p>
          <p><b>{t('phone')}:</b> <i>{userProfile && userProfile.phoneNumber}</i></p>
        </div>
      </div>
    </div>
  );
};

export default UserContacts;