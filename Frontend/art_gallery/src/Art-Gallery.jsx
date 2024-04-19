import React, { useState, useEffect } from 'react';
import "./searchbar.css"

const ArtGallery = () => {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5033/api/User')
      .then(response => {
        if (!response.ok) {
          throw new Error('Failed to fetch data');
        }
        return response.json();
      })
      .then(data => {
        setUsers(data);
      })
      .catch(error => console.error('Error fetching data:', error));
  }, []);

  return (
    <div className='ArtGallery'>
      <h2>User List</h2>
      <div className='user-list'>
        {users.map(user => (
          <div key={user.id} className='user-card'>
            <p>ID: {user.id}</p>
            <p>Name: {user.firstName} {user.lastName}</p>
            <p>Email: {user.email}</p>
            <p>Role: {user.role}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default ArtGallery;
