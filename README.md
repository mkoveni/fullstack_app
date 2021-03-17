# Rivalani Simon Hlengani

## .Net 5, Vuejs

This repository demonstrates how to build backend API services using  .NET 5. it also demonstrates how to consume API services from Single Page Application. The project utilizes github actions to build, test and publish the applications as images on dockerhub.

Api demo here [api demo](https://assess.rivalani.dev/swagger)

Client demo here [client demo](https://demo1.rivalani.dev)

## Backend API
The api folder contains the .NET 5 project. this project contains endpoints for:

- Searching Chuck Norris jokes and Star wars characters
- Retrieving Star wars characters
- Retrieving Chuck Norris categories

## Single Page App
Consumes the endpoints provided by the REST API

## REQUIREMENTS

The following is needed to successfully run these projects

- Nodejs
- .NET 5
- Docker


### How to run the project

You can use this repository in one of 2 ways, you can simply download the zipped file and extract it or you can just clone it with the following command (you must have git installed on your system)  

>`https://github.com/mkoveni/fullstack_app.git`  

This will create a fullstack_app directory in your current working directory. navigate into the directory and take a look at the api and client projects.

> `cd fullstack_app && cd backend`  

we will start with the api project first as it contains our data endpoints. the first thing you will do is to install our project dependencies by running **`dotnet restore`**,  once that is done we will run: 

>`dotnet watch run`  


### Now lets head to client project
let's first navigate to the app directory and issue the following command to install all the node dependencies

>`npm install`  

now we can run project by issueing 
> `npm run serve`  

The project will run on http://localhost:8082 , copy and paste the link into your browser and Voilà!

### NB
I have published docker images on dockerhub for both the api and the client. you also run the projects straight from the images

`docker run --rm -p 8080:80 mkoveni/assess_backend` open your browser on http://localhost:8080/swagger

`docker run --rm -p 8081:80 mkoveni/assess_app` open your browser on http://localhost:8081