import React, { useState, useEffect } from 'react';
import "./searchbar.css"
import axios from 'axios';


const Artifacts = () => {
  const [artifact, setartifact] = useState([]);

  useEffect(() => {
    fetchArtifacts();
  }, []);

  const fetchArtifacts = async () => {
    try 
    {
      const response = await axios.get('http://localhost:5033/api/Artifact', {
        auth: {
          username: localStorage.getItem('email'),
          password: localStorage.getItem('password'),
        },
      }); 
      console.log(response)
      setartifact(response.data);
    }

    catch(error)
    {
      console.error('Error in getting the artifacts', error);
    }
    console.log(localStorage.getItem('email'));
    console.log(localStorage.getItem('password'));
  };

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
