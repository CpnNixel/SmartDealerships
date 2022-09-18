import {useField} from 'formik';
import ErrorValidation from '../../shared/ErrorValidation';
import React from 'react';


const TextInput = ({ label, ...props }) => {
  const [field, meta] = useField(props);
  return (
    <div className="form-group">
      <label htmlFor={props.id || props.name} className="col-sm-2 col-form-label">{label}</label>
      <input className="form-control" {...field} {...props} value={props.value} />
      {meta.touched && meta.error ? (
        <ErrorValidation error={meta.error} touched={meta.touched}/>
      ) : null}
    </div>
  );
};

export default TextInput;