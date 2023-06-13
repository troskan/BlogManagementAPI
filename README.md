# Blogging Platform

This project is a blogging platform built with React.js for the frontend and a .NET 7 Web API for the backend.

[Alvin-Strandberg.se](https://www.alvin-strandberg.se)

<img src="https://i.imgur.com/p7Kztub.jpg" style="height: 200px"><img src="https://i.imgur.com/0hrpMGz.jpg" style="height: 200px">

<img src="https://i.imgur.com/ihmzcc1.png" style="height: 200px"><img src="https://i.imgur.com/7tssX4q.png" style="height: 200px"><img src="https://i.imgur.com/PdW3TEV.png" style="height: 200px">





## Overview

The goal of this project is to develop a blogging platform where I can publish blog posts. The platform will also include a user authentication system so that only I can create blog posts. The frontend of the application will be built using React.js, while the backend will use a .NET 7 Web API. For data persistence, I will use Entity Framework with a code-first approach to manage a SQL database.

## Planned Features

### Frontend

1. **Blog posts page**: A page where all blog posts are listed.
2. **Individual blog post page**: A page for reading a full blog post.
3. **Login page**: A page for user authentication.
4. **Admin page**: A page where I can create, edit, and delete blog posts (accessible only after login).

### Backend

1. **User management**: Handle user authentication (login, logout).
2. **Blog post management**: Handle CRUD (create, read, update, delete) operations for blog posts.

### Database

The database will include three main tables: `User`, `Post`, and `UserComment`.

1. **User**: Stores information about users.
2. **Post**: Stores information about blog posts.
3. **UserComment**: Stores information about comments on blog posts.

## Development Plan

### Stage 1: Backend and Database

1. **Set up .NET 7 Web API project**: Create a new .NET 7 Web API project with the appropriate authentication method.
2. **Design the database schema**: Design the database schema and create the necessary models in the .NET project.
3. **Configure Entity Framework**: Set up Entity Framework for database management.
4. **Develop the API**: Implement the necessary endpoints for user management and blog post management.

### Stage 2: Frontend

1. **Set up React.js project**: Create a new React.js project.
2. **Develop the frontend**: Build the pages for the blog posts, individual blog post, login, and admin.
3. **Connect to the API**: Use `fetch` or a library such as Axios to send requests to the API.

### Stage 3: Testing and Deployment

1. **Test the application**: Ensure that all features are working as expected.
2. **Deploy the application**: Deploy the frontend and backend to a hosting service.

## Deployment

The application is planned to be deployed at [alvin-strandberg.se](https://www.alvin-strandberg.se/). Please note that the website is currently under a total overhaul.

Please follow this project for updates and release announcements.
