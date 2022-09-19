import React from 'react';
import  {Button, Accordion, Card} from 'react-bootstrap';

const AccordionSmall = (props) => {
  return (    
    <div>
      <Accordion>
        <Card>
          <Card.Header>
            <Accordion.Toggle as={Button} variant="link" eventKey="0">
              {props.level}
            </Accordion.Toggle>
          </Card.Header>
          <Accordion.Collapse eventKey="0">
            <Card.Body>{props.text}</Card.Body>
          </Accordion.Collapse>
        </Card>
      </Accordion>
    </div>);
};

export default AccordionSmall;