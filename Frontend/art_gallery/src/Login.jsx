import React, { useState } from 'react';
import axios from 'axios'; // Import axios for making HTTP requests
import { redirect } from 'react-router-dom';

const Login = ({ setIsAuthenticated }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [redirectToMain, setRedirectToMain] = useState(false);
  const [error, setError] = useState('');

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      // Encode the username and password for Basic Authentication
      const credentials = btoa(`${username}:${password}`);
      const response = await axios.get('http://localhost:5033/login', {
        headers: {
          'Authorization': `Basic ${credentials}`
        }
      });
      if (response.status === 200) {
        setIsAuthenticated(true);
        setRedirectToMain(true);
      } else {
        setError('Authentication failed');
      }
    } catch (error) {
      setError('Authentication failed');
    }
  };

  if (redirectToMain || isAuthenticated) {
    return <redirect to="/" />;
  }

  return (
    <div className="login">
      <h2>Login</h2>
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
  );
};

export default Login;
