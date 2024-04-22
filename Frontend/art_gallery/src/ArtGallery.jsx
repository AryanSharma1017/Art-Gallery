import React, { useState, useEffect } from 'react';
import "./searchbar.css"

const ArtGallery = () => {
  const [Artgalleries, setArtgallery] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5033/api/ArtGallery')
      .then(response => {
        if (!response.ok) {
          throw new Error('Failed to fetch data');
        }
        return response.json();
      })
      .then(data => {
        setArtgallery(data);
      })
      .catch(error => console.error('Error fetching data:', error));
  }, []);

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
