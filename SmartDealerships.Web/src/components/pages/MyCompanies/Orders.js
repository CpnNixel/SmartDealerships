import React from 'react';
import Table from 'react-bootstrap/Table';
import { useTranslation } from 'react-i18next';
export default function Orders(props) {
  const { t } = useTranslation();

  return (
    <Table striped bordered hover>
      <thead>
        <tr>
          <th>{t('orderid')}</th>
          <th>{t('buyerid')}</th>
          <th>{t('ordertotal')}</th>
          <th>{t('created')}</th>
        </tr>
      </thead>
      {props.orders?.map(x => {
        return (
          <tbody key={x.id} >
            <tr>
              <td>{x.id}</td>
              <td>{x.userId}</td>
              <td>$ {x.total}</td>
              <td>{x.dateCreated}</td>
            </tr>
          </tbody>
        );
      })}
    </Table>
  );
}
