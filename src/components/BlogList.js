import React, { useState, useEffect } from 'react';
import axios from 'axios';

const BlogList = () => {
    const [blogs, setBlogs] = useState([]);

    useEffect(() => {
        console.log('Fetching blogs from API...');
        axios.get('https://localhost:44346/api/blog') // Use the correct API URL here
            .then(response => {
                console.log('Blogs fetched:', response.data);
                setBlogs(response.data);
            })
            .catch(error => {
                console.error('There was an error fetching the blogs!', error);
            });
    }, []);

    return (
        <div>
            <h1>Blogs</h1>
            <ul>
                {blogs.map(blog => (
                    <li key={blog.id}>
                        <h2>{blog.title}</h2>
                        <p>{blog.content}</p>
                        <p>{new Date(blog.createdAt).toLocaleDateString()}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default BlogList;
