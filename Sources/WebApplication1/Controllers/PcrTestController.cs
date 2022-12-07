using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Persistence;

namespace WebApplication1.Controllers;

public class PcrTestController : Controller
{
    private readonly PcrContext _pcrContext;
    private readonly IMapper _mapper;

    public PcrTestController(PcrContext pcrContext, IMapper mapper)
    {
        _pcrContext = pcrContext;
        _mapper = mapper;
    }

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

        //var pcrTestsSync = _pcrContext.PcrTests.ToList();
        var pcrTests = await _pcrContext.PcrTests
            .Include(x => x.Performer) // join User 'Performer' on User.Id = PcrTests.Id 
            //.Where(z => z.Performer.Firstname == "Ludwig")
            .ToListAsync();

        /*var dtos = pcrTests.Select(x => new PcrTestListViewModel()
        {
            Performer = $"{x.Performer.Firstname} {x.Performer.Lastname}",
            Id = x.Id,
            Code = x.Code,
            Comment = x.Comment,
            CreationDate = x.CreationDate,
            AnalysisDate = x.AnalysisDate,
            ReceptionDate = x.ReceptionDate,
            SamplingDate = x.SamplingDate,
            AnalysisResultEnum = x.AnalysisResultEnum,
        }).ToList();*/

        //var dtos = pcrTests.Select(x => _mapper.Map<PcrTestListViewModel>(x)).ToList();
        var dtos2 = _mapper.Map<List<PcrTestListViewModel>>(pcrTests);
        /*var dtos3 = new List<PcrTestListViewModel>();
        _mapper.Map(pcrTests, dtos3);*/

        return View(dtos2);
    }

    public async Task<IActionResult> Edit(int id = -1)
    {
        var model = new PcrTestEditViewModel();

        if (id > 0)
        {
            // query db
            // model.Code = dbResult.Code;
            var match = await _pcrContext.PcrTests.FirstOrDefaultAsync(x => x.Id == id);
            if (match != null)
            {
                /*model = new PcrTestEditViewModel();
                model.Id = match.Id;
                model.Code = match.Code;
                model.Comment = match.Comment;
                model.PerformerId = match.PerformerId;
                model.AnalysisDate = match.AnalysisDate;
                model.ReceptionDate = match.ReceptionDate;
                model.AnalysisResultEnum = match.AnalysisResultEnum;
                model.LogisticStatusEnum = match.LogisticStatusEnum;
                model.SamplingDate = match.SamplingDate;*/
                //model = _mapper.Map<PcrTestEditViewModel>(match);
                _mapper.Map(match, model);
            }
        }
        else
        {
            model.SamplingDate = DateTime.Now;
        }

        var users = await _pcrContext.Users.ToListAsync();
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

        PcrTest entityPcrTest = null;

        if (model.Id > 0)
            entityPcrTest = await _pcrContext.PcrTests.FindAsync(model.Id);
        else
            entityPcrTest = new PcrTest();

        _mapper.Map(model, entityPcrTest);

        /*entityPcrTest.Code = model.Code;
        entityPcrTest.AnalysisDate = model.AnalysisDate;
        entityPcrTest.ReceptionDate = model.ReceptionDate;
        entityPcrTest.SamplingDate = model.SamplingDate;
        entityPcrTest.Comment = model.Comment;
        entityPcrTest.AnalysisResultEnum = model.AnalysisResultEnum;
        entityPcrTest.LogisticStatusEnum = model.LogisticStatusEnum;
        entityPcrTest.PerformerId = model.PerformerId;*/

        if (entityPcrTest.Id <= 0)
            await _pcrContext.AddAsync(entityPcrTest);
        else
            _pcrContext.Update(entityPcrTest);
        await _pcrContext.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id = -1)
    {
        if (id > 0)
        {
            var dbContext = _pcrContext;
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