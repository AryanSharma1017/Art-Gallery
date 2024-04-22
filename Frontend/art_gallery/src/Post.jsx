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
      } else {
        console.error(`Failed to create ${selectedOption}`);
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };

  const renderFormFields = () => {
    switch (selectedOption) {
      case 'ArtGallery':
        return (
          <>
            <div className='form-group'>
              <label htmlFor='name'>Name:</label>
              <input type='text' id='name' name='name' value={formData.name} onChange={handleChange} />
            </div>
            <div className='form-group'>
              <label htmlFor='address'>Address:</label>
              <input type='text' id='address' name='address' value={formData.address} onChange={handleChange} />
            </div>
            <div className='form-group'>
              <label htmlFor='numberofartifacts'>Number of Artifacts:</label>
              <input type='number' id='numberofartifacts' name='numberofartifacts' value={formData.numberofartifacts} onChange={handleChange} />
            </div>
            <div className='form-group'>
              <label htmlFor='ongoingExhibition'>Ongoing Exhibition:</label>
              <input type='checkbox' id='ongoingExhibition' name='ongoingExhibition' checked={formData.ongoingExhibition} onChange={handleChange} />
            </div>
            <div className='form-group'>
              <label htmlFor='exhibitionId'>Exhibition ID:</label>
              <input type='text' id='exhibitionId' name='exhibitionId' value={formData.exhibitionId} onChange={handleChange} />
            </div>
          </>
        );


      case 'Artifacts':
        return (
          <>
            <div className='form-group'>
              <label htmlFor='name'>Name:</label>
              <input type='text' id='name' name='name' value={formData.name} onChange={handleChange} />
            </div>
            <div className='form-group'>
               <label htmlFor='description'>Description </label>
               <textarea id='description' name='description' value={formData.description} onChange={handleChange}></textarea>
            </div>
            <div className='form-group'>
              <label htmlFor='type'>Type:</label>
              <input type='text' id='type' name='type' value={formData.type} onChange={handleChange} />
            </div>
            <div className='form-group'>
              <label htmlFor='Price'>Price:</label>
              <input type='text' id='price' name='price' value={formData.price} onChange={handleChange} />
            </div>
            <div className='form-group'>
              <label htmlFor='galleryID'>gallery ID:</label>
              <input type='text' id='galleryId' name='galleryId' value={formData.galleryid} onChange={handleChange} />
            </div>
            <div className='form-group'>
              <label htmlFor='artistId'>Artist ID:</label>
              <input type='text' id='ArtistId' name='ArtistId' value={formData.artistId} onChange={handleChange} />
            </div>
          </>

        );

      case 'Artist':
        return (
          <>
            <div className='form-group'>
              <label htmlFor='firstname'>First Name:</label>
              <input type='text' id='firstName' name='firstName' value={formData.firstName} onChange={handleChange} />
            </div>
            <div className='form-group'>
              <label htmlFor='lastname'>Last Name:</label>
              <input type='text' id='lastName' name='lastName' value={formData.lastName} onChange={handleChange} />
            </div>
            <div className='form-group'>
              <label htmlFor='type'>Type:</label>
              <input type='text' id='type' name='type' value={formData.type} onChange={handleChange} />
            </div>
            <div className='form-group'>
              <label htmlFor='about'>About:</label>
              <input type='text' id='about' name='about' value={formData.about} onChange={handleChange} />
            </div>
            <div className='form-group'>
              <label htmlFor='phonenumber'>Phone Number:</label>
              <input type='text' id='phonenumber' name='phonenumber' value={formData.phoneNumber} onChange={handleChange} />
            </div>
            <div className='form-group'>
              <label htmlFor='age'>Age:</label>
              <input type='text' id='age' name='age' value={formData.age} onChange={handleChange} />
            </div>
          </>

        );

      case 'ArtTypes':
        return (
          <>
            <div className='form-group'>
              <label htmlFor='name'>Name:</label>
              <input type='text' id='name' name='name' value={formData.name} onChange={handleChange} />
            </div>
            <div className='form-group'>
              <label htmlFor='origin'>Origin:</label>
              <input type='text' id='origin' name='origin' value={formData.origin} onChange={handleChange} />
            </div>
          </>

        );

        case 'Exhibition':
          return (
            <>
              <div className='form-group'>
                <label htmlFor='name'>Name:</label>
                <input type='text' id='name' name='name' value={formData.name} onChange={handleChange} />
              </div>
              <div className='form-group'>
                <label htmlFor='Description'>Description:</label>
                <input type='text' id='description' name='description' value={formData.description} onChange={handleChange} />
              </div>
              <div className='form-group'>
                <label htmlFor='galleryID'>Galery ID:</label>
                <input type='text' id='galleryID' name='galleryID' value={formData.galleryid} onChange={handleChange} />
              </div>
            </>
  
          );

      case 'User':
        return(
          <>
            <div className='form-group'>
              <label htmlFor='id'>ID </label>
              <input type='text' id='id' name='id' value={formData.id} onChange={handleChange} />
            </div>
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
          </>
        )

      // Add cases for other options (Artifacts, Artist, ArtTypes, Exhibitions) with respective form fields
      default:
        return null;
    }
  };

  return (
    <div className='Post'>
      <h2>Post</h2>
      <div className='Poptions'>
        <label htmlFor='options'>Select from the following Options </label>
        <select id='options' value={selectedOption} onChange={(e) => handleOptionChange(e.target.value)}>
          <option value=''>Select</option>
          <option value='ArtGallery'>ArtGallery</option>
          <option value='Artifacts'>Artifacts</option>
          <option value='Artist'>Artist</option>
          <option value='ArtTypes'>ArtTypes</option>
          <option value='Exhibition'>Exhibition</option>
          <option value='User'>User</option>
        </select>
      </div>
      {selectedOption && (
        <div className='Div1'>
          <form onSubmit={handleSubmit} className='PostForm'>
            {renderFormFields()}
            <div className='Div2'>
              <button type='submit'>POST</button>
            </div>
          </form>
        </div>
      )}
    </div>
  );
};

export default Post;
