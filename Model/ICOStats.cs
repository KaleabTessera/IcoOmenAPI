using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ICOStats
{
    [BsonId]
    public ObjectId InternalId { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public double price_usd { get; set; }
    public object price_btc { get; set; }
    public object market_cap_usd { get; set; }
    public object available_supply { get; set; }
    public object total_supply { get; set; }
    public DateTime start_date { get; set; }
    public double eth_price_at_launch { get; set; }
    public double btc_price_at_launch { get; set; }
    public bool is_erc20 { get; set; }
    public double eth_price_usd { get; set; }
    public double btc_price_usd { get; set; }
    public double amount_sold_in_ico { get; set; }
}

public class Data
{
    public List<ICOStats> icos { get; set; }
}
public class RootObject
{
    public Data data { get; set; }
}