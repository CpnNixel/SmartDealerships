import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom/cjs/react-router-dom';
import ProductDetails from '.';
import { productService } from '../../../services';
export default function ProductDetailsHandler() {
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [item, setItem] = useState([]);
  let { id } = useParams();

  useEffect(() => {
    productService.getProductById(id)
      .then(
        (result) => {
          setItem(result.data);
          setIsLoaded(true);
        },
        (error) => {
          setError(error);
          setIsLoaded(true);
        }
      );
  }, []);

  if (error) {
    return <div>Error: {error.message}</div>;
  } else if (!isLoaded) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <ProductDetails item={item} />
    </div>
  );

}
