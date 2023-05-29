# Harvest Connect Prototype

This is a prototype of the Harvest Connect website, which allows employees to manage farmers and their associated products.
Prerequisites

Before you can build and run the prototype, ensure you have the following tools installed on your machine:

- Visual Studio - We recommend using Visual Studio as the development environment.
- .NET Framework - The prototype is built using .NET Framework Version 4.8, so make sure you have it installed.

## Getting Started

To build and run the prototype, follow these steps:

- Download the project files from the provided zip file.
- Extract the zip file to a desired location on your machine.

## Building the Project

To build the project, follow these steps:

- Open Visual Studio.
- Click on File > Open > Project/Solution.
- Navigate to the extracted project folder and select the solution file (ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.sln).
- Once the solution is opened, go to the Build menu and select Build Solution.
- Visual Studio will compile the project and generate the necessary binaries.

## Running the Prototype

To run the prototype, follow these steps:

- Make sure the project has been built successfully.
- In Visual Studio, go to the Debug menu and select Start Debugging or press F5.
- The prototype will start running, and the default web browser will open the Farmers Hub home page.
- You can now navigate through the prototype, log in as an employee, and perform various actions such as adding farmers, managing their products, and applying filters.

## Project Structure

The project follows a typical ASP.NET MVC architecture and consists of the following main components:

- Controllers - Contains the controller classes responsible for handling requests and managing the flow of data.
- Models - Defines the data models used in the application.
- Views - Contains the Razor view templates that define the user interface.

### Additional Notes

- The prototype uses a local database for storing farmers and products. Make sure you have a compatible version of SQL Server installed on your machine. The connection string can be configured in the web.config file.
- The prototype is intended for demonstration purposes only and may not include all the features and error handling required in a production-ready application.

### License

This project is licensed under the MIT License.
