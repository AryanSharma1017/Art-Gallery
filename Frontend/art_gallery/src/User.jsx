import React, { useState, useEffect } from 'react';
import axios from 'axios';
import "./searchbar.css"

const Users = () => {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    fetchUsers();
  }, []);

  const fetchUsers = async () => {
    try {
      const response = await axios.get('http://localhost:5033/api/User', {
        auth: {
          username: localStorage.getItem('email'), 
          password: localStorage.getItem('password'), 
        },
      });
      console.log(response)
      setUsers(response.data);
    } catch (error) {
      console.error('Error fetching users:', error);
    }
    console.log(localStorage.getItem('email'));
    console.log(localStorage.getItem('password'))
  };

  return (
    <div>
      <div className="Post">
        <h2>User List</h2> 
      </div>
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