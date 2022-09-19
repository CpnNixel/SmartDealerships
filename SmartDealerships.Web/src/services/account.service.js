import { BehaviorSubject } from 'rxjs';
import { axiosWrapper } from '../api-client';


const tokenSubject = new BehaviorSubject(localStorage.authorizationToken);
const accountControllerUrl = 'api/account';

export const accountService = {
  login,
  logout,
  register,
  getUserProfile,
  token: tokenSubject.asObservable(),
  get tokenValue() {
    return tokenSubject.value;
  }
};

async function login(params) {

  const response = await axiosWrapper.post(`${accountControllerUrl}/login`, params);

  if (response.data.isSuccessful) {
    localStorage.setItem('authorizationToken', response.data.token);

    // publish token to subscribers
    tokenSubject.next(response.data.token);
  }

  return response;
}

async function logout() {

  const response = await axiosWrapper
    .post(`${accountControllerUrl}/logout`, { token: localStorage.authorizationToken });

  localStorage.removeItem('authorizationToken');
  localStorage.removeItem('userName');
  tokenSubject.next(null);

  return response;
}

async function register(params) {

  const response = await axiosWrapper.post(`${accountControllerUrl}/register`, params);

  localStorage.setItem('authorizationToken', response.data.token);

  // publish token to subscribers
  tokenSubject.next(response.data.token);

  return response;
}

async function getUserProfile() {
  const response = await axiosWrapper
    .post(`${accountControllerUrl}/get`, { token: localStorage.authorizationToken });
  return response.data;
}