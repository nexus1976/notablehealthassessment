# Notable Health Assessment
## Microservice
---

### Running
This can be composed at this level to get the database and microservice containers up and running, or will automatically be included at the top-level of the entire solution .

To spin up the containers, ensure both Docker and Docker Compose are available and run the following command in the same directory of this README.md: `docker-compose up` .

After complete the running steps, you can point a local browser to http://localhost:5003/swagger/index.html in order to observe the OpenAPI specification page for the microservice.

### Debugging
To start a debugging session for the microservice, you must first have the database container up and running (see the README.md in the .data folder). Open the nh.health.sln in either Visual Studio 2022 or VS Code and initiate a debugging session. The local debugging address will be the same (be careful to not have the docker image running at the same time or else a port collision will occur).