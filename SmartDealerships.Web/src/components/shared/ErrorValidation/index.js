import React from 'react';
import PropTypes from 'prop-types';
import { MdInfoOutline } from 'react-icons/md';
import './ErrorValidation.css';

const ErrorValidation = ({ error, touched }) =>
  touched && error ? (
    <div className="text-danger ml-4">
      <MdInfoOutline className="error-icon" />
      {error}
    </div>
  ) : null;

ErrorValidation.propTypes = {
  error: PropTypes.string,
  touched: PropTypes.bool
};

export default ErrorValidation;