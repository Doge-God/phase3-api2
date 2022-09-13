# phase3-api2: FridgeLogger

This API is meant to be used with food storing IoT devices to collect data on items put in/ taken out.

The data collected is publicly avaliable and anonymous for research purposes.


## Phase3 features
- Onion Architecture 
- EF core usage
- End to end testing with Postman (tested with postman throughout development, demonstrated in presentation)
- Fluent Validation
- ci/cd with GitHub Action, deloyed on Azure

## Usage
Base API URL: https://fridgeloggerapi.azurewebsites.net

### Get all stored data

GET /getAllProdEntries

Example response:
```
[
  {
    "id": 0,
    "name": "string",
    "timeExpire": "2022-09-13T06:14:37.775Z",
    "timeStored": "2022-09-13T06:14:37.775Z",
    "isWasted": true,
    "timeTaken": "2022-09-13T06:14:37.775Z"
  }
]
```

### Log a new item that has been put into storage

POST /addProdEntryStore

Example request body:
```
{
  "name": "string",
  "timeExpire": "2022-09-13T06:14:37.766Z"
}
```
Note: expiry date has to be in date time format

Respond with information on the item you've just stored.

NOTE: keep id stored locally to locate this entry later.

Example response:
```
{
  "id": 0,
  "name": "string",
  "timeExpire": "2022-09-13T06:14:37.776Z",
  "timeStored": "2022-09-13T06:14:37.776Z",
  "isWasted": null,
  "timeTaken": null
}
```

### Log a an item being taken out of storage

PUT /addProdEntryTake

Example request body:
```
{
  "id": 0,
  "isWasted": false
}
```

Respond with information on the item you've just confirmed was taken out of storage.

Example response:
```
{
  "id": 0,
  "name": "string",
  "timeExpire": "2022-09-13T06:14:37.776Z",
  "timeStored": "2022-09-13T06:14:37.776Z",
  "isWasted": false,
  "timeTaken": "2022-09-15T09:20:37.1101"
}
```
