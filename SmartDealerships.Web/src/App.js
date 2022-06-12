import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Hello from './components/Hello/Hello';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <Routes>
          <Route path="/hello" element={<Hello />} />
          <Route
            path="/" element={<div>Home</div>} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
