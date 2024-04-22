import React, { useState, useEffect } from 'react';
import "./searchbar.css"

const ArtTypes = () => {
  const [arttypes, setArttypes] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5033/api/ArtTypes')
      .then(response => {
        if (!response.ok) {
          throw new Error('Failed to fetch data');
        }
        return response.json();
      })
      .then(data => {
        setArttypes(data);
      })
      .catch(error => console.error('Error fetching data:', error));
  }, []);

  return (
    <div className='ArtGallery'>
      <h2>Art Types List</h2>
      <div className='user-list'>
        {arttypes.map(ArtTypes => (
          <div key={ArtTypes.id} className='user-card'>
            {Object.keys(ArtTypes).map(key => (
              <p key={key}>{key}: {ArtTypes[key]}</p>
            ))}
          </div> 
        ))}
      </div>
    </div>
  );
};

export default ArtTypes;
