import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './Homepage/Navbar';
import Homepage from './Homepage/Homepage';
import Login from './Login/Login';
import ShoppingCart from './ShoppingCart/ShoppingCart';


import './App.css';

function App() {
    return (



        <Router>
            <div className="App">
                <Navbar />
                <Routes>
                    <Route path="/" element={<Homepage />} />
                    <Route path="/login" element={<Login />} /> 
                    <Route path="/ShoppingCart" element={<ShoppingCart />} />
                </Routes>
                
            </div>
       
        </Router>
    );
}

export default App;
