import React from 'react';
import { Link } from 'react-router-dom';
import "./searchbar.css"

const SearchBar = ({ isLoggedIn, logout }) => {
  return (
    <div className='SearchBar'>
      <Link to={"/"}><h2>Art-gallery</h2></Link>
      <div className='options'>
        <Link to="/artgallery">Art Gallery</Link>
        <Link to="/artifacts">Artifacts</Link>
        <Link to="/artist">Artist</Link>
        <Link to="/arttypes">Art-Types</Link>
        <Link to="/exhibition">Exhibition</Link>
        {isLoggedIn ? (
          <button onClick={logout} className="logout-button">Logout</button>
        ) : (
          <Link to="/login">Login</Link>
        )}
      </div>
    </div>
  );
};

export default SearchBar;
