import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import './ProductDetails.css';
import { Button } from 'react-bootstrap';
import { cartService } from '../../../services';
import { useHistory, useLocation } from 'react-router-dom/cjs/react-router-dom';
import { useTranslation } from 'react-i18next';
import { t } from 'i18next';


const ProductDetails = (props) => {
  let { id } = useParams();
  const [qty, setQty] = useState(0);
  function handleChange(event) {
    setQty(event.target.value);
  }

  let product = props.item;
  return (
    <div className="container">
      <h2>{product.name}</h2>
      <img src="https://www.motomobil.com/shop_images/7546030.jpg" alt='' />
      <p>{t('sku')} {product.name}</p>
      <p>{t('category')}: {product.categoryName}</p>
      <p>{t('description')}: {product.description}</p>
      <p>{t('price')}: ${product.price}</p>
      <input name="firstName" onChange={handleChange} /> <br></br>
      <AddToCartButton itemId={id} qty={qty} />
    </div>
  );
};

function AddToCartButton(props) {
  const [isLoading, setLoading] = useState(false);
  const history = useHistory();
  const location = useLocation();
  const { t } = useTranslation();

  useEffect(() => {
    if (isLoading) {
      const response = cartService.addToCart(props.itemId, props.qty).then(() => {
        setLoading(false);
      });
      if (response) {
        const { from } = location.state || { from: { pathname: '/cart' } };
        history.push(from);
      }

    }
  }, [isLoading]);

  const handleClick = () => {
    setLoading(true);
  };

  return (
    <Button
      variant="outline-primary" size="lg"
      disabled={isLoading}
      onClick={!isLoading ? handleClick : null}
    >
      {isLoading ? t('loading') : t('addtocart')}
    </Button>
  );
}

export default ProductDetails;