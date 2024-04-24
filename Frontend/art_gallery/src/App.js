import React from 'react';
import { useState } from 'react'
import { Routes, Route } from 'react-router-dom';
import './App.css';

// Import all the necessary components
import SearchBar from './searchbar';
import Home from './Home';
import Users from './User';
import Post from './Post';
import ArtGallery from './ArtGallery';
import Artist from './Artist';
import ArtTypes from './ArtTypes';
import Artifacts from './Artifacts';
import Exhibition from './Exhibitions';
import Update from './Update';
import Delete from './Delete';
import Login from './Login';

function App() {

  const [userLoggedIn, setLoginStatus] = useState(false);

  const userLogin = () => setLoginStatus(true);
  const userLogout = () => setLoginStatus(false);

  return (
    <div className="App">
      <SearchBar /> 
      <Routes>
        <Route path="/" element={<Home userloggedin = {userLoggedIn}/>} />
        <Route path="/login" element={<Login userLogin = {userLogin}/>} />
        <Route path="/user" element={<Users />} />
        <Route path="/post" element={<Post />} />
        <Route path="/artgallery" element={<ArtGallery />} />
        <Route path="/artist" element={<Artist />} />
        <Route path="/artifacts" element={<Artifacts />} />
        <Route path="/arttypes" element={<ArtTypes />} />
        <Route path="/exhibition" element={<Exhibition />} />
        <Route path="/update" element={<Update />} />
        <Route path="/delete" element={<Delete />} />
      </Routes>
    </div>
  );
}

export default App;
