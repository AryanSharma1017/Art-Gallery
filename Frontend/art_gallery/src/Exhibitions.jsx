import React, { useState, useEffect } from 'react';
import "./searchbar.css"

const Exhibition = () => {
  const [Exhibition, setExhi] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5033/api/Exhibition')
      .then(response => {
        if (!response.ok) {
          throw new Error('Failed to fetch data');
        }
        return response.json();
      })
      .then(data => {
        setExhi(data);
      })
      .catch(error => console.error('Error fetching data:', error));
  }, []);

  return (
    <div className='ArtGallery'>
      <h2>Exhibition List</h2>
      <div className='user-list'>
        {Exhibition.map(Exhibition => (
          <div key={Exhibition.id} className='user-card'>
            {Object.keys(Exhibition).map(key => (
              <p key={key}>{key}: {Exhibition[key]}</p>
            ))}
          </div>
        ))}
      </div>
    </div>
  );
};

export default Exhibition;
