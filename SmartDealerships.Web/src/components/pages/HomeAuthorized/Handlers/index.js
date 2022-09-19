import React, { useEffect, useState } from 'react';
import { productService } from '../../../../services';
import ProductsCardList from '../ProductsCardList';
import icon from './search-icon-png-2.png';
import './ProductsHandler.css';
import { useTranslation } from 'react-i18next';

const ProductsHandler = () => {
  const { t } = useTranslation();
  const [items, setItems] = useState({});
  const [value, setValue] = useState('');

  const getItems = () => {
    productService.getAllProducts()
      .then((response) => {
        setItems(response.data);
      });

  };
  useEffect(() => {
    getItems();
  }, []);

  const filteredProducts = items.products?.filter(item => {
    return item.name.toLowerCase().includes(value.toLowerCase());
  });

  return (
    <div className="container">
      <h3>
        {t('ourproducts')}
      </h3>
      <br></br>
      <div style={{ alignSelf: 'center' }}>
        <form >
          <input type="text"
            placeholder={t('searchproduct')}
            className='search_input'
            onChange={(event) => setValue(event.target.value)}
          />
          <img src={icon} alt="img" style={{ maxHeight: '1.5em' }} />
        </form>
      </div>
      <ProductsCardList products={filteredProducts} />
    </div >
  );
};

export default ProductsHandler;