import React, { useState, useEffect } from 'react';
import "./searchbar.css"

const Artist = () => {
  const [Artists, setArtist] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5033/api/Artist')
      .then(response => {
        if (!response.ok) {
          throw new Error('Failed to fetch data');
        }
        return response.json();
      })
      .then(data => {
        setArtist(data);
      })
      .catch(error => console.error('Error fetching data:', error));
  }, []);

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
