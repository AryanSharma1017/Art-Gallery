import React, { useState, useEffect } from 'react';
import './home.css';

const Home = () => {
    const welcomeMessages = [
        'Artist',
        'Artifacts',
        'Art Types',
        'Exhibition'
    ];

    const [index, setIndex] = useState(0);
    const [text, setText] = useState(
        <h1>Create &nbsp; <span>{welcomeMessages[index]}</span></h1>
    );

    useEffect(() => {
        const interval = setInterval(() => {
            setIndex((prevIndex) => (prevIndex + 1) % welcomeMessages.length);
        }, 1000);

        return () => {
            clearInterval(interval);
        };
    }, []);

    useEffect(() => {
        setText(
            <h1>Create &nbsp; <span>{ welcomeMessages[index]}</span></h1>
        );
    }, [index]);

    return (
        <div className='HomePage'>
            <h1 >{text}</h1>
            <div className='buttons'>
                <button>POST</button>
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
