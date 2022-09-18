import { axiosWrapper } from '../api-client';

const cartControllerUrl = 'api/cart';

export const cartService = {
  getCartStatus,
  emptyCart,
  checkoutCart,
  addToCart
};

async function getCartStatus() {
  const response = await axiosWrapper
    .get(`${cartControllerUrl}/status`);
  return response;
}

async function emptyCart() {
  const response = await axiosWrapper
    .put(`${cartControllerUrl}/empty`);
  return response;
}

async function checkoutCart() {
  const response = await axiosWrapper
    .post(`${cartControllerUrl}/checkout`);
  return response;
}

async function addToCart(itemId, qty) {
  const response = await axiosWrapper
    .post(`${cartControllerUrl}/add/`, {
      'productId': itemId,
      'productQty': qty
    }
    );
  return response;
} 