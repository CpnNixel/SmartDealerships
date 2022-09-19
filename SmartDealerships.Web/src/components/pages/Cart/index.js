import React, { useEffect, useState } from 'react';
import { Button, Table } from 'react-bootstrap';
import './Cart.css';
import { cartService } from '../../../services';
import { useHistory, useLocation } from 'react-router';
import { useTranslation } from 'react-i18next';

export default function Cart(props) {
  const { t, i18n } = useTranslation();


  const cart = props.products;

  return (<div className="container">
    {cart.Total === 0 || !cart.items
      ? (<h2 style={{ textAlign: 'center' }}>{t('emptycart')}</h2>)
      : (<div>
        <Table striped>
          <thead>
            <tr>
              <th>#</th>
              <th>Product Name</th>
              <th>Product Quantity</th>
              <th>Product Price</th>
            </tr>
          </thead>
          {cart.items.map((item) => (
            <tbody key={item.id}>
              <tr>
                <td>{item.id}</td>
                <td>{item.name}</td>
                <td>{item.quantity}</td>
                <td>{item.price}</td>
              </tr>
            </tbody>

          ))
          }

        </Table>
        <div className="longdiv"></div>
        <div className='total'>

          <h2 >{t('total')}: {cart.total}</h2>
          <p></p>
          <EmptyCartButton />
          <p></p>
          <CheckoutCartButton />
        </div>
      </div>)
    }
  </div >
  );
}

const CheckoutCartButton = () => {
  const history = useHistory();
  const location = useLocation();
  const [isLoading, setLoading] = useState(false);
  const { t } = useTranslation();

  useEffect(() => {
    if (isLoading) {
      cartService.checkoutCart().then(() => {
        setLoading(false);
        const { from } = location.state || { from: { pathname: '/cart' } };
        history.go(from);
      });
    }
  }, [isLoading]);

  const handleClick = () => {
    setLoading(true);
  };

  return (
    <Button
      className="navButton"
      disabled={isLoading}
      onClick={!isLoading ? handleClick : null}>
      {isLoading ? t('loading') : t('checkout')}
    </Button>
  );
};


const EmptyCartButton = () => {
  const history = useHistory();
  const location = useLocation();
  const [isLoading, setLoading] = useState(false);
  const { t } = useTranslation();
  useEffect(() => {
    if (isLoading) {
      cartService.emptyCart().then(() => {
        setLoading(false);
        const { from } = location.state || { from: { pathname: '/cart' } };
        history.go(from);
      });
    }
  }, [isLoading]);

  const handleClick = () => {
    setLoading(true);
  };

  return (
    <Button
      className="navButton"
      variant="outline-warning"
      disabled={isLoading}
      onClick={!isLoading ? handleClick : null}
    >
      {isLoading ? t('loading') : t('toemptycart')}
    </Button>
  );
};
