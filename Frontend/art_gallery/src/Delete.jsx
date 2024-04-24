import React, { useState } from "react";
import "./searchbar.css";

const Delete = () => {
    const [selectedOption, setSelectedOption] = useState("");
    const [formData, setFormData] = useState({
    id: "",
});

const handleOptionChange = (option) => {
    setSelectedOption(option);
    setFormData({ id: "" });
};

const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
};

const handleSubmit = async (e) => {
    e.preventDefault();
    if (!formData.id) {
        alert("Please enter an ID to delete.");
        return;
    }
    try {
        const response = await fetch(
        `http://localhost:5033/api/${selectedOption}/${formData.id}`,
        {
            method: "DELETE",
            headers: {
            "Content-Type": "application/json",
            },
        }
        );
        if (response.ok) {
            console.log(`${selectedOption} deleted successfully`);
            setFormData({ id: "" });
        } else {
            console.error(`Failed to delete ${selectedOption}`);
        }
    } catch (error) {
        console.error("Error:", error);
    }
};

const renderFormFields = () => {
    return (
        <div className="form-group">
            <label htmlFor="id">ID:</label>
                <input
                    type="text"
                    id="id"
                    name="id"
                    value={formData.id}
                    onChange={handleChange}
                />
        </div>
    );
};

return (
    <div className="Delete">
        <h2>Delete</h2>
        <div className="Poptions">
            <label htmlFor="options">Select Entity to Delete:</label>
                <select
                id="options"
                value={selectedOption}
                onChange={(e) => handleOptionChange(e.target.value)}
                >
                    <option value="">Select</option>
                    <option value="ArtGallery">Art Gallery</option>
                    <option value="Artifact">Artifacts</option>
                    <option value="Artist">Artist</option>
                    <option value="ArtType">Art Types</option>
                    <option value="Exhibition">Exhibition</option>
                    <option value="User">User</option>
                </select>
        </div>
        {selectedOption && (
        <div className="Div1">
            <form onSubmit={handleSubmit} className="DeleteForm">
            {renderFormFields()}
                <div className="Div2">
                    <button type="submit">DELETE</button>
                </div>
            </form>
        </div>
        )}
    </div>
    );
};

export default Delete;
