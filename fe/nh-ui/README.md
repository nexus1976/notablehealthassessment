# Notable Health Assessment
## Micro Frontend
---

This can be composed at this level to get the frontend container up and running, or will automatically be included at the top-level of the entire solution .

To spin up the container, ensure both Docker and Docker Compose are available and run the following command in the same directory of this README.md: `docker-compose up` .

The micro frontend can be navigated to by opening a browser to http://localhost:8089 . Note that without the complete backend runnng in some way (either through Docker or directly running in debug mode), the frontend calls to it will fail.