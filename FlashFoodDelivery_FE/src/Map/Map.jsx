import React from 'react';
import './Mappage.css';

import biaImage from '../assets/images/fastfood.jpg' 

const Mappage = () => {
    return (
        <div className="homepage">
           
          <img src={biaImage} alt="Bia" className="hero-image" />
        </div>
    );
};

export default Mappage;