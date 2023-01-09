using MegaSiteMVC.Data;
using MegaSiteMVC.Data.Services;
using MegaSiteMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MegaSiteMVC.Controllers
{
    public class TableNotesController : Controller
    {
        private readonly ITableNotesService _service;

        public TableNotesController(ITableNotesService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            string jsonSave = _service.ReadJson();
            TableNotes notes = JsonConvert.DeserializeObject<TableNotes>(jsonSave);
            return View(notes);
        }

        [HttpPost]
        public IActionResult Index(TableNotes newNotes)
        {
            string jsonString = JsonConvert.SerializeObject(newNotes);
            _service.WriteJson(jsonString);
            return View(newNotes);
        }
    }
}
