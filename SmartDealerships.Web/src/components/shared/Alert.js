import React, { useState, useEffect, useCallback } from 'react';
import PropTypes from 'prop-types';

import { alertService, AlertType } from '../../services';
import { history } from '../../api-client';

const propTypes = {
  id: PropTypes.string,
  fade: PropTypes.bool
};

const defaultProps = {
  id: 'default-alert',
  fade: true
};

const Alert = ({ id, fade }) => {
  const [alerts, setAlerts] = useState([]);

  const removeAlert = useCallback((alert) => {
    if (fade) {
      // fade out alert
      const alertWithFade = { ...alert, fade: true };
      setAlerts(alerts => alerts.map(x => x === alert ? alertWithFade : x));

      // remove alert after faded out
      setTimeout(() => {
        setAlerts(alerts => alerts.filter(x => x !== alertWithFade));
      }, 250);
    } else {
      // remove alert
      setAlerts(alerts => alerts.filter(x => x !== alert));
    }
  }, [fade]);

  useEffect(() => {
    let cleanupFunction = false;
    // subscribe to new alert notifications
    const subscription = alertService.onAlert(id)
      .subscribe(alert => {
        // clear alerts when an empty alert is received
        if (!alert.message) {
          setAlerts(alerts => {
            // filter out alerts without 'keepAfterRouteChange' flag
            const filteredAlerts = alerts.filter(x => x.keepAfterRouteChange);

            // remove 'keepAfterRouteChange' flag on the rest
            filteredAlerts.forEach(x => delete x.keepAfterRouteChange);
            return filteredAlerts;
          });
        } else {
          // add alert to array
          setAlerts(alerts => ([...alerts, alert]));
          // auto close alert if required
          if (alert.autoClose) {
            setTimeout(() => {
              if(!cleanupFunction) {
                removeAlert(alert);
              }
            }, 3000);
          }
        }
      });

    // clear alerts on location change
    const historyUnlisten = history.listen(({ pathname }) => {
      // don't clear if pathname has trailing slash because this will be auto redirected again
      if (pathname.endsWith('/')) {return;}

      alertService.clear(id);
    });

    // clean up function that runs when the component unmounts
    return () => {
      // unsubscribe & unlisten to avoid memory leaks
      subscription.unsubscribe();
      historyUnlisten();
      cleanupFunction = true;
    };
  }, [id, removeAlert]);

  function cssClasses(alert) {
    if (!alert) {return;}

    const classes = ['alert', 'alert-dismissable'];

    const alertTypeClass = {
      [AlertType.Success]: 'alert alert-success',
      [AlertType.Error]: 'alert alert-danger',
      [AlertType.Info]: 'alert alert-info',
      [AlertType.Warning]: 'alert alert-warning'
    };

    classes.push(alertTypeClass[alert.type]);

    if (alert.fade) {
      classes.push('fade');
    }

    return classes.join(' ');
  }

  if (!alerts.length) {return null;}
  return (
    <div className="container">
      <div className="m-3">
        {alerts.map((alert, index) =>
          <div key={index} className={cssClasses(alert)}>
            <button type="button" className="close" onClick={() => removeAlert(alert)}>&times;</button>
            <span dangerouslySetInnerHTML={{__html: alert.message}} className="m-0 p-0"/>
          </div>
        )}
      </div>
    </div>
  );
};

Alert.propTypes = propTypes;
Alert.defaultProps = defaultProps;
export default Alert;