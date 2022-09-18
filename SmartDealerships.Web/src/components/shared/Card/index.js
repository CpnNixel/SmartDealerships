import React from 'react';
import './Card.css';

const Card = (props) => {
  return (
    <div className="cardWrap">
      <div className="card">
        <img className="card-img-top" src={props.ImgPath} alt=""/>
        <div className="card-body">
          <h2>{props.CardTitle}</h2>
          <p className="card-text">
            {props.CardText}
          </p>
        </div>
      </div>
    </div>
  );
};
export default Card;
