#!/bin/bash

# 1. Change folder and download wanted repos

cd ./src/

git clone https://github.com/MATHEMA-GmbH/Owl-Racer-AI-Server.git
git clone https://github.com/MATHEMA-GmbH/Owl-Racer-AI-UI.git
git clone https://github.com/MATHEMA-GmbH/Owl-Racer-AI-Client-ML.Net.git
git clone https://github.com/MATHEMA-GmbH/Owl-Racer-AI-Client-Python.git

# 2. Create solution file for VS

cd ..
dotnet new sln
proj="$(find ./ | grep "csproj$")"
dotnet sln add $proj


# Wait for key on fin
echo Waiting for key press
read -n 1 -s