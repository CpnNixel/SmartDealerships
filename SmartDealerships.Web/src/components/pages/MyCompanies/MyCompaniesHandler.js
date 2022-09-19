import React, { useState, useEffect } from 'react';
import { useHistory, useLocation } from 'react-router';
import { Alert } from 'react-bootstrap';
import { companiesService } from '../../../services';
import Table from 'react-bootstrap/Table';
import Orders from './Orders';
import { useTranslation } from 'react-i18next';

const MyCompaniesHandler = () => {
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [items, setItems] = useState([]);
  const history = useHistory();
  const location = useLocation();
  const { t } = useTranslation();

  useEffect(async () => {
    let cleanupFunction = false;
    await companiesService.getUserCompanies()
      .then(
        (result) => {
          if (!cleanupFunction) {
            setIsLoaded(true);
            setItems(result.data['company']);
          }
        },
        (error) => {
          if (!cleanupFunction) {
            setIsLoaded(true);
            setError(error);
          }
        }
      );
    return () => cleanupFunction = true;
  }, []);

  if (error) {
    return <div className="container">{t('error')}: {error.message}</div>;
  } else if (!isLoaded) {
    return <div className="container">{t('loading')}</div>;
  }
  const redirectToCreateCompany = () => {
    const { from } = location.state || { from: { pathname: '/createcompany' } };
    history.push(from);
  };

  const redirectToCreateProduct = () => {
    const { from } = location.state || { from: { pathname: '/createproduct' } };
    history.push(from);
  };


  if (items && items.products && items.orders) {
    const products = items.products;
    const orders = items.orders;
    console.log(products);
    console.log(orders);
  }


  return (
    (items == undefined || items.isSuccessful == false) ?
      (<Alert variant='info'>
        {t('userhasnocompanies')}
        <Alert.Link onClick={redirectToCreateCompany}> <p></p>{t('youcancreatecompany')}</Alert.Link>
      </Alert>)
      :
      (<div>
        <h2>{t('company')}:</h2>
        <p>{t('id')}: {items.id}</p>
        <p>{t('name')}: {items.name}</p>
        <p>{t('created')}: {items.dateCreated}</p>

        <h2>{t('products')}:</h2>
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>{t('product')}</th>
              <th>{t('product')} {t('name')}</th>
              <th>{t('categoryname')}</th>
              <th>{t('company')}</th>
              <th>{t('description')}</th>
              <th>{t('sku')}</th>
              <th>{t('price')}</th>
            </tr>
          </thead>
          {items.products?.map(x => {
            return (
              <tbody key={x.id} >
                <tr>
                  <td>{x.id}</td>
                  <td>{x.name}</td>
                  <td>{x.categoryName}</td>
                  <td>{x.companyName}</td>
                  <th>{x.description}</th>
                  <td>{x.sku}</td>
                  <td>$ {x.price}</td>
                </tr>
              </tbody>

            );
          })}
        </Table>
        <Alert variant='info'>
          <Alert.Link onClick={redirectToCreateProduct}> <p></p>{t('uploadnewproducts')}</Alert.Link>
        </Alert>

        <h2>{t('orders')}:</h2>
        <Orders orders={items?.orders} />
      </div>)
  );
};

export default MyCompaniesHandler;
