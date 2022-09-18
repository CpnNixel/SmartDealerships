import React from 'react';
import { Card, Pagination } from 'react-bootstrap';
import './HomeAuthorized.css';
import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import logo from '../../shared/turbo.jpg';

const ProductsCardList = (props) => {
  const { t, i18n } = useTranslation();

  return (
    <div className='container'>
      <div className='cards-container'>
        {props.products?.map((item) => (
          <Card style={{
            width: '18rem', margin: '5px 5px 5px 5px', padding: '5px 5px 5px 5px',
            textAlign: 'center'
          }} key={item.id}>
            <Card.Img variant="top" src={logo} />
            <Card.Body>
              <Card.Title>{item.name}</Card.Title>
              <Card.Text>{item.categoryName}</Card.Text>
              <Card.Text>${item.price}</Card.Text>
              <Link to={`/products/${item.id}`} className="btn navButton single-line">{t("gotodetails")}</Link>
            </Card.Body>
          </Card>
        ))}
      </div>

      <p></p>
      <div style={{ alignSelf: 'center' }}>
        <Pagination>
          <Pagination.First />
          <Pagination.Prev />
          <Pagination.Item>{1}</Pagination.Item>
          <Pagination.Ellipsis />

          <Pagination.Item>{10}</Pagination.Item>
          <Pagination.Item>{11}</Pagination.Item>
          <Pagination.Item active>{12}</Pagination.Item>
          <Pagination.Item>{13}</Pagination.Item>
          <Pagination.Item disabled>{14}</Pagination.Item>

          <Pagination.Ellipsis />
          <Pagination.Item>{20}</Pagination.Item>
          <Pagination.Next />
          <Pagination.Last />
        </Pagination>
      </div>
    </div >
  );
};
export default ProductsCardList;