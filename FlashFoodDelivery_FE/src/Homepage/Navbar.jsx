// src/Homepage/Navbar.js

import React from 'react';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faShoppingCart, faSearch } from '@fortawesome/free-solid-svg-icons';
import logo from '../assets/images/logo.jpg';
import './Navbar.css';

const Navbar = () => {
    return (
        <nav className="navbar">
            <div className="logo">
                <Link to="/">
                    <img src={logo} alt="Logo" className="logo-image" />
                </Link>
            </div>
            <ul className="nav-links">
                <li><Link to="/">Home</Link></li>
                <li><Link to="/category">Category</Link></li>
                <li><Link to="/about">About</Link></li>
                <li><Link to="/contact">Contact us</Link></li>
                <li><Link to="/service">Service</Link></li>

                
            </ul>
            <div className="nav-icons">
                <Link to="/search" className="nav-icon">
                    <FontAwesomeIcon icon={faSearch} />
                </Link>
                <Link to="/ShoppingCart" className="nav-icon">
                    <FontAwesomeIcon icon={faShoppingCart} />


                </Link>
                <Link to="/login" className="login-btn">Login</Link>
            </div>
        </nav>
    );
}

export default Navbar;
