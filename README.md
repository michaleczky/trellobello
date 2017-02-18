# Project 'TrelloBello'

## API

`GET /api/test`

## Tips & Tricks

### Using Trello API

Get an [API key](https://trello.com/app-key) and generate a permanent (never expiring) access token on the same page.

Set the Trello API key and the access token in web.config.

To use the API send the key and the token as query string parameter (GET) or form encoded parameters (POST).

### JSON <-> BSON conversion

jsonData: JObject, bson: BsonDocument

`var bson = BsonSerializer.Deserialize<BsonDocument>(jsonData.ToString());`

`var json = JObject.Parse(bson.ToJson<BsonDocument>());`



