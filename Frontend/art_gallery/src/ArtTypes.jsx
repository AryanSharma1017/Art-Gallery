import React, { useState, useEffect } from 'react';
import "./searchbar.css"
import axios from 'axios';

const ArtTypes = () => {
  const [arttypes, setArttypes] = useState([]);

  useEffect(() => {
    fetchArtTypes();
  }, [])


  const fetchArtTypes = async () => {
    try
    {
      const response = await axios.get('http://localhost:5033/api/ArtType', {
        auth: {
          username: localStorage.getItem('email'),
          password: localStorage.getItem('password'),
        },
      });
      console.log(response)
      setArttypes(response.data);
    }

    catch(error)
    {
      console.error('Error in fecthing ArtTypes:', error);
    }
    console.log(localStorage.getItem('email'));
    console.log(localStorage.getItem('password'));
  };
  

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
