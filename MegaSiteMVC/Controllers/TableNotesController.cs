using MegaSiteMVC.Data;
using MegaSiteMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MegaSiteMVC.Controllers
{
    public class TableNotesController : Controller
    {
        private readonly AppDbContext _context;

        // GET: TableNotesController
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public string LoadedTableNotes()
        //{
        //    string loadedTable = 
        //    //return list as Json    
        //    return ;
        //}
    }
}
