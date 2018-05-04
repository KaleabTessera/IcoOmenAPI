using System;
using Microsoft.AspNetCore.Mvc;

using ICOAppApi.Interfaces;
using ICOAppApi.Model;

namespace ICOAppApi.Controllers
{
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
        private readonly InterfaceICORepository _noteRepository;

        public SystemController(InterfaceICORepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // Call an initialization - api/system/init
        [HttpGet("{setting}")]
        public string Get(string setting)
        {
            if (setting == "init")
            {
                // _noteRepository.RemoveAllICOs();
                // var name = _noteRepository.CreateIndex();

                // _noteRepository.AddICO(new ICO() { Id = "1", Body = "Test Ico 1", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UserId = 1 });
                // _noteRepository.AddICO(new ICO() { Id = "2", Body = "Test Ico 2", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UserId = 1 });
                // _noteRepository.AddICO(new ICO() { Id = "3", Body = "Test Ico 3", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UserId = 2 });
                // _noteRepository.AddICO(new ICO() { Id = "4", Body = "Test Ico 4", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UserId = 2 });

                return "Database NotesDb was created, and collection 'Notes' was filled with 4 sample items";
            }

            return "Unknown";
        }
    }
}
