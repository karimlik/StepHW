# WPF MVVM Application
This is a simple WPF application that demonstrates the Model-View-ViewModel (MVVM) architecture pattern. The application displays a list of cars and allows the user to search for cars by name or refresh the list.

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

## Prerequisites
To run this application, you will need:

Visual Studio 2022 or later
.NET Core 6.0 or later
## Installing
Clone the repository to your local machine:
bash
```
git clone https://github.com/karimlik/StepHW.git
```
Open the solution file (WpfMvvmApp.sln) in Visual Studio.

Build and run the application.

## Architecture
This application is built using the Model-View-ViewModel (MVVM) architecture pattern. The MVVM pattern is a variation of the Model-View-Controller (MVC) pattern that separates the user interface (View) from the application logic (ViewModel) and the data model (Model).

## Model
The Model represents the data and business logic of the application. In this application, the Model consists of a Car class that represents a car and a CarService class that provides methods to retrieve a list of cars from a data source.

## View
The View represents the user interface of the application. In this application, the View consists of a CarListView class that displays a list of cars and provides search and refresh functionality.

## ViewModel
The ViewModel acts as a bridge between the View and the Model. It provides data and behavior to the View and communicates with the Model to retrieve and manipulate data. In this application, the ViewModel consists of a CarListViewModel class that provides data and behavior to the CarListView and communicates with the CarService to retrieve and manipulate data.

## Contributing
If you'd like to contribute to this project, please fork the repository and create a pull request.
