import { check } from 'k6';
import http from 'k6/http';


export const options = {
    vus: 10,
    duration: '1m',
    insecureSkipTLSVerify: true
}

export default function () {
   const url = 'http://localhost:5088/get-all-products';

    const params = {
        headers: {
            'Content-Length' : 0,
        }
    }

    const res = http.get(url, params);

    check(res, {
        'is status 400': (r) => r.status = 400,
    });
}