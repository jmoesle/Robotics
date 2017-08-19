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
            foreach (var property in listspecificrobotsinrelation.Where(p => p.Contributingfields != null)) {
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
            ViewData["specificrobots"] = specificrobots;

            ViewData["NotSelectedDegreeOfMaturity"] = NotSelectedDegreeOfMaturity;
            SpecificRobotsInRelation specificrobotsinrelation = new SpecificRobotsInRelation();
            specificrobotsinrelation.Specificrobots = specificrobots;
            return View(specificrobotsinrelation);
            
        }


        // GET: SpecificRobotsInRelations/Add
        public IActionResult Add(int specificrobots, string property, int id, string currentpath)
        {

            var relation = new SpecificRobotsInRelation();

            if (property.Equals("ContributingFields")) {  relation = new SpecificRobotsInRelation { Specificrobots = specificrobots, Contributingfields = id }; };
            if (property.Equals("ModesOfLocomotion")) {  relation = new SpecificRobotsInRelation { Specificrobots = specificrobots, Modesoflocomotion = id }; };
            if (property.Equals("RoboticsPrinciples")) {  relation = new SpecificRobotsInRelation { Specificrobots = specificrobots, Roboticsprinciples = id }; };
            if (property.Equals("Business")) {  relation = new SpecificRobotsInRelation { Specificrobots = specificrobots, Business = id }; };
            if (property.Equals("Branches")) {  relation = new SpecificRobotsInRelation { Specificrobots = specificrobots, Branches = id }; };
            if (property.Equals("Types")) {  relation = new SpecificRobotsInRelation { Specificrobots = specificrobots, Types = id }; };
            if (property.Equals("RobotComponentsAndDesignFeatures")) {  relation = new SpecificRobotsInRelation { Specificrobots = specificrobots, Robotcomponentsanddesignfeatures = id }; };
            if (property.Equals("RoboticsDevelopmentAndDevelopmentTools")) {  relation = new SpecificRobotsInRelation { Specificrobots = specificrobots, Roboticsdevelopmentanddevelopmenttools = id }; };
            if (property.Equals("RoboticsCompanies")) {  relation = new SpecificRobotsInRelation { Specificrobots = specificrobots, Roboticscompanies = id }; };
            if (property.Equals("RoboticsOrganizations")) {  relation = new SpecificRobotsInRelation { Specificrobots = specificrobots, Roboticsorganizations = id }; };
            if (property.Equals("RoboticsCompetitions")) {  relation = new SpecificRobotsInRelation { Specificrobots = specificrobots, Roboticscompetitions = id }; };
            if (property.Equals("InfluentialPeople")) {  relation = new SpecificRobotsInRelation { Specificrobots = specificrobots, Influentialpeople = id }; };
            if (property.Equals("DegreeOfMaturity")) {  relation = new SpecificRobotsInRelation { Specificrobots = specificrobots, Degreeofmaturity = id }; };

            _context.Add(relation);
            _context.SaveChanges();

            String[] url = new String[4];
            url = currentpath.Split('/');
            return RedirectToAction(url[3], url[2], new { specificrobots = specificrobots });

        }

        // GET: SpecificRobotsInRelations/Remove
        public IActionResult Remove(int specificrobots, string property, int id, string currentpath)
        {

            int relation = 0;
            List<SpecificRobotsInRelation> listSpecificRobotsInRelation = _context.SpecificRobotsInRelation.ToList();
            if (property.Equals("ContributingFields")) { foreach (var entry in listSpecificRobotsInRelation.Where(E=>E.Contributingfields == id)) { relation = entry.Id; }; };
            if (property.Equals("ModesOfLocomotion")) { foreach (var entry in listSpecificRobotsInRelation.Where(E => E.Modesoflocomotion == id)) { relation = entry.Id; }; };
            if (property.Equals("RoboticsPrinciples")) { foreach (var entry in listSpecificRobotsInRelation.Where(E => E.Roboticsprinciples == id)) { relation = entry.Id; }; };
            if (property.Equals("Business")) { foreach (var entry in listSpecificRobotsInRelation.Where(E => E.Business == id)) { relation = entry.Id; }; };
            if (property.Equals("Branches")) { foreach (var entry in listSpecificRobotsInRelation.Where(E => E.Branches == id)) { relation = entry.Id; }; };
            if (property.Equals("Types")) { foreach (var entry in listSpecificRobotsInRelation.Where(E => E.Types == id)) { relation = entry.Id; }; };
            if (property.Equals("RobotComponentsAndDesignFeatures")) { foreach (var entry in listSpecificRobotsInRelation.Where(E => E.Robotcomponentsanddesignfeatures == id)) { relation = entry.Id; }; };
            if (property.Equals("RoboticsDevelopmentAndDevelopmentTools")) { foreach (var entry in listSpecificRobotsInRelation.Where(E => E.Roboticsdevelopmentanddevelopmenttools == id)) { relation = entry.Id; }; };
            if (property.Equals("RoboticsCompanies")) { foreach (var entry in listSpecificRobotsInRelation.Where(E => E.Roboticscompanies == id)) { relation = entry.Id; }; };
            if (property.Equals("RoboticsOrganizations")) { foreach (var entry in listSpecificRobotsInRelation.Where(E => E.Roboticsorganizations == id)) { relation = entry.Id; }; };
            if (property.Equals("RoboticsCompetitions")) { foreach (var entry in listSpecificRobotsInRelation.Where(E => E.Roboticscompetitions == id)) { relation = entry.Id; }; };
            if (property.Equals("InfluentialPeople")) { foreach (var entry in listSpecificRobotsInRelation.Where(E => E.Influentialpeople == id)) { relation = entry.Id; }; };
            if (property.Equals("DegreeOfMaturity")) { foreach (var entry in listSpecificRobotsInRelation.Where(E => E.Degreeofmaturity == id)) { relation = entry.Id; }; };

            var specificRobotsInRelation = _context.SpecificRobotsInRelation.SingleOrDefault(m => m.Id == relation);
            _context.SpecificRobotsInRelation.Remove(specificRobotsInRelation);
            _context.SaveChanges();
            

            String[] url = new String[4];
            url = currentpath.Split('/');
            return RedirectToAction(url[3], url[2], new { specificrobots = specificrobots });

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
