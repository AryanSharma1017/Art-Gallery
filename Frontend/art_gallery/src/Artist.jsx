import React, { useState, useEffect } from 'react';
import "./searchbar.css"
import axios from 'axios';

const Artist = () => {
  const [Artists, setArtist] = useState([]);

  useEffect(()=> {
    fetchArist();
  }, [])

  const fetchArist = async () => {
    try
    {
      const response = await axios.get('http://localhost:5033/api/Artist', {
        auth: {
          username: localStorage.getItem('email'),
          password: localStorage.getItem('password'),
        },
      });
      console.log(response)
      setArtist(response.data);
    }
    catch(error) {
      console.error('Error in fetching Artist:', error);
    }

    console.log(localStorage.getItem('email'));
    console.log(localStorage.getItem('password'));
  };


  return (
    <div className='ArtGallery'>
      <h2>Artist List</h2>
      <div className='user-list'>
        {Artists.map(artist => (
          <div key={artist.id} className='user-card'>
            {Object.keys(artist).map(key => (
              <p key={key}>{key}: {artist[key]}</p>
            ))}
          </div>
        ))}
      </div>
    </div>
  );
};

export default Artist;
