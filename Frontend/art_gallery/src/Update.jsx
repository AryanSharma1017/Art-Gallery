import React, { useState, useEffect } from 'react';
import "./searchbar.css";

const Update = () => {
  const [selectedOption, setSelectedOption] = useState('');
  const [formData, setFormData] = useState({
    id: '',
    firstName: '',
    lastName: '',
    email: '',
    passwordHash: '',
    role: '',
    description: ''
  });

  useEffect(() => {
    // Reset form data when selected option changes
    setFormData({
      id: '',
      firstName: '',
      lastName: '',
      email: '',
      passwordHash: '',
      role: '',
      description: ''
    });
  }, [selectedOption]);

  const handleOptionChange = (option) => {
    setSelectedOption(option);
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
      const response = await fetch(`http://localhost:5033/api/${selectedOption}/${formData.id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
      });
      if (response.ok) {
        console.log(`${selectedOption} updated successfully`);
        // Optionally, redirect or show a success message
      } else {
        console.error(`Failed to update ${selectedOption}`);
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };

  return (
    <div className='Update'>
      <h2>Update</h2>
      <div className='Poptions'>
        <label htmlFor='options'>Select Entity to Update:</label>
        <select id='options' value={selectedOption} onChange={(e) => handleOptionChange(e.target.value)}>
          <option value=''>Select</option>
          <option value='ArtGallery'>Art Gallery</option>
          <option value='Artifacts'>Artifacts</option>
          <option value='Artist'>Artist</option>
          <option value='ArtTypes'>Art Types</option>
          <option value='Exhibition'>Exhibition</option>
          <option value='User'>User</option>
        </select>
      </div>
      {selectedOption && (
        <div className='Div1'>
          <form onSubmit={handleSubmit} className='UpdateForm'>
            <div className='form-group'>
              <label htmlFor='id'>ID:</label>
              <input type='text' id='id' name='id' value={formData.id} onChange={handleChange} />
            </div>
            {/* Render form fields based on selected option */}
            {/* Add fields dynamically based on selected option */}
            {Object.keys(formData).map((field, index) => (
              field !== 'id' && (
                <div className='form-group' key={index}>
                  <label htmlFor={field}>{field.charAt(0).toUpperCase() + field.slice(1)}:</label>
                  <input type='text' id={field} name={field} value={formData[field]} onChange={handleChange} />
                </div>
              )
            ))}
            <div className='Div2'>
              <button type='submit'>UPDATE</button>
            </div>
          </form>
        </div>
      )}
    </div>
  );
};

export default Update;
