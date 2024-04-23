import React, { useState, useEffect } from 'react';
import "./searchbar.css";

const Users = () => {
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
            {Object.keys(user).map(key => (
              <p key={key}>{key}: {user[key]}</p>
            ))}
          </div>
        ))}
      </div>
    </div>
  );
};

export default Users;