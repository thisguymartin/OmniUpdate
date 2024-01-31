#!/bin/bash

# Database connection details
DB_HOST="your_database_host"
DB_PORT="your_database_port"
DB_NAME="your_database_name"
DB_USER="your_database_user"
DB_PASSWORD="your_database_password"

# Define the SQL query to create the database if it doesn't exist
CREATE_DB_QUERY="CREATE DATABASE IF NOT EXISTS $DB_NAME;"

# Define the SQL query to create the "Users" table
CREATE_TABLE_QUERY="CREATE TABLE IF NOT EXISTS Users (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Archived BOOLEAN NOT NULL,
    ImageUrl TEXT,
    CreateDate TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    UpdateDate TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    CONSTRAINT UQ_Users_Name UNIQUE (Name)
);"

# Define the SQL query to insert records
INSERT_QUERY="INSERT INTO Users (Id, Name, Archived, ImageUrl, CreateDate, UpdateDate) VALUES
    (1, 'John Doe', false, 'https://example.com/johndoe.jpg', '2023-01-15 08:30:00', '2023-01-15 08:30:00'),
    (2, 'Jane Smith', true, null, '2023-01-16 09:15:00',
