using Application.Services;
using dp_task_json.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dp_task_json.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileService service;
        private readonly string path = Environment.CurrentDirectory + @"\FileToBeProcessed.json";
        public HomeController(IFileService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string path = Path.Combine(Environment.CurrentDirectory, "FileToBeProcessed.json");

                    using (var stream = System.IO.File.Create(path))
                    {
                        await file.CopyToAsync(stream);
                    }
                    
                    return RedirectToAction("Preview", "Home");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Preview()
        {
            try
            {
                return View(service.ProccessedData(path));
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Upload Failed. {ex}";
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var processedData = service.ProccessedData(path);
            return PhysicalFile(processedData.Download, "application/json", "processed.json");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}