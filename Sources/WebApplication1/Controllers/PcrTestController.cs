using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Persistence;

namespace WebApplication1.Controllers;

public class PcrTestController : Controller
{
    // GET
    //public IActionResult Index() (sync case)
    public async Task<IActionResult> Index()
    {
        /*var list = new List<PcrTestListViewModel>();
        foreach (var pcrTest in _pcrTests)
        {
            list.Add(new PcrTestListViewModel()
            {
                Id = pcrTest.Id
            });
        }*/

        //var pcrTestsSync = new PcrContext().PcrTests.ToList();
        var pcrTests = await new PcrContext().PcrTests
            .Include(x => x.Performer) // join User 'Performer' on User.Id = PcrTests.Id 
            //.Where(z => z.Performer.Firstname == "Ludwig")
            .ToListAsync();
        
        return View(pcrTests.Select(x => new PcrTestListViewModel()
        {
            Id = x.Id,
            Performer = $"{x.Performer.Firstname} {x.Performer.Lastname}",
            Code = x.Code,
            Comment = x.Comment,
            CreationDate = x.CreationDate,
            AnalysisDate = x.AnalysisDate,
            ReceptionDate = x.ReceptionDate,
            SamplingDate = x.SamplingDate,
            AnalysisResultEnum = x.AnalysisResultEnum,
        }).ToList());
    }

    public async Task<IActionResult> Edit(int id = -1)
    {
        var model = new PcrTestEditViewModel();

        if (id > 0)
        {
            // query db
            // model.Code = dbResult.Code;
            var match = await new PcrContext().PcrTests.FirstOrDefaultAsync(x => x.Id == id);
            if (match != null)
            {
                model = new PcrTestEditViewModel();
                model.Id = match.Id;
                model.Code = match.Code;
                model.Comment = match.Comment;
                model.PerformerId = match.PerformerId;
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
        
        var users = await new PcrContext().Users.ToListAsync();
        model.SliPerformers = users
            .Select(z => new SelectListItem()
            {
                Text = $"{z.Firstname} {z.Lastname}",
                Value = z.Id.ToString()
            })
            .ToList();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(PcrTestEditViewModel model)
    {
        if (!ModelState.IsValid)
            return RedirectToAction("Index");
        
        var dbContext = new PcrContext();
        PcrTest entityPcrTest = null;

        if (model.Id > 0)
            entityPcrTest = await dbContext.PcrTests.FindAsync(model.Id);
        else
            entityPcrTest = new PcrTest();

        entityPcrTest.Code = model.Code;
        entityPcrTest.AnalysisDate = model.AnalysisDate;
        entityPcrTest.ReceptionDate = model.ReceptionDate;
        entityPcrTest.SamplingDate = model.SamplingDate;
        entityPcrTest.Comment = model.Comment;
        entityPcrTest.AnalysisResultEnum = model.AnalysisResultEnum;
        entityPcrTest.LogisticStatusEnum = model.LogisticStatusEnum;
        entityPcrTest.PerformerId = model.PerformerId;

        if(entityPcrTest.Id <= 0)
            await dbContext.AddAsync(entityPcrTest);
        else
            dbContext.Update(entityPcrTest);
        await dbContext.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Delete(int id = -1)
    {
        if (id > 0)
        {
            var dbContext = new PcrContext();
            // var match = await dbContext.PcrTests.FirstOrDefaultAsync(x => x.Id == id);
            var match = await dbContext.PcrTests.FindAsync(id);
            if (match != null)
            {
                dbContext.Remove(match);
                await dbContext.SaveChangesAsync();
            }
        }
        
        return RedirectToAction("Index");
    }
}