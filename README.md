# Matlabs OwlRacer AI

## Table of Contents

* [Introduction](#introduction)
* [Architecture](#architecture)
  * [Server](#server)
  * [Common Library](#common-library)  
  * [Local Client](#local-client)  
  * [Web Client](#web-client)
  * [Machine Learning Algorithm](#machine-learning-algorithm)
  * [ML.NET Model Loader](#ml.net-model-loader)
* [SDK](#sdk)
* [Setup for local development](#setup-for-local-development)
  * [.NET Projects](#.net-projects)
  * [Machine Learning Samples](#machine-learning-samples)

## Introduction

This repository contains all the files for the Matlabs OwlRacer AI project. The goal of this project is to play around and work with a AI using a simple racing game framework. It is intented for students and colleagues who want to get started with machine learning or try out their own models.

## Architecture

The OwlRacer project consists of two major parts: First is the 'Server', whose purpose is to control all the aspects of the racing game without actually providing an UI. It holds all the required information, about the track, the race cars, in which direction they are driving etc. Then there are 'Clients' which can be used to control the cars on the Server by sending commands like "Please rotate the car now" or querying data like "How far is it to the next wall on my righthand-side?".

The communication between Server and Clients is realized using (Web-)gRPC which allows fast IPC (Inter-Process-Communication) between process- and machine boundaries. This way, the Server can run on a separate and faster machine, serving multiple clients at once. The Client on the other hand can virtually be anything (gRPC/protobuf is supported on a good amount of platforms and languages). This repository contains a visual Client to enable the user to 'see' what is actually happening with his Car on the client and even control it with the cursor keys. Also an experimanteal Web-Client is included and may be expanded in the future.

Usually Clients want to be more low-key though, like console-based AI trainers written in Python e.g.

To support pre-computed machine learning models, the Server supports a ML.NET based component to load and execute these models. This is an alternative for on-the-fly learning on the server.

![Architecture Overview](doc/OwlracerArchOverview.png "Architecture Overview")

### Server

The Server is the central part of the project, calculating the outcome of the commands sent by the clients, keeping everything synchronized and providing services for controlling the racing game overall. The communication between the Server and Clients is performed using (Web-)gRPC.

For more information on the component, [visit its documentation here](src/Matlabs.OwlRacer.Server/README.md).

The Server itself is ASP.NET Core based, which means it is able to host the Web-Client directly within its process space (see Web-Client below).

The Server also contains some sub-components:

### Common Library

The common library contains shared models and classes for easier data exchange between the Local Client and the Server projects, as they reside within the same Visual Studio solution. This project is built and used by the other .NET projects directly and does not require additional documentation.

### Local Client

The Local Client is a visual test and sandbox client implemented with the MonoGame Framework. MonoGame is based on Microsofts XNA Framework and enables fast and lightweight 2D rendering perfectly suited for the purpose of showing the user what is going on during machine learning. It also enables the users to drive a car themselves and even compete against AI and other opponents.

Note however, that the Local Client (as the Web Client) is merely a tool to give developers a visual representation to make analysis easier (ok, and to incorporate some fun into the project^^). The main focus still relies on the machine learning clients doing the actually interesting stuff.

The communication between the Local Client and the Server is realized using a (Web-)gRPC channel.

For more information on the component, [visit its documentation here](src/Matlabs.OwlRacer.GameClient/README.md).

#### Web Client

The Web-Client is a .NET Blazor-based Web-Application that is able to connect to the Server and display different game sessions as a spectator and even start playing in your Browser by creating or joining a session.

For communication with the Server, again (Web-)gRPC is used.

For more information on the component, [visit its documentation here](src/Matlabs.OwlRacer.WebClient/README.md).

#### Machine Learning Algorithm

This component represents virtually any Client that connects to the Server via (Web-)gRPC with the intent to train an AI model to drive the car around the track.

Any language and implementation can be used that supports gRPC and allows nearly any developer interested in machine learning to start implementing their own algorithms.

Currently there are sample algorithms available, written in Python.

For more information on the component, [visit its documentation here](src/PythonSamples/README.md).

#### ML.NET Model Loader

The ML.NET Model Loader is capable of loading previously created AI models into the Server and executing them directly. The component is still in the early stages of development, so no documentation or direct implenentation is yet available.

### SDK

A SDK is currently in development and no documentation is yet available unfortunately.

### Setup for local development

If you want to develop directly on the project, the following requirements must be met.

#### .NET Projects

The .NET projects include the Server, the Common Library, the Local Client, the Web-Client and the ML.NET model loader
* .NET 5 SDK or later
* Visual Studio 2019 or later
* A protobuf compiler (can be installed with Visual Studio)

The main Visual Studio solution containing all the .NET projects all in one, is the *Matlabs.OwlRacer.sln* found in the */src*-Folder

When all requirements above are met, the solution should build without any further setup or problems.

There are currently two standard configurations for the solution, **DEBUG** and **RELEASE**. Apart from some more verbose console output and the usual facts about **DEBUG** and **RELEASE** builds, the configuration you use will not matter that much at the moment.

When starting the projects, the Server should always be started first, the any other Client you want to use. It is recommended to setup multiple startup-projecsts in the solution settings, having the Server start before the Client, to make things easier.

Note that the Web-Client will only require the Server to be started as it is hosted directly within the ASP.NET host. It does not have to be started explicitly, you can just visit the bound address.

#### Machine Learning Samples

Development and use of the machine learning samples [is described separately in this README](src/PythonSamples/README.md).