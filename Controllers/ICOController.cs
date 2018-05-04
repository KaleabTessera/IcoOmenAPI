using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ICOAppApi.Interfaces;
using ICOAppApi.Model;
using ICOAppApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace ICOAppApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ICOController : Controller
    {
        private readonly InterfaceICORepository _icoRepository;
        static HttpClient client = new HttpClient();
        public ICOController(InterfaceICORepository icoRepository)
        {
            _icoRepository = icoRepository;
        }

        // [NoCache]
        // [HttpGet]
        // public async Task<IEnumerable<ICO>> Get()
        // {
        //     return await _icoRepository.GetAllICOs();
        // }

        // GET api/notes/5
        // [HttpGet("{id}")]
        // public async Task<ICO> Get(string id)
        // {
        //     return await _icoRepository.GetICO(id) ?? new ICO();
        // }

        // POST api/notes
        // [HttpPost]
        // public void Post([FromBody] ICOParam newNote)
        // {
        //     _icoRepository.AddICO(new ICO
        //     {
        //         Id = newNote.Id,
        //         Body = newNote.Body,
        //         CreatedOn = DateTime.Now,
        //         UpdatedOn = DateTime.Now,
        //         UserId = newNote.UserId
        //     });
        // }

        // PUT api/notes/5
        // [HttpPut("{id}")]
        // public void Put(string id, [FromBody]string value)
        // {
        //     _icoRepository.UpdateICODocument(id, value);
        // }

        // DELETE api/notes/23243423
        // [HttpDelete("{id}")]
        // public void Delete(string id)
        // {
        //     _icoRepository.RemoveICO(id);
        // }

        [HttpGet]
        [Route("getFromIcoStats")]
        public async Task<IActionResult> GetICOInfoFromICOStats()
        {
            RootObject icos = null;
            var task = await client.PostAsync("https://icostats.com/graphql", new StringContent("{ \"query\": \"{ icos { id, name, price_usd,price_btc,market_cap_usd, available_supply, total_supply, start_date, eth_price_at_launch,btc_price_at_launch,is_erc20, eth_price_usd,btc_price_usd,amount_sold_in_ico } }\" }"
                , Encoding.UTF8, "application/json"));

            using (HttpContent content = task.Content)
            {
                // var postResponse = content.Result;
                var jsonString = content.ReadAsStringAsync();
                jsonString.Wait();
                icos = JsonConvert.DeserializeObject<RootObject>(jsonString.Result);
            }
            foreach(Ico ico in icos.data.icos){
                await _icoRepository.AddICOStats(ico);
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
                // var postResponse = content.Result;
                var jsonString = content.ReadAsStringAsync();
                jsonString.Wait();
                icos = JsonConvert.DeserializeObject<ICODrops[]>(jsonString.Result);
            }
            foreach(ICODrops ico in icos){
                await _icoRepository.AddICODrops(ico);
            }
            return Ok();

        }

    }

}
