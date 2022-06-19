import React from 'react';
import { useState, useEffect } from 'react';
import { getDefaultService } from '../../services/default.service';

export default function Hello() {
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [item, setItem] = useState([]);
  useEffect(() => {
    getDefaultService.getDefault()
      .then(
        (result) => {
          setItem(result.data);
          setIsLoaded(true);
        },
        (error) => {
          setError(error);
          setIsLoaded(true);
        }
      );
  }, []);
  if (error) {
    return <div>Error: {error.message}</div>;
  } else if (!isLoaded) {
    return <div>Loading...</div>;
  }
  return <div>{item}</div>
}
