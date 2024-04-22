import React, { useState, useEffect } from 'react';
import "./searchbar.css"

const Artifacts = () => {
  const [artifact, setartifact] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5033/api/Artifacts')
      .then(response => {
        if (!response.ok) {
          throw new Error('Failed to fetch data');
        }
        return response.json();
      })
      .then(data => {
        setartifact(data);
      })
      .catch(error => console.error('Error fetching data:', error));
  }, []);

  return (
    <div className='ArtGallery'>
      <h2>Artifacts List</h2>
      <div className='user-list'>
        {artifact.map(Artifacts => (
          <div key={Artifacts.id} className='user-card'>
            {Object.keys(Artifacts).map(key => (
              <p key={key}>{key}: {Artifacts[key]}</p>
            ))}
          </div>
        ))}
      </div>
    </div>
  );
};

export default Artifacts;
