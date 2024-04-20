import React, { useState } from 'react';
import "./searchbar.css";

const Post = () => {
  const [selectedOption, setSelectedOption] = useState('');
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    passwordHash: '',
    role: '',
    description: ''
  });

  const handleOptionChange = (option) => {
    setSelectedOption(option);
    // Reset form data when changing option
    setFormData({
      firstName: '',
      lastName: '',
      email: '',
      passwordHash: '',
      role: '',
      description: ''
    });
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prevData => ({
      ...prevData,
      [name]: value
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch(`http://localhost:5033/api/${selectedOption}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
      });
      if (response.ok) {
        console.log(`${selectedOption} created successfully`);
        // Optionally, redirect or show a success message
      } else {
        console.error(`Failed to create ${selectedOption}`);
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };

  return (
    <div className='Post'>
      <h2>Post</h2>
      <div className='Poptions'>
        <label htmlFor='options'>Select from the following Options </label>
        <select id='options' value={selectedOption} onChange={(e) => handleOptionChange(e.target.value)}>
            <option value=''>Select</option>
            <option value='User'>User</option>
            <option value='Artist'>Artist</option>
            <option value='Artifacts'>Artifacts</option>
            <option value='Exhibitions'>Exhibitions</option>
        </select>
        </div>
      {selectedOption && (
        <div className='Div1'>
          <form onSubmit={handleSubmit} className='PostForm'>
          <div className='form-group'>
            <label htmlFor='firstName'>First Name </label>
            <input type='text' id='firstName' name='firstName' value={formData.firstName} onChange={handleChange} />
          </div>
          <div className='form-group'>
            <label htmlFor='lastName'>Last Name </label>
            <input type='text' id='lastName' name='lastName' value={formData.lastName} onChange={handleChange} />
          </div>
          <div className='form-group'>
            <label htmlFor='email'>Email </label>
            <input type='email' id='email' name='email' value={formData.email} onChange={handleChange} />
          </div>
          <div className='form-group'>
            <label htmlFor='passwordHash'>Password </label>
            <input type='password' id='passwordHash' name='passwordHash' value={formData.passwordHash} onChange={handleChange} />
          </div>
          <div className='form-group'>
            <label htmlFor='role'>Role </label>
            <input type='text' id='role' name='role' value={formData.role} onChange={handleChange} />
          </div>
          <div className='form-group'>
            <label htmlFor='description'>Description </label>
            <textarea id='description' name='description' value={formData.description} onChange={handleChange}></textarea>
          </div>
          <div className='Div2'>
            <button type='submit'>Submit</button>
          </div>
        </form>
        </div>
      )}
    </div>
  );
};

export default Post;
