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
using ICOAppApi.Data;

namespace ICOAppApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ICOController : Controller
    {

    }

}
