import React from 'react';
import { useState } from 'react'
import { Routes, Route } from 'react-router-dom';
import './App.css';

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

  const [isLoggedIn, setLoginStatus] = useState(false);

  const logout = () => {
    setLoginStatus(false);
    localStorage.removeItem('email');
    localStorage.removeItem('password');
  };

  return (
    <div className="App">
      <SearchBar isLoggedIn={isLoggedIn} logout={logout} />
      <Routes>
        <Route path="/" element={ <Home />} />
        <Route path="/login" element={<Login setLoginStatus={setLoginStatus}/>} />
        <Route path="/post" element={isLoggedIn ? <Post /> : <Login setLoginStatus={setLoginStatus} />} />
        <Route path="/artgallery" element={isLoggedIn ? <ArtGallery /> : <Login setLoginStatus={setLoginStatus} />} />
        <Route path="/artist" element={isLoggedIn ? <Artist /> : <Login setLoginStatus={setLoginStatus} />} />
        <Route path="/artifacts" element={isLoggedIn ? <Artifacts /> : <Login setLoginStatus={setLoginStatus} />} />
        <Route path="/arttypes" element={isLoggedIn ? <ArtTypes /> : <Login setLoginStatus={setLoginStatus} />} />
        <Route path="/exhibition" element={isLoggedIn ? <Exhibition /> : <Login setLoginStatus={setLoginStatus} />} />
        <Route path="/update" element={isLoggedIn ? <Update /> : <Login setLoginStatus={setLoginStatus} />} />
        <Route path="/delete" element={isLoggedIn ? <Delete /> : <Login setLoginStatus={setLoginStatus} />} />
      </Routes>
    </div>
  );
}

export default App;
