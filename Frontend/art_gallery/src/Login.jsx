// import { useState } from "react";
// import { Link, useNavigate } from "react-router-dom";
// import axios from "axios";

// function Login(props) {
//     const navigate = useNavigate();

//     const [userDetails, setUserDetails] = useState({ email: "", password: "" });
//     const [error, setError] = useState("");

//     const { email, password } = userDetails;

//     async function handleLogIn(event) {
//         event.preventDefault();

//         try {
//             if (!email || !password) {
//                 setError("All fields are required");
//                 return;
//             }
//             const response = await axios.get("http://localhost:5033/api/User", {
//                 auth: {
//                     username: email,
//                     password: password
//                 }
//             });

//             // Assuming the response contains user data
//             const userData = response.data;

//             // Do something with userData, e.g., save it to localStorage
//             localStorage.setItem("userData", JSON.stringify(userData));

//             // Call the loginUser function from props to update the login state
//             props.loginUser();

//             // Redirect to the home page after successful login
//             navigate("/");
//         } catch (error) {
//             setUserDetails({ email: "", password: "" });
//             setError("Invalid credentials");
//             console.error("Invalid credentials", error.message);
//         }
//     }

//     function handleInputChange(event) {
//         const eventName = event.target.name;
//         const eventValue = event.target.value;

//         setUserDetails((previousDetails) => {
//             return {
//                 ...previousDetails,
//                 [eventName]: eventValue,
//             };
//         });
//     }

//     return (
//         <div>
//             <div>
//                 {/* Assuming you have a Header component */}
//                 <Header loggedIn={false} />
//             </div>
//             <div className="login-parent">
//                 <form onSubmit={handleLogIn}>
//                     <div>
//                         <label>Email:</label>
//                         <input
//                             type="email"
//                             name="email"
//                             value={email}
//                             onChange={handleInputChange}
//                         />
//                     </div>
//                     <div>
//                         <label>Password:</label>
//                         <input
//                             type="password"
//                             name="password"
//                             value={password}
//                             onChange={handleInputChange}
//                         />
//                     </div>
//                     {error && <div className="error">{error}</div>}
//                     <button type="submit">Login</button>
//                 </form>
//                 <p>
//                     Don't have an account? <Link to="/register">Register</Link>
//                 </p>
//             </div>
//         </div>
//     );
// }

// export default Login;


import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import axios from "axios";

function Login(props) {
    const navigate = useNavigate();

    const [userDetails, setUserDetails] = useState({ email: "", password: "" });
    const [error, setError] = useState("");

    const { email, password } = userDetails;

    async function handleLogIn(event) {
        event.preventDefault();

        try {
            if (!email || !password) {
                setError("All fields are required");
                return;
            }
            const response = await axios.get("http://localhost:5033/api/User", {
                auth: {
                    username: email,
                    password: password
                }
            });

            // Assuming the response contains user data
            const userData = response.data;

            // Do something with userData, e.g., save it to localStorage
            localStorage.setItem("userData", JSON.stringify(userData));

            // Call the loginUser function from props to update the login state
            props.userLogin();

            // Redirect to the home page after successful login
            navigate("/");
        } catch (error) {
            setUserDetails({ email: "", password: "" });
            setError("Invalid credentials");
            console.error("Invalid credentials", error.message);
        }
    }

    function handleInputChange(event) {
        const eventName = event.target.name;
        const eventValue = event.target.value;

        setUserDetails((previousDetails) => {
            return {
                ...previousDetails,
                [eventName]: eventValue,
            };
        });
    }

    return (
        <div>
            <div>
            </div>
            <div className="login-parent">
                <form onSubmit={handleLogIn}>
                    <div>
                        <label>Email:</label>
                        <input
                            type="email"
                            name="email"
                            value={email}
                            onChange={handleInputChange}
                        />
                    </div>
                    <div>
                        <label>Password:</label>
                        <input
                            type="password"
                            name="password"
                            value={password}
                            onChange={handleInputChange}
                        />
                    </div>
                    {error && <div className="error">{error}</div>}
                    <button type="submit">Login</button>
                </form>
                <p>
                    Don't have an account? <Link to="/register">Register</Link>
                </p>
            </div>
        </div>
    );
}

export default Login;
