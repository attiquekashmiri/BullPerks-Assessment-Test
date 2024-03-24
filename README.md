# BullPerks Assessment Test

This project combines a .NET Core backend with an Angular frontend.

## Setup Instructions

### Frontend (Angular)

1. Navigate to the `assessment-test` directory.
   ```bash
   cd assessment-test
1. Install the required npm packages.
npm i

2. Run the Angular frontend.
ng serve

This will start the development server for the Angular application. You can access the frontend at http://localhost:4200.

### Backend (.NET Core)
Open the appsettings.json file in the backend project.

Update the server name in the appsettings.json file to match your server configuration.

Example:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;"
  },
  // Other configurations...
}

Make any other relevant changes in the backend code if needed.

### Running the Project
Before running the project, ensure both the frontend and backend are set up correctly.

Start the backend server according to your .NET Core environment.

Navigate to the assessment-test directory and start the Angular frontend as explained above.

Access the application through your browser.

### Additional Notes
Ensure all dependencies are installed and configured properly before running the application.
Refer to the respective documentation for Angular and .NET Core for more detailed instructions on setup and configuration.
Verify your server and database configurations to avoid any connection issues.
Feel free to reach out for further assistance or clarification.