using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Numerics;
public class Category
{
    public string naicsCode { get; set; }
    public string sicCode { get; set; }
    public string subIndustry { get; set; }
    public string industry { get; set; }
    public string industryGroup { get; set; }
    public string sector { get; set; }
}

public class Facebook
{
    public int? likes { get; set; }
    public string handle { get; set; }
}

public class Geo
{
    public double? lng { get; set; }
    public double? lat { get; set; }
    public string countryCode { get; set; }
    public string country { get; set; }
    public string stateCode { get; set; }
    public string state { get; set; }
    public string postalCode { get; set; }
    public string city { get; set; }
    public string subPremise { get; set; }
    public string streetName { get; set; }
    public string streetNumber { get; set; }
}

public class Metrics
{
    public int? fiscalYearEnd { get; set; }
    public string estimatedAnnualRevenue { get; set; }
    public long? annualRevenue { get; set; }
    public int? raised { get; set; }
    public long? marketCap { get; set; }
    public string employeesRange { get; set; }
    public int? employees { get; set; }
    public int? alexaGlobalRank { get; set; }
    public int? alexaUsRank { get; set; }
}

public class Twitter
{
    public string avatar { get; set; }
    public string site { get; set; }
    public string location { get; set; }
    public int? following { get; set; }
    public int? followers { get; set; }
    public string bio { get; set; }
    public string id { get; set; }
    public string handle { get; set; }
}

public class Crunchbase
{
    public string handle { get; set; }
}

public class Linkedin
{
    public string handle { get; set; }
}

public class Scores
{
    public double valuation { get; set; }
    public double social { get; set; }
    public double transparancy { get; set; }
}

public class MonthMarket
{
    public List<object> price { get; set; }
    public List<object> volume { get; set; }
}

public class WeekMarket
{
    public List<object> price { get; set; }
    public List<object> volume { get; set; }
}

public class FourteenDay
{
    public double? change { get; set; }
    public object predictionStats { get; set; }
    public double prediction { get; set; }
}

public class SevenDay
{
    public double? change { get; set; }
    public object predictionStats { get; set; }
    public double prediction { get; set; }
}

public class Predictions
{
    public FourteenDay fourteenDay { get; set; }
    public SevenDay sevenDay { get; set; }
}

public class LinkedFile
{
    public string _id { get; set; }
    public string link { get; set; }
    public string fileName { get; set; }
    public string fileId { get; set; }
}

public class Description
{
    public string value { get; set; }
    public string matchLevel { get; set; }
    public List<object> matchedWords { get; set; }
}

public class Symbol
{
    public string value { get; set; }
    public string matchLevel { get; set; }
    public List<object> matchedWords { get; set; }
}

public class Name
{
    public string value { get; set; }
    public string matchLevel { get; set; }
    public List<object> matchedWords { get; set; }
}

public class HighlightResult
{
    public Description description { get; set; }
    public Symbol symbol { get; set; }
    public Name name { get; set; }
}

public class User
{
    public string id { get; set; }
    public string authkey { get; set; }
}

public class Hit
{
    [BsonId]
    public ObjectId InternalId { get; set; }
    public object _reddit { get; set; }
    //public string _id { get; set; }
    public DateTime timeStamp { get; set; }
    public string imageUrl { get; set; }
    public int views { get; set; }
    public string whitepaperUrl { get; set; }
    public string websiteUrl { get; set; }
    public int status { get; set; }
    public string creator { get; set; }
    public string description { get; set; }
    public string category { get; set; }
    public string blockchain { get; set; }
    public string twitterUrl { get; set; }
    public string redditUrl { get; set; }
    public string githubUrl { get; set; }
    public string symbol { get; set; }
    public string email { get; set; }
    public string name { get; set; }
    public int __v { get; set; }
    public double totalScore { get; set; }
    public Category _category { get; set; }
    public List<object> _emailaddresses { get; set; }
    public Facebook _facebook { get; set; }
    public Geo _geo { get; set; }
    public Metrics _metrics { get; set; }
    public object _tags { get; set; }
    public List<object> _tech { get; set; }
    public Twitter _twitter { get; set; }
    public Crunchbase _crunchbase { get; set; }
    public Linkedin _linkedin { get; set; }
    public object market { get; set; }
    public double btcPrice { get; set; }
    public double? change { get; set; }
    public object marketcap { get; set; }
    public double usdPrice { get; set; }
    public object volume { get; set; }
    public Scores scores { get; set; }
    public double forecast14Day { get; set; }
    public double forecast7Day { get; set; }
    public object dayMarket { get; set; }
    public MonthMarket monthMarket { get; set; }
    public object quarterMarket { get; set; }
    public WeekMarket weekMarket { get; set; }
    public object yearMarket { get; set; }
    public object _github { get; set; }
    public Predictions predictions { get; set; }
    public DateTime lastUpdated { get; set; }
    public List<LinkedFile> linkedFiles { get; set; }
    public object ratings { get; set; }
    public object exchanges { get; set; }
    public object news { get; set; }
    public List<object> team { get; set; }
    public List<object> verifiedTeam { get; set; }
    public List<object> price7Day { get; set; }
    public List<object> volume7Day { get; set; }
    public string objectID { get; set; }
    public HighlightResult _highlightResult { get; set; }
    public string slackUrl { get; set; }
    public User user { get; set; }
    public double? icoRaisedAmount { get; set; }
    public long? tokensIco { get; set; }
    public BigInteger? tokensIssues { get; set; }
    public double? icoPriceUSD { get; set; }
    public string icoStartDate { get; set; }
    public string keywords { get; set; }
    public string telegramUrl { get; set; }
    public string youtubeUrl { get; set; }
    public string teamMembers { get; set; }
    public string _foundedYear { get; set; }
    public string _legalName { get; set; }
    public string events { get; set; }
    public string facebookUrl { get; set; }
    public string icoEndDate { get; set; }
    public string slug { get; set; }
    public string mediumUrl { get; set; }
    public string releaseDate { get; set; }
    public string projectFeatures { get; set; }
    public string acceptedCurrencies { get; set; }
}

public class Result
{
    public List<Hit> hits { get; set; }
    public int nbHits { get; set; }
    public int page { get; set; }
    public int nbPages { get; set; }
    public int hitsPerPage { get; set; }
    public int processingTimeMS { get; set; }
    public bool exhaustiveNbHits { get; set; }
    public string query { get; set; }
    public string @params { get; set; }
    public string index { get; set; }
}

public class PredictionVC
{
    public List<Result> results { get; set; }
}