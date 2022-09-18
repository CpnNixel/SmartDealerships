import { axiosWrapper } from '../api-client';

const productControllerUrl = 'api/products';

export const productService = {
  getAllProducts,
  getProductById,
  getProductsByName
};

async function getAllProducts() {
  const response = await axiosWrapper
    .get(`${productControllerUrl}/all`);
  return response;
}

async function getProductById(itemId) {
  const response = await axiosWrapper
    .get(`${productControllerUrl}/${itemId}`);
  return response;
}

async function getProductsByName(searchName) {
  const response = await axiosWrapper
    .get(`${productControllerUrl}/search/${searchName}`);
  return response;
}
