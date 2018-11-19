# API layer for IcoOmen

## How to run:
### 1. Install Docker and Docker-Compose 
https://docs.docker.com/compose/install/#install-compose
 
### 2. Build and Run Docker-compose
```
docker-compose up
```

### 3. Initialize Database with data from Different locations
```
http://localhost:8080/api/system/init`
```
`You should receive a 200, with a success message`

### 4. View Data in Mongo Db
- Make sure you have a Mongo db client (e.g. Studio3t).
- Connect to mongo using db client - url is localhost:27017. 
- View data in table "ICODb"

### 5. Apply views to aggregate the Data.
