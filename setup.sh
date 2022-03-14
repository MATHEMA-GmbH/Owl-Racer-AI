#!/bin/bash

# 1. Change folder and download wanted repos

cd ./src/

git clone https://git.matheads.de/data-science/owlracer-ai-opensource-server.git
git clone https://git.matheads.de/data-science/owlracer-ai-opensource-ui.git
git clone https://git.matheads.de/data-science/owlracer-ai-group/owlracer-ai-opensource-client-ml.net.git
git clone https://git.matheads.de/data-science/owlracer-ai-group/owlracer-ai-opensource-client-python.git

#git clone https://github.com/MATHEMA-GmbH/Owl-Racer-AI-UI.git
#git clone https://github.com/MATHEMA-GmbH/Owl-Racer-AI-Client-ML.Net.git
#git clone https://github.com/MATHEMA-GmbH/Owl-Racer-AI-Client-Python.git

# 2. Create solution file for VS

cd ..
dotnet new sln
proj="$(find ./ | grep "csproj$")"
dotnet sln add $proj


# Wait for key on fin
echo Waiting for key press
read -n 1 -s