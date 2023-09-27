# FridgeLogger
### Currently OFFLINE due to costs.

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

**All request bodies need to be JSON**

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

Try example requests in Postman:

[![Run in Postman](https://run.pstmn.io/button.svg)](https://god.gw.postman.com/run-collection/23182448-1345c61c-b4ec-4d4c-8cd4-8b0f6b72af69?action=collection%2Ffork&collection-url=entityId%3D23182448-1345c61c-b4ec-4d4c-8cd4-8b0f6b72af69%26entityType%3Dcollection%26workspaceId%3Dc1607ba7-d6ac-4d5c-a739-1ad801e365cb)

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
Try example requests in Postman

[![Run in Postman](https://run.pstmn.io/button.svg)](https://god.gw.postman.com/run-collection/23182448-339a421d-ccce-4ca7-b601-ef0dd4a4d37d?action=collection%2Ffork&collection-url=entityId%3D23182448-339a421d-ccce-4ca7-b601-ef0dd4a4d37d%26entityType%3Dcollection%26workspaceId%3Dc1607ba7-d6ac-4d5c-a739-1ad801e365cb)


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

Try example requests in Postman:

[![Run in Postman](https://run.pstmn.io/button.svg)](https://god.gw.postman.com/run-collection/23182448-090b9b1c-c07c-4d8f-a20c-e6d3f70edcbc?action=collection%2Ffork&collection-url=entityId%3D23182448-090b9b1c-c07c-4d8f-a20c-e6d3f70edcbc%26entityType%3Dcollection%26workspaceId%3Dc1607ba7-d6ac-4d5c-a739-1ad801e365cb)
