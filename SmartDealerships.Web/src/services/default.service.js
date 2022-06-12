import {axiosWrapper} from '../api-client';

// const defaultService = 'api/courses';

export const getDefaultService = {
    getDefault
};


async function getDefault(){
    const response = await axiosWrapper
      .get( '/hello');
    return response;
  }