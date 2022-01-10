#!/bin/bash

# 1. Change folder and dowlnoad wanted repos

cd ./src/

git clone https://git.matheads.de/data-science/owlracer-ai-opensource-server.git
git clone https://git.matheads.de/data-science/owlracer-ai-opensource-ui.git

# 2. Create solution file for VS

cd ..
dotnet new sln
proj="$(find ./ | grep "csproj$")"
dotnet sln add $proj


# Wait for key on fin
echo Waiting for key press
read -n 1 -s