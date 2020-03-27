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
                Part Bel = new Part { Name = "Bel", Description = "De bel wordt gebruikt als geluidssignal om andere weggebruikers te signaliseren", Functionality = Functionality.Varia, IsOptional = true };
                Part Stuur = new Part { Name = "Stuur", Description = "Het stuur is een metalen buis die er voor zorgt dat je de richting kan kiezen waarin je stuurt", Functionality = Functionality.Sturen, IsOptional = false, DependantParts = new List<Part>(){ Bel } };
                Part BottomBracket = new Part { Name = "Bottom Bracket", Description = "De Bottom Bracket is de motor van de Bike. Het Part zit tussen de twee pedalen en zorgt dat de pedalen goed draaien.", Functionality = Functionality.Aandrijving, IsOptional = false };
                Part CrankSet = new Part { Name = "Crank Set", Description = "De crankset zal voor de meeste mensen bekend staan als de pedalen.", Functionality = Functionality.Aandrijving, IsOptional = false, DependantParts = new List<Part>() { BottomBracket } };
                ICollection<Part> parts = new List<Part>() {Stuur, Bel, BottomBracket, CrankSet };
                _applicationDbContext.Parts.AddRange(parts);
                
                #endregion

                #region bikes
                Bike fixie = new Bike { Name = "Fixie", Type = "Single-speed track", Parts = new List<Part>() {Stuur, Bel, BottomBracket, CrankSet } };
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
