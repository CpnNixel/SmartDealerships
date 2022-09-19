import axios from 'axios';

const apiClient = axios.create({
  baseURL: process.env.REACT_APP_API_URL,
  headers: {'Content-Type': 'application/json'}
});

apiClient.interceptors.request.use((config) => {
  const token = localStorage.authorizationToken;
  config.headers.Authorization =  token ? `Bearer ${token}` : '';
  return config;
});

export const axiosWrapper = {
  get,
  post,
  put,
  delete: _delete
};

function get(url) {
  return apiClient.get(url);
}

function post(url, data) {
  return apiClient.post(url, data);
}

function put(url, data) {
  return apiClient.put(url, data);
}

// prefixed with underscored because delete is a reserved word in javascript
function _delete(url) {
  return apiClient.delete(url);
}
