using FietsAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FietsAPI.Data
{
    public class BikeDataInitializer
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public BikeDataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _applicationDbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _applicationDbContext.Database.EnsureDeleted();
            if (_applicationDbContext.Database.EnsureCreated())
            {
                #region parts
                Part Zadel = new Part
                {
                    Name = "Zadel",
                    Description = "Het zadel is het deel waar je op zit.",
                    Functionality = Functionality.Varia,
                    IsOptional = false
                };
                Part Zadelpen = new Part
                {
                    Name = "Zadelpen",
                    Description = "De Zadelpen voorziet de verbinding tussen zadel en  kader. De hoogte van het zadel kan daar ook mee versteld worden.",
                    Functionality = Functionality.Varia,
                    IsOptional = false,
                    
                };
                
                Part Bel = new Part 
                { 
                    Name = "Bel", 
                    Description = "De bel wordt gebruikt als geluidssignal om andere weggebruikers te signaliseren", 
                    Functionality = Functionality.Varia, 
                    IsOptional = true 
                };
                Part Stuur = new Part 
                { 
                    Name = "Stuur", 
                    Description = "Het stuur is een metalen buis die er voor zorgt dat je de richting kan kiezen waarin je stuurt", 
                    Functionality = Functionality.Sturen, 
                    IsOptional = false, 
                    
                };
              
                Part pedalen = new Part
                {
                    Name = "Pedalen",
                    Description = "De pedalen zijn de voetsteunen van de fiets.",
                    Functionality = Functionality.Aandrijving,
                    IsOptional = false,
                };
                Part ketting = new Part()
                {
                    Name = "Ketting",
                    Description = "De ketting draagt de energie van de pedalen over naar het achterwiel.",
                    Functionality = Functionality.Aandrijving,
                    IsOptional = false
                };
                Part achterTandWiel = new Part()
                {
                    Name = "Achter tandwiel",
                    Description = "Het achterste tandwiel hangt vast aan het achterwiel en drijft via de ketting de fiets aan.",
                    Functionality = Functionality.Aandrijving,
                    IsOptional = false,
                    
                };
                Part CrankSet = new Part
                {
                    Name = "Crankset",
                    Description = "De crankset zal voor de meeste mensen bekend staan als de pedalen.",
                    Functionality = Functionality.Aandrijving,
                    IsOptional = false,
                    
                };
                Part BottomBracket = new Part 
                { 
                    Name = "Bottom Bracket", 
                    Description = "De Bottom Bracket is de motor van de Bike. Het Part zit tussen de twee pedalen en zorgt dat de pedalen goed draaien.", 
                    Functionality = Functionality.Aandrijving, 
                    IsOptional = false,
                    

                };
                Part BuitenBand = new Part()
                {
                    Name = "Buitenband",
                    Description = "De buitenband dient als bescherming voor de binnenband. Ook zorgen de groeven voor waterafleiding en grip op de weg",
                    Functionality = Functionality.Remmen,
                    IsOptional = false
                };
                Part BinnenBand = new Part()
                {
                    Name = "Binnenband",
                    Description = "De binnenband bevat lucht. De lucht vangt de schokken van de weg gedeeltelijk op.",
                    Functionality = Functionality.Aandrijving,
                    IsOptional = false,
                    
                };
                Part Voorwiel = new Part
                {
                    Name = "Voorwiel",
                    Description = "Het voorwiel is het wiel dat aan je voorvoor/stuur vasthangt en niet wordt aangedreven, maar gewoon meerijdt.",
                    Functionality = Functionality.Sturen,
                    IsOptional = false,
                    
                };
                Part Achterwiel = new Part
                {
                    Name = "Achterwiel",
                    Description = "Het  achterwiel is het onderdeel dat de aandrijving naar de grond overbrengt.",
                    Functionality = Functionality.Aandrijving,
                    IsOptional = false,
                    
                };
                Part stuurpen = new Part()
                {
                    Name = "Stuurpen",
                    Description = "De stuurpen is de verbinding tussen het stuur en de voorvork. Het stuur kan ook verhoogt/verlaagt worden.",
                    Functionality = Functionality.Sturen,
                    
                };
                Part Voorvork = new Part()
                {
                    Name = "Voorvork",
                    Description = "De voorvork werkt als verbinding tussen het kader, het voorwiel en de stuurpen/het stuur.",
                    Functionality = Functionality.Sturen,
                    IsOptional = false,
                    
                
                };
                Part Kader = new Part
                {
                    Name = "Kader",
                    Description = "Het kader is het skelet van de fiets. het verbindt alle onderdelen van de fiets",
                    Functionality = Functionality.Varia,
                    IsOptional = false,
                    
                };

                ICollection<Part> parts = new List<Part>() 
                {
                    Stuur, Bel, BottomBracket, 
                    CrankSet, BuitenBand, BinnenBand, 
                    Voorwiel, Achterwiel, Zadel, 
                    Zadelpen, Kader, stuurpen, 
                    achterTandWiel, ketting, pedalen,
                    Voorvork};
                _applicationDbContext.Parts.AddRange(parts);
                _applicationDbContext.SaveChanges();

                #endregion

                #region partsRelations
                PartsRelation zadelPenZadel = new PartsRelation
                {
                    DominantPart = Zadelpen,
                    DependantPart = Zadel,
                    DomId = Zadelpen.Id,
                    DepId = Zadel.Id
                };
                PartsRelation crankSetPedalen = new PartsRelation
                {
                    DominantPart = CrankSet,
                    DependantPart = pedalen,
                    DomId = CrankSet.Id,
                    DepId = pedalen.Id
                };
                PartsRelation binnenBandBuitenband = new PartsRelation
                {
                    DominantPart = BinnenBand,
                    DependantPart = BuitenBand,
                    DomId = BinnenBand.Id,
                    DepId = BuitenBand.Id
                };
                PartsRelation voorwielBinnenband = new PartsRelation
                {
                    DominantPart = Voorwiel,
                    DependantPart = BinnenBand,
                    DomId = Voorwiel.Id,
                    DepId = BinnenBand.Id
                };
                PartsRelation voorwielBuitenband = new PartsRelation
                {
                    DominantPart = Voorwiel,
                    DependantPart = BuitenBand,
                    DomId = Voorwiel.Id,
                    DepId = BuitenBand.Id
                };
                PartsRelation achterwielBinnenband = new PartsRelation
                {
                    DominantPart = Achterwiel,
                    DependantPart = BinnenBand,
                    DomId = Achterwiel.Id,
                    DepId = BinnenBand.Id
                };
                PartsRelation achterwielBuitenband = new PartsRelation
                {
                    DominantPart = Achterwiel,
                    DependantPart = BuitenBand,
                    DomId = Achterwiel.Id,
                    DepId = BuitenBand.Id
                };
                PartsRelation achterwielAchterTandwiel = new PartsRelation
                {
                    DominantPart = Achterwiel,
                    DependantPart = achterTandWiel,
                    DomId = Achterwiel.Id,
                    DepId = achterTandWiel.Id
                };
                PartsRelation achterTandWielKetting = new PartsRelation
                {
                    DominantPart = achterTandWiel,
                    DependantPart = ketting,
                    DomId = achterTandWiel.Id,
                    DepId = ketting.Id

                };
                PartsRelation cranksetKetting = new PartsRelation
                {
                    DominantPart = CrankSet,
                    DependantPart = ketting,
                    DomId = CrankSet.Id,
                    DepId = ketting.Id
                };
                PartsRelation bottomBracketCrankset = new PartsRelation
                {
                    DominantPart = BottomBracket,
                    DependantPart = CrankSet,
                    DomId = BottomBracket.Id,
                    DepId = CrankSet.Id
                };
                PartsRelation voorvorkVoorwiel = new PartsRelation
                {
                    DominantPart = Voorvork,
                    DependantPart = Voorwiel,
                    DomId = Voorvork.Id,
                    DepId = Voorwiel.Id
                };
                PartsRelation voorvorkStuurpen = new PartsRelation
                {
                    DominantPart = Voorvork,
                    DependantPart = stuurpen,
                    DomId = Voorvork.Id,
                    DepId = stuurpen.Id
                };
                PartsRelation stuurpenStuur = new PartsRelation
                {
                    DominantPart = stuurpen,
                    DependantPart = Stuur,
                    DomId = stuurpen.Id,
                    DepId = Stuur.Id
                };
                PartsRelation stuurBel = new PartsRelation
                {
                    DominantPart = Stuur,
                    DependantPart = Bel,
                    DomId = Stuur.Id,
                    DepId = Bel.Id
                };
                PartsRelation kaderVoorvork = new PartsRelation
                {
                    DominantPart = Kader,
                    DependantPart = Voorvork,
                    DomId = Kader.Id,
                    DepId = Voorvork.Id

                };
                PartsRelation kaderAchterwiel = new PartsRelation
                {
                    DominantPart = Kader,
                    DependantPart = Achterwiel,
                    DomId = Kader.Id,
                    DepId = Achterwiel.Id
                };
                PartsRelation kaderBottombracket = new PartsRelation
                {
                    DominantPart = Kader,
                    DependantPart = BottomBracket,
                    DomId = Kader.Id,
                    DepId = BottomBracket.Id
                };
                PartsRelation kaderStuurPen = new PartsRelation
                {
                    DominantPart = Kader,
                    DependantPart = stuurpen,
                    DomId = Kader.Id,
                    DepId = stuurpen.Id
                };
                PartsRelation kaderZadelpen = new PartsRelation
                {
                    DominantPart = Kader,
                    DependantPart = Zadelpen,
                    DomId = Kader.Id,
                    DepId = Zadelpen.Id
                };
                _applicationDbContext.PartsRelations.AddRange(
                    new List<PartsRelation> 
                    {
                        zadelPenZadel, 
                        crankSetPedalen, cranksetKetting, 
                        stuurBel, 
                        stuurpenStuur, 
                        binnenBandBuitenband,
                        achterwielAchterTandwiel, achterwielBinnenband, achterwielBuitenband,
                        voorwielBinnenband, voorwielBuitenband,
                        voorvorkStuurpen, voorvorkVoorwiel,
                        bottomBracketCrankset,
                        achterTandWielKetting,
                        kaderAchterwiel, kaderBottombracket, kaderStuurPen, kaderVoorvork, kaderZadelpen
                    }
                    );


                #endregion

                #region bikes
                Bike fixie = new Bike { Name = "Fixie", Type = "Single-speed track", Parts = parts };
                _applicationDbContext.Bikes.Add(fixie);
                #endregion

                #region users
                BUser putin = new BUser { Email = "Vladimir.Putin@hogent.be", FirstName = "Vladimir", LastName = "Putin" };
                _applicationDbContext.BUsers.Add(putin);
                await CreateUser(putin.Email, "Putin1");
                BUser mao = new BUser { Email = "Mao.Zedong@hogent.be", FirstName = "Mao", LastName = "Zedong" };
                _applicationDbContext.BUsers.Add(mao);
                await CreateUser(mao.Email, "Zedong1");
                
                #endregion

                _applicationDbContext.SaveChanges();
            }
        }

        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }

    }
}
