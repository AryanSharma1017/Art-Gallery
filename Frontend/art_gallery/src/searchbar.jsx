import React, { useState } from 'react';
import "./searchbar.css"
import { Link } from 'react-router-dom'; 
import "./searchbar.css"
import Home from './Home';
import ArtGallery from './Art-Gallery';

const SearchBar = () => {

  return (
    <div className='SearchBar'>
      <h2>Art-gallery</h2>
      <div className='options'>
        <Link to="/artgallery">Art Gallery</Link>
        {/* Add more links as needed */}
      </div>
    </div>
  );
};

export default SearchBar;
