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
    public class SpecificRobotsInRelationsController : Controller
    {
        private readonly RoboticsContext _context;

        public SpecificRobotsInRelationsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: SpecificRobotsInRelations
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.SpecificRobotsInRelation
                .Include(s => s.ContributingfieldsNavigation).Include(s => s.DegreeofmaturityNavigation).Include(s => s.BranchesNavigation).Include(s => s.BusinessNavigation).Include(s => s.InfluentialpeopleNavigation).Include(s => s.ModesoflocomotionNavigation).Include(s => s.RobotcomponentsanddesignfeaturesNavigation).Include(s => s.RoboticscompaniesNavigation).Include(s => s.RoboticscompetitionsNavigation).Include(s => s.RoboticsdevelopmentanddevelopmenttoolsNavigation).Include(s => s.RoboticsorganizationsNavigation).Include(s => s.RoboticsprinciplesNavigation).Include(s => s.SpecificrobotsNavigation).Include(s => s.TypesNavigation)
                ;
            return View(await roboticsContext.ToListAsync());
        }
        public async Task<IActionResult> IndexSpecificRobot(int specificrobot)
        {
            var roboticsContext = _context.SpecificRobotsInRelation.Include(s => s.ContributingfieldsNavigation).Include(s => s.DegreeofmaturityNavigation).Include(s => s.BranchesNavigation).Include(s => s.BusinessNavigation).Include(s => s.InfluentialpeopleNavigation).Include(s => s.ModesoflocomotionNavigation).Include(s => s.RobotcomponentsanddesignfeaturesNavigation).Include(s => s.RoboticscompaniesNavigation).Include(s => s.RoboticscompetitionsNavigation).Include(s => s.RoboticsdevelopmentanddevelopmenttoolsNavigation).Include(s => s.RoboticsorganizationsNavigation).Include(s => s.RoboticsprinciplesNavigation).Include(s => s.SpecificrobotsNavigation).Include(s => s.TypesNavigation);
            return View(await roboticsContext.ToListAsync());
        }


        // GET: SpecificRobotsInRelations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificRobotsInRelation = await _context.SpecificRobotsInRelation
                .Include(s => s.ContributingfieldsNavigation) 
                .Include(s => s.DegreeofmaturityNavigation)
                .Include(s => s.BranchesNavigation)
                .Include(s => s.BusinessNavigation)
                .Include(s => s.InfluentialpeopleNavigation)
                .Include(s => s.ModesoflocomotionNavigation)
                .Include(s => s.RobotcomponentsanddesignfeaturesNavigation)
                .Include(s => s.RoboticscompaniesNavigation)
                .Include(s => s.RoboticscompetitionsNavigation)
                .Include(s => s.RoboticsdevelopmentanddevelopmenttoolsNavigation)
                .Include(s => s.RoboticsorganizationsNavigation)
                .Include(s => s.RoboticsprinciplesNavigation)
                .Include(s => s.SpecificrobotsNavigation)
                .Include(s => s.TypesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (specificRobotsInRelation == null)
            {
                return NotFound();
            }

            return View(specificRobotsInRelation);
        }



        // GET: SpecificRobotsInRelations/Manage
        public IActionResult Manage(int specificrobots)
        {
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFieldsTrans.Where(cf => cf.Language.Equals(1)), "Contributingfields", "Name");

           // ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id");
            ViewData["Degreeofmaturity"] = new SelectList(_context.DegreeOfMaturity, "Id", "Id");
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id");
            ViewData["Business"] = new SelectList(_context.Business, "Id", "Id");
            ViewData["Influentialpeople"] = new SelectList(_context.InfluentialPeople, "Id", "Id");
            ViewData["Modesoflocomotion"] = new SelectList(_context.ModesOfLocomotion, "Id", "Id");
            ViewData["Robotcomponentsanddesignfeatures"] = new SelectList(_context.RobotComponentsAndDesignFeatures, "Id", "Id");
            ViewData["Roboticscompanies"] = new SelectList(_context.RoboticsCompanies, "Id", "Id");
            ViewData["Roboticscompetitions"] = new SelectList(_context.RoboticsCompetitions, "Id", "Id");
            ViewData["Roboticsdevelopmentanddevelopmenttools"] = new SelectList(_context.RoboticsDevelopmentAndDevelopmentTools, "Id", "Id");
            ViewData["Roboticsorganizations"] = new SelectList(_context.RoboticsOrganizations, "Id", "Id");
            ViewData["Roboticsprinciples"] = new SelectList(_context.RoboticsPrinciples, "Id", "Id");
            ViewData["Specificrobots"] = new SelectList(_context.SpecificRobots, "Id", "Id");
            ViewData["Types"] = new SelectList(_context.Types, "Id", "Id");
            ViewData["Specificrobot"] = specificrobots;
            ViewData["Specificrobotsinrelation"] = _context.SpecificRobotsInRelation.Where(SR => SR.Specificrobots.Equals(specificrobots)).Include(s => s.ContributingfieldsNavigation).ThenInclude(cf => cf.ContributingFieldsTrans).Include(s => s.DegreeofmaturityNavigation).Include(s => s.BranchesNavigation).Include(s => s.BusinessNavigation).Include(s => s.InfluentialpeopleNavigation).Include(s => s.ModesoflocomotionNavigation).Include(s => s.RobotcomponentsanddesignfeaturesNavigation).Include(s => s.RoboticscompaniesNavigation).Include(s => s.RoboticscompetitionsNavigation).Include(s => s.RoboticsdevelopmentanddevelopmenttoolsNavigation).Include(s => s.RoboticsorganizationsNavigation).Include(s => s.RoboticsprinciplesNavigation).Include(s => s.SpecificrobotsNavigation).Include(s => s.TypesNavigation).ToList();


            SpecificRobotsInRelation specificrobotsinrelation = new SpecificRobotsInRelation();
            specificrobotsinrelation.Specificrobots = specificrobots;
            return View(specificrobotsinrelation);
            
        }
        // GET: SpecificRobotsInRelations/Create
        public IActionResult Create(int specificrobots)
        {
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id");
            ViewData["Degreeofmaturity"] = new SelectList(_context.DegreeOfMaturity, "Id", "Id");
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id");
            ViewData["Business"] = new SelectList(_context.Business, "Id", "Id");
            ViewData["Influentialpeople"] = new SelectList(_context.InfluentialPeople, "Id", "Id");
            ViewData["Modesoflocomotion"] = new SelectList(_context.ModesOfLocomotion, "Id", "Id");
            ViewData["Robotcomponentsanddesignfeatures"] = new SelectList(_context.RobotComponentsAndDesignFeatures, "Id", "Id");
            ViewData["Roboticscompanies"] = new SelectList(_context.RoboticsCompanies, "Id", "Id");
            ViewData["Roboticscompetitions"] = new SelectList(_context.RoboticsCompetitions, "Id", "Id");
            ViewData["Roboticsdevelopmentanddevelopmenttools"] = new SelectList(_context.RoboticsDevelopmentAndDevelopmentTools, "Id", "Id");
            ViewData["Roboticsorganizations"] = new SelectList(_context.RoboticsOrganizations, "Id", "Id");
            ViewData["Roboticsprinciples"] = new SelectList(_context.RoboticsPrinciples, "Id", "Id");
            ViewData["Specificrobots"] = new SelectList(_context.SpecificRobots, "Id", "Id");
            ViewData["Types"] = new SelectList(_context.Types, "Id", "Id");


            SpecificRobotsInRelation specificrobotsinrelation = new SpecificRobotsInRelation();
            specificrobotsinrelation.Specificrobots = specificrobots;

            return View(specificrobotsinrelation);
        }

        // POST: SpecificRobotsInRelations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Specificrobots,Modesoflocomotion,Roboticsprinciples,Branches,Business,Contributingfields,Types,Robotcomponentsanddesignfeatures,Roboticsdevelopmentanddevelopmenttools,Roboticscompanies,Roboticsorganizations,Roboticscompetitions,Influentialpeople,Degreeofmaturity")] SpecificRobotsInRelation specificRobotsInRelation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specificRobotsInRelation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id", specificRobotsInRelation.Contributingfields);
            ViewData["Degreeofmaturity"] = new SelectList(_context.DegreeOfMaturity, "Id", "Id", specificRobotsInRelation.Degreeofmaturity);
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id", specificRobotsInRelation.Branches);
            ViewData["Business"] = new SelectList(_context.Business, "Id", "Id", specificRobotsInRelation.Business);
            ViewData["Influentialpeople"] = new SelectList(_context.InfluentialPeople, "Id", "Id", specificRobotsInRelation.Influentialpeople);
            ViewData["Modesoflocomotion"] = new SelectList(_context.ModesOfLocomotion, "Id", "Id", specificRobotsInRelation.Modesoflocomotion);
            ViewData["Robotcomponentsanddesignfeatures"] = new SelectList(_context.RobotComponentsAndDesignFeatures, "Id", "Id", specificRobotsInRelation.Robotcomponentsanddesignfeatures);
            ViewData["Roboticscompanies"] = new SelectList(_context.RoboticsCompanies, "Id", "Id", specificRobotsInRelation.Roboticscompanies);
            ViewData["Roboticscompetitions"] = new SelectList(_context.RoboticsCompetitions, "Id", "Id", specificRobotsInRelation.Roboticscompetitions);
            ViewData["Roboticsdevelopmentanddevelopmenttools"] = new SelectList(_context.RoboticsDevelopmentAndDevelopmentTools, "Id", "Id", specificRobotsInRelation.Roboticsdevelopmentanddevelopmenttools);
            ViewData["Roboticsorganizations"] = new SelectList(_context.RoboticsOrganizations, "Id", "Id", specificRobotsInRelation.Roboticsorganizations);
            ViewData["Roboticsprinciples"] = new SelectList(_context.RoboticsPrinciples, "Id", "Id", specificRobotsInRelation.Roboticsprinciples);
            ViewData["Specificrobots"] = new SelectList(_context.SpecificRobots, "Id", "Id", specificRobotsInRelation.Specificrobots);
            ViewData["Types"] = new SelectList(_context.Types, "Id", "Id", specificRobotsInRelation.Types);
            return View(specificRobotsInRelation);
        }

        // GET: SpecificRobotsInRelations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificRobotsInRelation = await _context.SpecificRobotsInRelation.SingleOrDefaultAsync(m => m.Id == id);
            if (specificRobotsInRelation == null)
            {
                return NotFound();
            }
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id", specificRobotsInRelation.Contributingfields);
            ViewData["Degreeofmaturity"] = new SelectList(_context.DegreeOfMaturity, "Id", "Id", specificRobotsInRelation.Degreeofmaturity);
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id", specificRobotsInRelation.Branches);
            ViewData["Business"] = new SelectList(_context.Business, "Id", "Id", specificRobotsInRelation.Business);

            ViewData["Influentialpeople"] = new SelectList(_context.InfluentialPeople, "Id", "Id", specificRobotsInRelation.Influentialpeople);
            ViewData["Modesoflocomotion"] = new SelectList(_context.ModesOfLocomotion, "Id", "Id", specificRobotsInRelation.Modesoflocomotion);
            ViewData["Robotcomponentsanddesignfeatures"] = new SelectList(_context.RobotComponentsAndDesignFeatures, "Id", "Id", specificRobotsInRelation.Robotcomponentsanddesignfeatures);
            ViewData["Roboticscompanies"] = new SelectList(_context.RoboticsCompanies, "Id", "Id", specificRobotsInRelation.Roboticscompanies);
            ViewData["Roboticscompetitions"] = new SelectList(_context.RoboticsCompetitions, "Id", "Id", specificRobotsInRelation.Roboticscompetitions);
            ViewData["Roboticsdevelopmentanddevelopmenttools"] = new SelectList(_context.RoboticsDevelopmentAndDevelopmentTools, "Id", "Id", specificRobotsInRelation.Roboticsdevelopmentanddevelopmenttools);
            ViewData["Roboticsorganizations"] = new SelectList(_context.RoboticsOrganizations, "Id", "Id", specificRobotsInRelation.Roboticsorganizations);
            ViewData["Roboticsprinciples"] = new SelectList(_context.RoboticsPrinciples, "Id", "Id", specificRobotsInRelation.Roboticsprinciples);
            ViewData["Specificrobots"] = new SelectList(_context.SpecificRobots, "Id", "Id", specificRobotsInRelation.Specificrobots);
            ViewData["Types"] = new SelectList(_context.Types, "Id", "Id", specificRobotsInRelation.Types);
            return View(specificRobotsInRelation);
        }

        // POST: SpecificRobotsInRelations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Specificrobots,Modesoflocomotion,Roboticsprinciples,Branches,Business,Contributingfields,Types,Robotcomponentsanddesignfeatures,Roboticsdevelopmentanddevelopmenttools,Roboticscompanies,Roboticsorganizations,Roboticscompetitions,Influentialpeople,Degreeofmaturity")] SpecificRobotsInRelation specificRobotsInRelation)
        {
            if (id != specificRobotsInRelation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specificRobotsInRelation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecificRobotsInRelationExists(specificRobotsInRelation.Id))
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
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id", specificRobotsInRelation.Contributingfields);
            ViewData["Degreeofmaturity"] = new SelectList(_context.DegreeOfMaturity, "Id", "Id", specificRobotsInRelation.Degreeofmaturity);
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id", specificRobotsInRelation.Branches);
            ViewData["Business"] = new SelectList(_context.Business, "Id", "Id", specificRobotsInRelation.Business);

            ViewData["Influentialpeople"] = new SelectList(_context.InfluentialPeople, "Id", "Id", specificRobotsInRelation.Influentialpeople);
            ViewData["Modesoflocomotion"] = new SelectList(_context.ModesOfLocomotion, "Id", "Id", specificRobotsInRelation.Modesoflocomotion);
            ViewData["Robotcomponentsanddesignfeatures"] = new SelectList(_context.RobotComponentsAndDesignFeatures, "Id", "Id", specificRobotsInRelation.Robotcomponentsanddesignfeatures);
            ViewData["Roboticscompanies"] = new SelectList(_context.RoboticsCompanies, "Id", "Id", specificRobotsInRelation.Roboticscompanies);
            ViewData["Roboticscompetitions"] = new SelectList(_context.RoboticsCompetitions, "Id", "Id", specificRobotsInRelation.Roboticscompetitions);
            ViewData["Roboticsdevelopmentanddevelopmenttools"] = new SelectList(_context.RoboticsDevelopmentAndDevelopmentTools, "Id", "Id", specificRobotsInRelation.Roboticsdevelopmentanddevelopmenttools);
            ViewData["Roboticsorganizations"] = new SelectList(_context.RoboticsOrganizations, "Id", "Id", specificRobotsInRelation.Roboticsorganizations);
            ViewData["Roboticsprinciples"] = new SelectList(_context.RoboticsPrinciples, "Id", "Id", specificRobotsInRelation.Roboticsprinciples);
            ViewData["Specificrobots"] = new SelectList(_context.SpecificRobots, "Id", "Id", specificRobotsInRelation.Specificrobots);
            ViewData["Types"] = new SelectList(_context.Types, "Id", "Id", specificRobotsInRelation.Types);
            return View(specificRobotsInRelation);
        }

        // GET: SpecificRobotsInRelations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificRobotsInRelation = await _context.SpecificRobotsInRelation
                .Include(s => s.ContributingfieldsNavigation)
                .Include(s => s.DegreeofmaturityNavigation)
                .Include(s => s.BranchesNavigation)
                .Include(s => s.BusinessNavigation)

                .Include(s => s.InfluentialpeopleNavigation)
                .Include(s => s.ModesoflocomotionNavigation)
                .Include(s => s.RobotcomponentsanddesignfeaturesNavigation)
                .Include(s => s.RoboticscompaniesNavigation)
                .Include(s => s.RoboticscompetitionsNavigation)
                .Include(s => s.RoboticsdevelopmentanddevelopmenttoolsNavigation)
                .Include(s => s.RoboticsorganizationsNavigation)
                .Include(s => s.RoboticsprinciplesNavigation)
                .Include(s => s.SpecificrobotsNavigation)
                .Include(s => s.TypesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (specificRobotsInRelation == null)
            {
                return NotFound();
            }

            return View(specificRobotsInRelation);
        }

        // POST: SpecificRobotsInRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specificRobotsInRelation = await _context.SpecificRobotsInRelation.SingleOrDefaultAsync(m => m.Id == id);
            _context.SpecificRobotsInRelation.Remove(specificRobotsInRelation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SpecificRobotsInRelationExists(int id)
        {
            return _context.SpecificRobotsInRelation.Any(e => e.Id == id);
        }
    }
}
