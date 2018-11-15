# API layer for IcoOmen

## How to run:
### 1. Install and Run Mongo
https://docs.mongodb.com/manual/installation/
 
### 2. Update API Config
Change configuration in appsettings.json to match your mongo settings.

### 3. Run API via Docker
- `docker build -t api .`      
- `docker run -d -p 8080:80 --name myapp aspnetapp`

### 4. Initialize Database with data from Different locations
`http://localhost:8080/api/system/init`

### 5. Use Mongo Client to view data
