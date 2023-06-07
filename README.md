# File Downloader Project
Made for a client and is a paid task. This project is a file downloader application written in C#. It utilizes REST API integration using RestSharp and Metro-Modern UI for the front-end design. The application allows users to input a CSV file path and download files based on the information in each row, applying custom logic as required by the client. Additionally, it incorporates an asynchronous logging framework for efficient and non-blocking logging.

## Features
### REST API Integration: 
The project uses RestSharp to interact with the REST API for file downloads. RestSharp provides a convenient and efficient way to make HTTP requests and handle API responses.

### Metro-Modern UI: 
The front-end of the application is designed using the Metro-Modern UI framework. This framework offers a modern and visually appealing user interface, enhancing the user experience.

### CSV Input: 
Users are prompted to provide a CSV file path containing the necessary information for downloading files. The application reads the CSV file and processes each row to initiate file downloads.

### Custom Logic: 
The project allows for the implementation of custom logic as required by the client. This enables the application to handle specific requirements or business rules associated with file downloading.

### Asynchronous Logging: 
The logging framework implemented in the project is asynchronous, ensuring that logging operations do not block the application's execution. Asynchronous logging enhances performance and responsiveness.

## Prerequisites
To run the file downloader project, make sure you have the following prerequisites installed:

.NET Framework 
RestSharp library 
Metro-Modern UI library 

## Usage
Follow the steps below to use the file downloader project:

Clone or download the project repository to your local machine.
Open the project solution in your preferred C# development environment (e.g., Visual Studio).
Build the solution to resolve any dependencies and ensure successful compilation.
Run the application.
Input the CSV file path when prompted by the application.
The application will process each row of the CSV file and initiate file downloads based on the provided information and any custom logic implemented.
As the file downloads progress, the application will log the relevant information using the asynchronous logging framework.
Ensure that you have an active internet connection to interact with the REST API for file downloads.

## Configuration
If required, you can modify the configuration settings of the file downloader project. Look for the configuration files or settings within the project and adjust them according to your needs. For example, you may need to update API endpoint URLs or logging configurations.

## Contributing
Contributions to this file downloader project are welcome. To contribute, follow these steps:

Fork the repository.
Create a new branch for your feature or bug fix.
Implement your changes.
Test your changes thoroughly.
Create a pull request, providing a detailed description of your changes.
Please adhere to the existing coding style, include appropriate unit tests, and ensure that your changes do not break any existing functionality.

## License
  This project is licensed under the <b>MIT License</b>. Feel free to use, modify, and distribute it as per the license terms.

## Acknowledgements
  This project was developed by <b><u>Muneeb Ur Rehman</u></b>. Special thanks to the open-source community for their contributions and support.

  For any questions or inquiries, please contact muneeb110@live.com.
