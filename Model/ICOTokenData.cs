using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Datum
{
    [BsonId]
    public ObjectId InternalId { get; set; }
    //public string _id { get; set; }
    public string name { get; set; }
    public string ticker { get; set; }
    public string symbol { get; set; }
    public string whitepaper { get; set; }
    public string description { get; set; }
    public string status { get; set; }
    public object usd_raised { get; set; }
    public string month { get; set; }
    public object start_date { get; set; }
    public object end_date { get; set; }
    public object current_token_price { get; set; }
    public object token_sale_price { get; set; }
    public object token_return { get; set; }
    public string website { get; set; }
    public string featured_until { get; set; }
    public string etherscan { get; set; }
}

public class ICOTokenData
{
    public List<Datum> data { get; set; }
}