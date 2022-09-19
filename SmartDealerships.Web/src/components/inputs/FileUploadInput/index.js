import React from 'react';
import ErrorValidation from '../../shared/ErrorValidation';

const  FileUploadInput = ({setfileinputvalue, ...props}) => {
  const {name, label, field, touched, error} = props;
  const handleChange = (e) => {
    const file  =  e.currentTarget.files[0];
    setfileinputvalue(name, file);
  };

  return (
    <div className="form-group">
      <label htmlFor={name} className="col-sm-2 col-form-label">{label}</label>
      <input type={'file'} onChange={(o) => handleChange(o)}
        className="form-control" {...field} {...props} value={props.value}/>
      {touched && error ? (
        <ErrorValidation error={error} touched={touched}/>
      ) : null}
    </div>
  );
};

export default FileUploadInput;