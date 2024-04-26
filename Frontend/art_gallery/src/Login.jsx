import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom'; // Import useNavigate
import "./login.css"

const Login = ({ setLoginStatus }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate(); // Initialize the useNavigate hook

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      // Encode the username and password for Basic Authentication
      const credentials = btoa(`${username}:${password}`);
      const response = await axios.get('http://localhost:5033/api/User', {
        headers: {
          'Authorization': `Basic ${credentials}`
        }
      });

      localStorage.setItem('email', username);
      localStorage.setItem('password', password);
      console.log(credentials);
      console.log(response);
      if (response.status === 200) {
        setLoginStatus(true);
        navigate('/'); // Navigate to the homepage
      } else {
        setError('Authentication failed');
      }
    } catch (error) {
      setError('Authentication failed');
    }
  };

  return (
    <div className="login" >
        <div className='Login2'>
            <h1>Login</h1>
            <form onSubmit={handleLogin}>
                <div>
                <label>Username:</label>
                <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} />
                </div>
                <div>
                <label>Password:</label>
                <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
                </div>
                {error && <div className="error">{error}</div>}
                <button type="submit">Login</button>
            </form>
        </div>
    </div>
  );
};

export default Login;