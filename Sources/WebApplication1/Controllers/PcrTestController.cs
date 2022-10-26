using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class PcrTestController : Controller
{
    // GET
    public IActionResult Index()
    {
        var pcrTest1 = new PcrTestViewModel()
        {
            Code = "AB123564",
            SamplingDate = DateTime.Now,
            ReceptionDate = DateTime.Now.AddDays(5),
            AnalysisDate = DateTime.Now.AddDays(6),
            Comment = "commentaire",
            Performer = "Pharmacie A",
            ResultEnum = ResultEnum.Positive
        };
        
        var pcrTest2 = new PcrTestViewModel()
        {
            Code = "AB12354645",
            SamplingDate = DateTime.Now,
            ReceptionDate = DateTime.Now.AddDays(6),
            AnalysisDate = DateTime.Now.AddDays(8),
            Comment = "commentaire",
            Performer = "Pharmacie B",
            ResultEnum = ResultEnum.Negative
        };

        var pcrTests = new List<PcrTestViewModel>();
        pcrTests.Add(pcrTest1);
        pcrTests.Add(pcrTest2);
        
        return View(pcrTests);
    }
}