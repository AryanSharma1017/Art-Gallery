import React from 'react';
import { useState } from 'react'
import { Routes, Route } from 'react-router-dom';
import { Navigate } from 'react-router-dom';
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
        <Route path="/user" element={userLoggedIn ? <Users/> : <Navigate to="/login" />} />
        <Route path="/post" element={userLoggedIn ? <Post /> : <Navigate to="/login" />} />
        <Route path="/artgallery" element={userLoggedIn ? <ArtGallery /> : <Navigate to="/login" />} />
        <Route path="/artist" element={userLoggedIn ? <Artist /> : <Navigate to="/login" />} />
        <Route path="/artifacts" element={userLoggedIn ? <Artifacts /> : <Navigate to="/login" />} />
        <Route path="/arttypes" element={userLoggedIn ? <ArtTypes /> : <Navigate to="/login" />} />
        <Route path="/exhibition" element={userLoggedIn ? <Exhibition /> : <Navigate to="/login" />} />
        <Route path="/update" element={userLoggedIn ? <Update /> : <Navigate to="/login" />} />
        <Route path="/delete" element={userLoggedIn ? <Delete /> : <Navigate to="/login" />} />
      </Routes>
    </div>
  );
}

export default App;
