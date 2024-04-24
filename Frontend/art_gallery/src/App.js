import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
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
  return (
    <div className="App">
      <SearchBar/>
      <Routes>
        <Route path="/" element={<Home/>} />
        <Route path="/user" element={<Users/>} />
        <Route path="/post" element={<Post/>} />
        <Route path="/artgallery" element={<ArtGallery/>} />
        <Route path="/artist" element={<Artist/>} />
        <Route path="/artifacts" element={<Artifacts/>} />
        <Route path="/arttypes" element={<ArtTypes/>} />
        <Route path="/Exhibition" element={<Exhibition/>} />
        <Route path="/update" element={<Update/>} />
        <Route path="/delete" element={<Delete/>} />
      </Routes>
    </div>
  );
}

export default App;
