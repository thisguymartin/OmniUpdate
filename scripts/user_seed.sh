#!/bin/bash

# Database connection details
DB_HOST="your_database_host"
DB_PORT="your_database_port"
DB_NAME="your_database_name"
DB_USER="your_database_user"
DB_PASSWORD="your_database_password"

# Define the SQL query to insert records
SQL_QUERY="INSERT INTO Users (Id, Name, Archived, ImageUrl, CreateDate, UpdateDate) VALUES
    (1, 'John Doe', false, 'https://example.com/johndoe.jpg', '2023-01-15 08:30:00', '2023-01-15 08:30:00'),
    (2, 'Jane Smith', true, null, '2023-01-16 09:15:00', '2023-01-16 09:15:00'),
    (3, 'Michael Johnson', false, 'https://example.com/michaeljohnson.jpg', '2023-01-17 10:45:00', '2023-01-17 10:45:00'),
    (4, 'Emily Davis', false, null, '2023-01-18 11:20:00', '2023-01-18 11:20:00'),
    (5, 'William Brown', true, 'https://example.com/williambrown.jpg', '2023-01-19 12:10:00', '2023-01-19 12:10:00'),
    (6, 'Susan Wilson', false, null, '2023-01-20 13:25:00', '2023-01-20 13:25:00'),
    (7, 'David Martinez', false, 'https://example.com/davidmartinez.jpg', '2023-01-21 14:45:00', '2023-01-21 14:45:00'),
    (8, 'Sarah Miller', true, null, '2023-01-22 15:55:00', '2023-01-22 15:55:00'),
    (9, 'Robert Taylor', false, 'https://example.com/roberttaylor.jpg', '2023-01-23 16:30:00', '2023-01-23 16:30:00'),
    (10, 'Linda Anderson', false, null, '2023-01-24 17:20:00', '2023-01-24 17:20:00'),
    (11, 'James Wilson', true, 'https://example.com/jameswilson.jpg', '2023-01-25 18:40:00', '2023-01-25 18:40:00'),
    (12, 'Emily Moore', false, null, '2023-01-26 19:55:00', '2023-01-26 19:55:00'),
    (13, 'Charles Johnson', false, 'https://example.com/charlesjohnson.jpg', '2023-01-27 20:10:00', '2023-01-27 20:10:00'),
    (14, 'Karen Lee', true, null, '2023-01-28 21:30:00', '2023-01-28 21:30:00'),
    (15, 'Michael Garcia', false, 'https://example.com/michaelgarcia.jpg', '2023-01-29 22:45:00', '2023-01-29 22:45:00'),
    (16, 'Jennifer Hernandez', false, null, '2023-01-30 23:05:00', '2023-01-30 23:05:00'),
    (17, 'David Wilson', true, 'https://example.com/davidwilson.jpg', '2023-01-31 00:15:00', '2023-01-31 00:15:00'),
    (18, 'Mary Clark', false, null, '2023-02-01 01:30:00', '2023-02-01 01:30:00'),
    (19, 'John Adams', false, 'https://example.com/johnadams.jpg', '2023-02-02 02:45:00', '2023-02-02 02:45:00'),
    (20, 'Laura Thomas', true, null, '2023-02-03 03:00:00', '2023-02-03 03:00:00');"

# Execute the SQL query using psql
psql -h "$DB_HOST" -p "$DB_PORT" -d "$DB_NAME" -U "$DB_USER" -c "$SQL_QUERY"

# Check for errors
if [ $? -eq 0 ]; then
  echo "Data inserted successfully."
else
  echo "Error inserting data."
fi
