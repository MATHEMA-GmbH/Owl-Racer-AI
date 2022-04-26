![Logo](./doc/owlracer-logo.png)

# Owl Racer


<p align="center">

  ## Get Conected

  <a href="https://de.linkedin.com/company/mathema-gmbh" align="center" >
          <img src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white" /></a>

  <a href="https://www.youtube.com/channel/UC0vntD32UJckGUXcVvlrIiA">
          <img src="https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white" /></a>

  <a href="https://twitter.com/MATHEMA_GmbH">
          <img src="https://img.shields.io/badge/Twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white" /></a>

  <a href="https://www.facebook.com/mathema.software.gmbh/">
            <img src="https://img.shields.io/badge/Facebook-1877F2?style=for-the-badge&logo=facebook&logoColor=white" /></a>

</p></center>

____

<a href="https://www.mathema.de/blog">
        <img src="https://img.shields.io/badge/Blog%20Article-1-green?style=social" /></a>

____

## Table of Contents

* [Introduction](#introduction)
* [Architecture](#architecture)
  * [Server](#server)
  * [Common Library](#common-library)  
  * [Local Client](#local-client)
  * [Machine Learning Algorithm](#machine-learning-algorithm)
* [Setup for local development](#setup-for-local-development)
  * [.NET Projects](#.net-projects)


## Introduction

This repository serves as the head repo for the Owl Racer AI project.
The goal of this project is to play around and work with an AI using a simple racing game framework.
It is intended for students, colleagues and enthusiasts who want to get started with machine learning or try out their own models.

## Architecture


The Owl Racer project consists of two major parts: First is the server, whose purpose is to control all the aspects of the racing game without providing an UI. It holds all the required information, about the track, the race cars, in which direction they are driving etc. Further there is a dedicated UI implementation in Monogame. Then there are clients which can be used to control the cars on the server by sending commands like "Please rotate the car now" or querying data like "How far is it to the next wall on my righthand-side?".

The communication between server and clients is realized using (Web-)gRPC which allows fast IPC (Inter-Process-Communication) between process- and machine boundaries. This way, the server can run on a separate and faster machine, serving multiple clients at once. The client on the other hand can virtually be anything (gRPC/protobuf is supported on a good amount of platforms and languages). This repository contains a UI client to enable the user to watch what is actually happening with his car on the client and even control it with the cursor keys.

Usually clients want to be more low-key though, like console-based AI trainers written in Python e.g. Check the [MATHEMA GitHub](https://github.com/MATHEMA-GmbH) for more supported languages.

To support pre-computed machine learning models the clients maintained by MATHEMA provide ONNX interfaces.

![Architecture Overview](doc/schema_owlracer-1_sRGB.jpg "Architecture Overview")

### Server

The server is the central part of the project, calculating the outcome of the commands sent by the clients, keeping everything synchronized and providing services for controlling the racing game overall. The communication between the Server and Clients is performed using (Web-)gRPC.

For more details on the component, [visit its documentation here](https://github.com/MATHEMA-GmbH/Owl-Racer-AI-Server).

The server itself is ASP.NET Core based, which means it is able to host the Web-Client directly within its process space.

### Common Library

The common library contains shared models and classes for easier data exchange between the UI client and the server, as they reside within the same Visual Studio solution. This project is built and used by the other .NET projects directly.

### Local UI Client

The UI client is a visual test and sandbox client implemented with the MonoGame Framework. MonoGame is based on Microsofts XNA Framework and enables fast and lightweight 2D rendering perfectly suited for the purpose of showing the user what is going on during machine learning. It also enables the users to drive a car themselves and even compete against AI.

Note however, that the UI client is merely a tool to give developers a visual representation to make analysis easier (ok, and to incorporate some fun into the project ^^). The focus still relies on the machine learning clients doing the actually interesting stuff.

The communication between the UI client and the server is realized using a (Web-)gRPC channel.

For more details on the component, [visit its documentation here](https://github.com/MATHEMA-GmbH/Owl-Racer-AI-UI).

#### Machine Learning Algorithm

This component represents virtually any client that connects to the server via (Web-)gRPC with the intent to train an AI model to drive the car around the track.

Any language and implementation can be used that supports gRPC and allows nearly any developer interested in machine learning to start implementing their own algorithms.

Currently there are sample algorithms available, written in Python.

### Setup for local development

If you want to develop directly on the project, the following requirements must be met.

#### .NET Projects

The .NET projects include the server, the common library, the UI client and the ML.NET model loader
* .NET 5 SDK or later (server, UI client, common libraries)
* .NET 3 Framework (for UI client)
* Visual Studio 2019 or later
* A [protobuf compiler](https://developers.google.com/protocol-buffers) (can be installed with Visual Studio)
* Git Bash

The main Visual Studio solution containing the project you need will be build with the setup.sh. This way your project contains the repositories you need

For Windows install with the PowerShell ``. .\setup.sh ``

If all requirements above are met, the solution should build without any further setup or problems.

There are currently two standard configurations for the solution, **DEBUG** and **RELEASE**. Apart from some more verbose console output and the usual facts about **DEBUG** and **RELEASE** builds, the configuration you use will not matter that much at the moment.

When starting the projects, the server should always be started first, for any other client you want to use. It is recommended to setup multiple startup-projecsts in the solution settings, having the server start before the client, to make things easier.

For execution of the different clients you need to edit the file paths in ``Matlabs.OwlRacer.GameClient\appsettings.json``
We provide you some examples in ``Matlabs.OwlRacer.GameClient\appsettings_examples.json``
