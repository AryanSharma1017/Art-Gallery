import React, { useState, useEffect } from 'react';
import './home.css';
import { Link } from 'react-router-dom'; 

const Home = () => {
    const welcomeMessages = [
        'Artist',
        'Artifacts',
        'Art Types',
        'Exhibition'
    ];


    const load_images = [
        'https://cdn11.bigcommerce.com/s-v1jc6q/product_images/uploaded_images/iconico1-capture-a-hyper-realistic-image-of-an-australian-abori-95b385bd-eb15-45e8-ba53-a0da9d01c8f1.png',
        'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQbwgVfeXJUh5bNu2DL7h2JbfNipRiTcF8LhVpGDhE1TA&s',
        'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQbwgVfeXJUh5bNu2DL7h2JbfNipRiTcF8LhVpGDhE1TA&s',
        'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQbwgVfeXJUh5bNu2DL7h2JbfNipRiTcF8LhVpGDhE1TA&s',
        'https://assets.hellovector.com/product-images/assets/blog/dreamtime.jpg'
    ];


    const [index, setIndex] = useState(0);
    const [text, setText] = useState(
        <h1>Create &nbsp; <span>{welcomeMessages[index]}</span></h1>
    );


    const [imageIndex, setImageIndex] = useState(0);

    useEffect(() => {
        const interval = setInterval(() => {
            setIndex((prevIndex) => (prevIndex + 1) % welcomeMessages.length);
        }, 1000);

        const imageInterval = setInterval(() => {
            setImageIndex((prevIndex) => (prevIndex + 1) % load_images.length);
        }, 1000);

        return () => {
            clearInterval(interval);
            clearInterval(imageInterval);
        };
    }, []);

    useEffect(() => {
        setText(
            <h1>Create &nbsp; <span>{ welcomeMessages[index]}</span></h1>
        );
    }, [index]);

    return (
        <div className='HomePage'>
            <img src={load_images[imageIndex]} alt="aborginial art" />
            <h1 >{text}</h1>
            <div className='buttons'>
                <Link to="/post"><button>POST</button></Link>
                <button>UPDATE</button>
                <button>DELETE</button>
            </div>

            <div className='para'>
                <p id='typewriter'>Welcome to Aboriginal Art Gallery, where creativity meets expression! Immerse yourself in a world of vibrant colors, captivating brushstrokes, and thought-provoking sculptures. Our gallery showcases the extraordinary talents of both established and emerging artists from around the globe. Explore a diverse range of artistic styles, from classical masterpieces to contemporary works pushing the boundaries of innovation. Whether you're a seasoned art enthusiast or just beginning your journey, there's something here to ignite your imagination and stir your soul. Join us on an inspiring visual journey as we celebrate the power and beauty of art in all its forms.</p>
            </div>
        </div>
    );
};

export default Home;
