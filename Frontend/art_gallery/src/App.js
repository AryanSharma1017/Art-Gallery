import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'; // Import BrowserRouter
import SearchBar from './searchbar';
import Home from './Home';
import ArtGallery from './Art-Gallery';

function App() {
  return (
    <div className="App">
      <SearchBar/>
      <Routes>
        <Route path="/" element={<Home/>} />
        <Route path="/artgallery" element={<ArtGallery/>} />
      </Routes>
    </div>
  );
}

export default App;
