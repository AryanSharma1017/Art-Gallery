import React, { useState, useEffect } from 'react';
import "./searchbar.css"
import axios from 'axios';

const ArtGallery = () => {
  const [Artgalleries, setArtgallery] = useState([]);

  useEffect(() => {
    fetchArtGallery();
  }, []);


  const fetchArtGallery = async () => {
    try
    {
      const response = await axios.get('http://localhost:5033/api/ArtGallery', {
        auth: {
          username: localStorage.getItem('email'),
          password: localStorage.getItem('password'),
        },
      });
      console.log(response)
      setArtgallery(response.data);
    }
    catch (error)
    {
      console.error('Error fetching ArtGallery:', error);
    }
    console.log(localStorage.getItem('email'));
    console.log(localStorage.getItem('password'));
  };


  return (
    <div className='ArtGallery'>
      <h2>Art Gallery List</h2>
      <div className='user-list'>
        {Artgalleries.map(ArtG => (
          <div key={ArtG.id} className='user-card'>
            {Object.keys(ArtG).map(key => (
              <p key={key}>{key}: {ArtG[key]}</p>
            ))}
          </div>
        ))}
      </div>
    </div>
  );
};

export default ArtGallery;
