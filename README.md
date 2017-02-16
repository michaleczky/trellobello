# Project 'TrelloBello'

## API

`GET /api/test`

## Tips & Tricks

### JSON <-> BSON conversion

jsonData: JObject, bson: BsonDocument

`var bson = BsonSerializer.Deserialize<BsonDocument>(jsonData.ToString());`

`var json = JObject.Parse(bson.ToJson<BsonDocument>());`



