using System;
using Microsoft.AspNetCore.Mvc;

using ICOAppApi.Interfaces;
using ICOAppApi.Model;
using ICOAppApi.Data;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace ICOAppApi.Controllers
{
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
        private readonly ICORepository<ICOStats> _iCOStatsRepository;
        private readonly ICORepository<ICODrops> _iCODropsRepository;
        private readonly ICORepository<Datum> _iCOTokenDataRepository;
        private readonly ICORepository<Hit> _iCOPredictionVSRepository;
        // private readonly ICORepository<ICOMaster> _ICOMasterRepository;
        

        static HttpClient client = new HttpClient();

         public SystemController(ICORepository<ICOStats> iCOStatsRepository,ICORepository<ICODrops> iCODropsRepository, ICORepository<Datum> iCOTokenDataRepository,ICORepository<Hit> iCOPredictionVSRepository)
        {
            _iCOStatsRepository = iCOStatsRepository;
            _iCODropsRepository = iCODropsRepository;
            _iCOTokenDataRepository = iCOTokenDataRepository;
            _iCOPredictionVSRepository = iCOPredictionVSRepository;
        }

        // Call an initialization - api/system/init
        [HttpGet("{setting}")]
        public string Get(string setting)
        {
            if (setting == "init")
            {
                Task icoStats = GetICOInfoFromICOStats();
                Task icoDrops = GetICOInfoFromICODrops();
                Task tokenData = GetICOInfoFromTokenData();
                Task predictionVC = GetICOInfoFromPredictionVC();

                Task.WaitAll(icoStats,icoDrops,tokenData,predictionVC);
                return "Database ICODb was created, and collection ICOStats,ICODrops and TokenData were created";
            }

            return "Unknown";
        }

        [HttpGet]
        [Route("getFromIcoStats")]
        public async Task<IActionResult> GetICOInfoFromICOStats()
        {
            //var IcoStatsRepo = new ICORepository<Ico>; 
            RootObject icos = null;
            var task = await client.PostAsync("https://icostats.com/graphql", new StringContent("{ \"query\": \"{ icos { id, name, price_usd,price_btc,market_cap_usd, available_supply, total_supply, start_date, eth_price_at_launch,btc_price_at_launch,is_erc20, eth_price_usd,btc_price_usd,amount_sold_in_ico } }\" }"
                , Encoding.UTF8, "application/json"));

            using (HttpContent content = task.Content)
            {
                var jsonString = content.ReadAsStringAsync();
                jsonString.Wait();
                icos = JsonConvert.DeserializeObject<RootObject>(jsonString.Result);
            }
            foreach(ICOStats ico in icos.data.icos){
                await _iCOStatsRepository.Insert(ico,"ICOStats",ico.name);
            }
            return Ok();

        }

        [HttpGet]
        [Route("getFromIcoDrops")]
        public async Task<IActionResult> GetICOInfoFromICODrops()
        {
            ICODrops[] icos = null;
            var task = await client.GetAsync("https://icodrops.com/cron.json");

            using (HttpContent content = task.Content)
            {
                var jsonString = content.ReadAsStringAsync();
                jsonString.Wait();
                icos = JsonConvert.DeserializeObject<ICODrops[]>(jsonString.Result);
            }
            foreach(ICODrops ico in icos){
                await _iCODropsRepository.Insert(ico,"ICODrops",ico.name);
            }
            return Ok();

        }

        [HttpGet]
        [Route("getFromIcoTokenData")]
        public async Task<IActionResult> GetICOInfoFromTokenData()
        {
            ICOTokenData icos = null;
            var task = await client.GetAsync("https://www.tokendata.io/icos");

            using (HttpContent content = task.Content)
            {
                var jsonString = content.ReadAsStringAsync();
                jsonString.Wait();
                icos = JsonConvert.DeserializeObject<ICOTokenData>(jsonString.Result);
            }
            foreach(Datum ico in icos.data){
                await _iCOTokenDataRepository.Insert(ico,"ICOTokenData",ico.name);
            }
            return Ok();

        }

        [HttpGet]
        [Route("getFromPredictionVC")]
         public async Task<IActionResult> GetICOInfoFromPredictionVC()
        {
            //var IcoStatsRepo = new ICORepository<Ico>; 
            PredictionVC icos = null;
            var task = await client.PostAsync("https://1br267wpjc-3.algolianet.com/1/indexes/*/queries?x-algolia-agent=Algolia%20for%20AngularJS%203.24.11%3BJS%20Helper%202.24.0&x-algolia-application-id=1BR267WPJC&x-algolia-api-key=92cf0d903128651acc7870a53fce7db7", 
            new StringContent("{\r\n  \"requests\": [\r\n    {\r\n      \"indexName\": \"projects\",\r\n      \"params\": \"query=&hitsPerPage=20000&page=0&tagFilters=\"\r\n    }\r\n  ]\r\n}"
                , Encoding.UTF8, "application/json"));

            using (HttpContent content = task.Content)
            {
                var jsonString = content.ReadAsStringAsync();
                jsonString.Wait();
                icos = JsonConvert.DeserializeObject<PredictionVC>(jsonString.Result);
            }
            foreach(Hit ico in icos.results[0].hits){
                await _iCOPredictionVSRepository.Insert(ico,"PredictionVC",ico.name);// .AddICOStats(ico);
            }
            return Ok();

        }
    }
}
