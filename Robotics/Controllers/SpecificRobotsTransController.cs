using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Robotics.Models;

namespace Robotics.Controllers
{
    public class SpecificRobotsTransController : Controller
    {
        private readonly RoboticsContext _context;

        public SpecificRobotsTransController(RoboticsContext context)
        {
            _context = context;
        }

        // GET: SpecificRobotsTrans
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.SpecificRobotsTrans
                .Include(s => s.LanguageNavigation)
                .Include(s => s.SpecificrobotsNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: SpecificRobotsTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var listspecificrobotsinrelation = _context.SpecificRobotsInRelation.ToList();
            ViewData["listspecificrobotsinrelation"] = listspecificrobotsinrelation;

            ViewData["Languages"] = _context.Languages.ToList();

            ViewData["ContributingFieldsTrans"] = _context.ContributingFieldsTrans.ToList();
            ViewData["ModesOfLocomotionTrans"] = _context.ModesOfLocomotionTrans.ToList();
            ViewData["RoboticsPrinciplesTrans"] = _context.RoboticsPrinciplesTrans.ToList();
            ViewData["BusinessTrans"] = _context.BusinessTrans.ToList();
            ViewData["BranchesTrans"] = _context.BranchesTrans.ToList();
            ViewData["TypesTrans"] = _context.TypesTrans.ToList();
            ViewData["RobotComponentsAndDesignFeaturesTrans"] = _context.RobotComponentsAndDesignFeaturesTrans.ToList();
            ViewData["RoboticsDevelopmentAndDevelopmentToolsTrans"] = _context.RoboticsDevelopmentAndDevelopmentToolsTrans.ToList();
            ViewData["RoboticsCompaniesTrans"] = _context.RoboticsCompaniesTrans.ToList();
            ViewData["RoboticsOrganizationsTrans"] = _context.RoboticsOrganizationsTrans.ToList();
            ViewData["RoboticsCompetitionsTrans"] = _context.RoboticsCompetitionsTrans.ToList();
            ViewData["InfluentialPeopleTrans"] = _context.InfluentialPeopleTrans.ToList();
            ViewData["DegreeOfMaturityTrans"] = _context.DegreeOfMaturityTrans.ToList();
            ViewData["SpecificRobotsTrans"] = _context.SpecificRobotsTrans.ToList();

            List<ContributingFields> SelectedContributingFields = new List<ContributingFields>();
            List<ContributingFields> NotSelectedContributingFields = _context.ContributingFields.ToList();
            foreach (var property in listspecificrobotsinrelation.Where(p => p.Contributingfields != null))
            {
                SelectedContributingFields.Add(property.ContributingfieldsNavigation);
                NotSelectedContributingFields.Remove(property.ContributingfieldsNavigation);
            };
            List<ModesOfLocomotion> SelectedModesOfLocomotion = new List<ModesOfLocomotion>();
            List<ModesOfLocomotion> NotSelectedModesOfLocomotion = _context.ModesOfLocomotion.ToList();
            foreach (var property in listspecificrobotsinrelation.Where(p => p.Modesoflocomotion != null))
            {
                SelectedModesOfLocomotion.Add(property.ModesoflocomotionNavigation);
                NotSelectedModesOfLocomotion.Remove(property.ModesoflocomotionNavigation);
            };
            List<RoboticsPrinciples> SelectedRoboticsPrinciples = new List<RoboticsPrinciples>();
            List<RoboticsPrinciples> NotSelectedRoboticsPrinciples = _context.RoboticsPrinciples.ToList();
            foreach (var property in listspecificrobotsinrelation.Where(p => p.Roboticsprinciples != null))
            {
                SelectedRoboticsPrinciples.Add(property.RoboticsprinciplesNavigation);
                NotSelectedRoboticsPrinciples.Remove(property.RoboticsprinciplesNavigation);
            };
            List<Business> SelectedBusiness = new List<Business>();
            List<Business> NotSelectedBusiness = _context.Business.ToList();
            foreach (var property in listspecificrobotsinrelation.Where(p => p.Business != null))
            {
                SelectedBusiness.Add(property.BusinessNavigation);
                NotSelectedBusiness.Remove(property.BusinessNavigation);
            };
            List<Branches> SelectedBranches = new List<Branches>();
            List<Branches> NotSelectedBranches = _context.Branches.ToList();
            foreach (var property in listspecificrobotsinrelation.Where(p => p.Branches != null))
            {
                SelectedBranches.Add(property.BranchesNavigation);
                NotSelectedBranches.Remove(property.BranchesNavigation);
            };
            List<Types> SelectedTypes = new List<Types>();
            List<Types> NotSelectedTypes = _context.Types.ToList();
            foreach (var property in listspecificrobotsinrelation.Where(p => p.Types != null))
            {
                SelectedTypes.Add(property.TypesNavigation);
                NotSelectedTypes.Remove(property.TypesNavigation);
            };
            List<RobotComponentsAndDesignFeatures> SelectedRobotComponentsAndDesignFeatures = new List<RobotComponentsAndDesignFeatures>();
            List<RobotComponentsAndDesignFeatures> NotSelectedRobotComponentsAndDesignFeatures = _context.RobotComponentsAndDesignFeatures.ToList();
            foreach (var property in listspecificrobotsinrelation.Where(p => p.Robotcomponentsanddesignfeatures != null))
            {
                SelectedRobotComponentsAndDesignFeatures.Add(property.RobotcomponentsanddesignfeaturesNavigation);
                NotSelectedRobotComponentsAndDesignFeatures.Remove(property.RobotcomponentsanddesignfeaturesNavigation);
            };
            List<RoboticsDevelopmentAndDevelopmentTools> SelectedRoboticsDevelopmentAndDevelopmentTools = new List<RoboticsDevelopmentAndDevelopmentTools>();
            List<RoboticsDevelopmentAndDevelopmentTools> NotSelectedRoboticsDevelopmentAndDevelopmentTools = _context.RoboticsDevelopmentAndDevelopmentTools.ToList();
            foreach (var property in listspecificrobotsinrelation.Where(p => p.Roboticsdevelopmentanddevelopmenttools != null))
            {
                SelectedRoboticsDevelopmentAndDevelopmentTools.Add(property.RoboticsdevelopmentanddevelopmenttoolsNavigation);
                NotSelectedRoboticsDevelopmentAndDevelopmentTools.Remove(property.RoboticsdevelopmentanddevelopmenttoolsNavigation);
            };
            List<RoboticsCompanies> SelectedRoboticsCompanies = new List<RoboticsCompanies>();
            List<RoboticsCompanies> NotSelectedRoboticsCompanies = _context.RoboticsCompanies.ToList();
            foreach (var property in listspecificrobotsinrelation.Where(p => p.Roboticscompanies != null))
            {
                SelectedRoboticsCompanies.Add(property.RoboticscompaniesNavigation);
                NotSelectedRoboticsCompanies.Remove(property.RoboticscompaniesNavigation);
            };
            List<RoboticsOrganizations> SelectedRoboticsOrganizations = new List<RoboticsOrganizations>();
            List<RoboticsOrganizations> NotSelectedRoboticsOrganizations = _context.RoboticsOrganizations.ToList();
            foreach (var property in listspecificrobotsinrelation.Where(p => p.Roboticsorganizations != null))
            {
                SelectedRoboticsOrganizations.Add(property.RoboticsorganizationsNavigation);
                NotSelectedRoboticsOrganizations.Remove(property.RoboticsorganizationsNavigation);
            };
            List<RoboticsCompetitions> SelectedRoboticsCompetitions = new List<RoboticsCompetitions>();
            List<RoboticsCompetitions> NotSelectedRoboticsCompetitions = _context.RoboticsCompetitions.ToList();
            foreach (var property in listspecificrobotsinrelation.Where(p => p.Roboticscompetitions != null))
            {
                SelectedRoboticsCompetitions.Add(property.RoboticscompetitionsNavigation);
                NotSelectedRoboticsCompetitions.Remove(property.RoboticscompetitionsNavigation);
            };
            List<InfluentialPeople> SelectedInfluentialPeople = new List<InfluentialPeople>();
            List<InfluentialPeople> NotSelectedInfluentialPeople = _context.InfluentialPeople.ToList();
            foreach (var property in listspecificrobotsinrelation.Where(p => p.Influentialpeople != null))
            {
                SelectedInfluentialPeople.Add(property.InfluentialpeopleNavigation);
                NotSelectedInfluentialPeople.Remove(property.InfluentialpeopleNavigation);
            };
            List<DegreeOfMaturity> SelectedDegreeOfMaturity = new List<DegreeOfMaturity>();
            List<DegreeOfMaturity> NotSelectedDegreeOfMaturity = _context.DegreeOfMaturity.ToList();
            foreach (var property in listspecificrobotsinrelation.Where(p => p.Degreeofmaturity != null))
            {
                SelectedDegreeOfMaturity.Add(property.DegreeofmaturityNavigation);
                NotSelectedDegreeOfMaturity.Remove(property.DegreeofmaturityNavigation);
            };
            ViewData["SelectedContributingFields"] = SelectedContributingFields;
            ViewData["NotSelectedContributingFields"] = NotSelectedContributingFields;
            ViewData["SelectedModesOfLocomotion"] = SelectedModesOfLocomotion;
            ViewData["NotSelectedModesOfLocomotion"] = NotSelectedModesOfLocomotion;
            ViewData["SelectedRoboticsPrinciples"] = SelectedRoboticsPrinciples;
            ViewData["NotSelectedRoboticsPrinciples"] = NotSelectedRoboticsPrinciples;
            ViewData["SelectedBusiness"] = SelectedBusiness;
            ViewData["NotSelectedBusiness"] = NotSelectedBusiness;
            ViewData["SelectedBranches"] = SelectedBranches;
            ViewData["NotSelectedBranches"] = NotSelectedBranches;
            ViewData["SelectedTypes"] = SelectedTypes;
            ViewData["NotSelectedTypes"] = NotSelectedTypes;
            ViewData["SelectedRobotComponentsAndDesignFeatures"] = SelectedRobotComponentsAndDesignFeatures;
            ViewData["NotSelectedRobotComponentsAndDesignFeatures"] = NotSelectedRobotComponentsAndDesignFeatures;
            ViewData["SelectedRoboticsDevelopmentAndDevelopmentTools"] = SelectedRoboticsDevelopmentAndDevelopmentTools;
            ViewData["NotSelectedRoboticsDevelopmentAndDevelopmentTools"] = NotSelectedRoboticsDevelopmentAndDevelopmentTools;
            ViewData["SelectedRoboticsCompanies"] = SelectedRoboticsCompanies;
            ViewData["NotSelectedRoboticsCompanies"] = NotSelectedRoboticsCompanies;
            ViewData["SelectedRoboticsOrganizations"] = SelectedRoboticsOrganizations;
            ViewData["NotSelectedRoboticsOrganizations"] = NotSelectedRoboticsOrganizations;
            ViewData["SelectedRoboticsCompetitions"] = SelectedRoboticsCompetitions;
            ViewData["NotSelectedRoboticsCompetitions"] = NotSelectedRoboticsCompetitions;
            ViewData["SelectedInfluentialPeople"] = SelectedInfluentialPeople;
            ViewData["NotSelectedInfluentialPeople"] = NotSelectedInfluentialPeople;
            ViewData["SelectedDegreeOfMaturity"] = SelectedDegreeOfMaturity;
            ViewData["NotSelectedDegreeOfMaturity"] = NotSelectedDegreeOfMaturity;


            ViewData["InfoSourcesInRelation"] =_context.InfoSourcesInRelation.ToList();
            ViewData["InfoTypes"] = _context.InfoTypes.ToList();
            ViewData["Websites"] = _context.Websites.ToList();
            ViewData["Books"] = _context.Books.ToList();
            ViewData["Journals"] = _context.Journals.ToList();
            ViewData["Series"] = _context.Series.ToList();
            ViewData["Collections"] = _context.Collections.ToList();
            ViewData["Unpublished"] = _context.Unpublished.ToList();
            ViewData["OfficialStatements"] = _context.OfficialStatements.ToList();
            ViewData["Newspapers"] = _context.Newspapers.ToList();

            if (id == null)
            {
                return NotFound();
            }

            var specificRobotsTrans = await _context.SpecificRobotsTrans
                .Include(s => s.LanguageNavigation)
                .Include(s => s.SpecificrobotsNavigation) //.ThenInclude(sr => sr.SpecificRobotsInRelation).ThenInclude(srr => srr.Branches)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (specificRobotsTrans == null)
            {
                return NotFound();
            }
            ViewData["Specificrobots"] = specificRobotsTrans.Specificrobots;

            return View(specificRobotsTrans);
        }

        // GET: SpecificRobotsTrans/Create
        public IActionResult Create(int specificrobots)
        {
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            SpecificRobotsTrans specificrobotstrans = new SpecificRobotsTrans();
            specificrobotstrans.Specificrobots = specificrobots;
              ViewData["Specificrobots"] = specificrobots;
            return View(specificrobotstrans);
        }

        public IActionResult CreateTranslation(int specificrobots)
        {
           return RedirectToAction("Create", "SpecificRobotsTrans", new { specificrobots = specificrobots });
        }



        // POST: SpecificRobotsTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int SpecificRobots, [Bind("Id,Name,Description,Specificrobots,Language")] SpecificRobotsTrans specificRobotsTrans)
        {
            if (ModelState.IsValid)
            {
                if (SpecificRobots == 0) { SpecificRobots entry = new SpecificRobots(); _context.Add(entry); specificRobotsTrans.Specificrobots = entry.Id; }

                _context.Add(specificRobotsTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", specificRobotsTrans.Language);
            ViewData["Specificrobots"] = new SelectList(_context.SpecificRobots, "Id", "Id", specificRobotsTrans.Specificrobots);
            return View(specificRobotsTrans);
        }

        // GET: SpecificRobotsTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificRobotsTrans = await _context.SpecificRobotsTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (specificRobotsTrans == null)
            {
                return NotFound();
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", specificRobotsTrans.Language);
            ViewData["Specificrobots"] = new SelectList(_context.SpecificRobots, "Id", "Id", specificRobotsTrans.Specificrobots);
            return View(specificRobotsTrans);
        }

        // POST: SpecificRobotsTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Specificrobots,Language")] SpecificRobotsTrans specificRobotsTrans)
        {
            if (id != specificRobotsTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specificRobotsTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecificRobotsTransExists(specificRobotsTrans.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", specificRobotsTrans.Language);
            ViewData["Specificrobots"] = new SelectList(_context.SpecificRobots, "Id", "Id", specificRobotsTrans.Specificrobots);
            return View(specificRobotsTrans);
        }

        // GET: SpecificRobotsTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificRobotsTrans = await _context.SpecificRobotsTrans
                .Include(s => s.LanguageNavigation)
                .Include(s => s.SpecificrobotsNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (specificRobotsTrans == null)
            {
                return NotFound();
            }

            return View(specificRobotsTrans);
        }

        // POST: SpecificRobotsTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specificRobotsTrans = await _context.SpecificRobotsTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.SpecificRobotsTrans.Remove(specificRobotsTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SpecificRobotsTransExists(int id)
        {
            return _context.SpecificRobotsTrans.Any(e => e.Id == id);
        }
    }
}
