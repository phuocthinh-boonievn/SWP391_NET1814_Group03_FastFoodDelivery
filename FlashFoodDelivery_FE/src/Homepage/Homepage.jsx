import React from 'react';
import './Homepage.css';

import biaImage from '../assets/images/fastfood.jpg' 

const Homepage = () => {
    return (
        <div className="homepage">
           
          <img src={biaImage} alt="Bia" className="hero-image" />
        </div>
    );
};

export default Homepage;