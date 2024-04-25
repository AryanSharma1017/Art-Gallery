import React, { useState, useEffect } from 'react';
import "./searchbar.css"
import axios from 'axios';

const Exhibition = () => {
  const [Exhibition, setExhi] = useState([]);

  useEffect(() => {
    fetchExhib();
  }, [])


  const fetchExhib = async () => {
    try{
      const response = await axios.get('http://localhost:5033/api/Exhibition', {
        auth: {
          username: localStorage.getItem('email'),
          password: localStorage.getItem('password'),
        },
      });
      console.log(response)
      setExhi(response.data);
    }

    catch(error)
    {
      console.error('Error in fetching the Exhibitions:', error);
    }

    console.log(localStorage.getItem('email'));
    console.log(localStorage.getItem('password'));
  };
  
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
