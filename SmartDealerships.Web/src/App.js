import React from 'react';
import {BrowserRouter, Route, Routes} from 'react-router-dom';
// import {getDefaultService} from './services/default.service'
import Hello from './components/Hello';

//   const Hello = () => {
//   const [error, setError] = useState(null);
//   const [isLoaded, setIsLoaded] = useState(false);
//   const [item, setItem] = useState([]);
//   useEffect( () => {
//     getDefaultService.getDefault()
//       .then(
//         (result) => {
//           setItem(result.data);
//           setIsLoaded(true);
//         },
//         (error) => {
//           setError(error);
//           setIsLoaded(true);
//         }
//       );
//   }, []);
//   if (error) {
//     return <div>Error: {error.message}</div>;
//   } else if (!isLoaded) {
//     return <div>Loading...</div>;
//   }
//    return <div>{item}</div>
// }


function App() {
  return (
<BrowserRouter>
  {/* <div className="App"> */}

  <Routes>
    <Route path="/hello" element = {<Hello/>}/>
    <Route path="/" element = {<div>Home</div>}/>
  </Routes>


  {/* </div> */}
</BrowserRouter>
  );
}

export default App;
