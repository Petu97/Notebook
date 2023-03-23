# This file contains my plans fro creating this application

The goal of this project is to develop a notebook application from scratch using methods i've not tried out before. The main goal of this project is to explore code testing in visual studio.
The project starts by creating a bareboned plan for the application structure. The code functionality is created using TDD method.

## Application structure

This application is built in Dotnet(Core) framework with C# language. The application is a WebAPI that responses to HTTP requests. 

![image](https://user-images.githubusercontent.com/60960104/227202231-75a146c7-32f8-4bc8-a5d4-abfaaa7b2e5a.png)


## Workflow

This project was created with a few goals in mind. The first goal is to practice creating and running tests in Visual Studio environment and the second one is to try out working with TDD workflow. Keep in mind that the benefits of TDD tend to ramp up the larger the project gets. In this case i'll be working on a small and simple application, so the benefits of TDD are going to be very limited. 

I will follow the principle of TDD throughout this project. First i'll start by creating a simple plan for the structure of the application. The structure consists of the bareboned application structure to make moving forward a little easier. The code functionality is created using TDD principle. Whenever a new functionality is needed i will start off by creating unit tests for that specific function. The functionality is implemented based on tests. 

![image](https://user-images.githubusercontent.com/60960104/227201162-f6d071a9-8dc2-4e59-b09a-39fd22d4eb81.png)

The testing will be done with xUnit tool for dotnet. The test types are Unit, Integratio and End-to-end testing. Testing will follow the testing pyramid structure.
