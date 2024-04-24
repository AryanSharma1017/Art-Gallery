import React, { useState } from 'react';
import "./searchbar.css"
import { Link } from 'react-router-dom'; 
import "./searchbar.css"

const SearchBar = () => {
  return (
    <div className='SearchBar'>
      <Link to={"/"}><h2>Art-gallery</h2></Link>
      <div className='options'>
        <Link to="/user">User</Link>
        <Link to="/artgallery">Art Gallery</Link>
        <Link to="/artifacts">Artifacts</Link>
        <Link to="/artist">Artist</Link>
        <Link to="/arttypes">Art-Types</Link>
        <Link to="/Exhibition">Exhibition</Link>
      </div>
    </div>
  );
};

export default SearchBar;
