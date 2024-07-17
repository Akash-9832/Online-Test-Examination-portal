# Online Test Examination portal

This is an ASP.NET MVC web application for an online examination system. The application provides a responsive user interface for users to interact with the system and includes a login validation process using data stored in an Excel file.


## Project Description

The Online Examination System is a web application designed to facilitate the process of conducting online exams. The application allows users to log in as either an admin or a candidate, and based on their role, they can access different functionalities of the system.

## Technology Stack

- **Frontend:**
  - HTML
  - CSS
  - JavaScript
  - Bootstrap 5

- **Backend:**
  - ASP.NET Core
  - C#
  - EPPlus library for Excel file handling

- **Database:**
  - Microsoft SQL Server

## Features

- **Login Page:** 
  - Users can log in as either an admin or a candidate.
  - Login validation is performed using data from an Excel file.
  - Appropriate messages are displayed based on the login validation result.

- **Responsive Design:**
  - The application uses Bootstrap to ensure a responsive user interface across different devices.

- **Admin and Candidate Login:**
  - Admin login requires username and password.
  - Candidate login requires username and date of birth (DOB).
## Usage
1. Open the application in a web browser.
2. The login page will appear. Select either "Admin" or "Candidate" and enter the required credentials.
3. Click the "Login" button. If the credentials are valid, a pop-up message will display "username, You are successfully logged in" and you will be redirected to the main page. If the credentials are invalid, a pop-up message will display "Login failed" and you will be redirected to the main page.
