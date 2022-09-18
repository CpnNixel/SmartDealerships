import { axiosWrapper } from '../api-client';

const companiesControllerUrl = 'api/companies';

export const companiesService = {
  getUserCompanies,
  createCompany,
  getOrders
};

async function getUserCompanies() {
  const response = await axiosWrapper
    .get(`${companiesControllerUrl}`);
  return response;
}

async function createCompany(name, descr, logo) {
  const response = await axiosWrapper
    .post(`${companiesControllerUrl}/create`, {
      'name': name,
      'description': descr,
      'logo': logo
    });
  return response;
}

async function getOrders() {
  const response = await axiosWrapper
    .get(`${companiesControllerUrl}/orders`,);
  return response;
}