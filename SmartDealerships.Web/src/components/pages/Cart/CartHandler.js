import { t } from 'i18next';
import React, { useEffect, useState } from 'react';
import { cartService } from '../../../services';
import Cart from './index';

const CartHandler = () => {
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [item, setItem] = useState([]);
  useEffect(() => {
    cartService.getCartStatus()
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
    return <div>{t('error')}: {error.message}</div>;
  } else if (!isLoaded) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <Cart products={item} />
    </div>
  );
};

export default CartHandler;