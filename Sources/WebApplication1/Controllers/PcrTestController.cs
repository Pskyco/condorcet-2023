using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class PcrTestController : Controller
{
    private List<PcrTest> _pcrTests = new List<PcrTest>()
    {
        new PcrTest()
        {
            Id = 1,
            Code = "AB123564",
            SamplingDate = DateTime.Now,
            ReceptionDate = DateTime.Now.AddDays(5),
            AnalysisDate = DateTime.Now.AddDays(6),
            Comment = "commentaire",
            PerformerId = 1,
            AnalysisResultEnum = AnalysisResultEnum.Positive,
            LogisticStatusEnum = LogisticStatusEnum.Received
        },
        new PcrTest()
        {
            Id = 2,
            Code = "AB12354645",
            SamplingDate = DateTime.Now,
            ReceptionDate = DateTime.Now.AddDays(6),
            AnalysisDate = DateTime.Now.AddDays(8),
            Comment = "commentaire",
            PerformerId = 2,
            AnalysisResultEnum = AnalysisResultEnum.Negative,
            LogisticStatusEnum = LogisticStatusEnum.Received
        }
    };

    // GET
    public IActionResult Index()
    {
        /*var list = new List<PcrTestListViewModel>();
        foreach (var pcrTest in _pcrTests)
        {
            list.Add(new PcrTestListViewModel()
            {
                Id = pcrTest.Id
            });
        }*/
        
        return View(_pcrTests.Select(x => new PcrTestListViewModel()
        {
            Id = x.Id,
            Performer = $"Performer {x.PerformerId}",
            Code = x.Code,
            Comment = x.Comment,
            AnalysisDate = x.AnalysisDate,
            ReceptionDate = x.ReceptionDate,
            SamplingDate = x.SamplingDate,
            AnalysisResultEnum = x.AnalysisResultEnum,
        }).ToList());
    }

    public IActionResult Edit(int id = -1)
    {
        var model = new PcrTestEditViewModel();

        if (id > 0)
        {
            // query db
            // model.Code = dbResult.Code;
            var match = _pcrTests.FirstOrDefault(x => x.Id == id);
            if (match != null)
            {
                model = new PcrTestEditViewModel();
                model.Id = match.Id;
                model.Code = match.Code;
                model.Comment = match.Comment;
                model.PerformerId = match.PerformerId;
                //model.Performer = match.Performer;
                model.AnalysisDate = match.AnalysisDate;
                model.ReceptionDate = match.ReceptionDate;
                model.AnalysisResultEnum = match.AnalysisResultEnum;
                model.LogisticStatusEnum = match.LogisticStatusEnum;
                model.SamplingDate = match.SamplingDate;
            }
        }
        else
        {
            model.SamplingDate = DateTime.Now;
        }

        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(PcrTestEditViewModel model)
    {
        if(!ModelState.IsValid)
            return RedirectToAction("Index");
        
        Console.WriteLine(JsonConvert.SerializeObject(model, Formatting.Indented));
        // do something with database
        return RedirectToAction("Index");
    }
}