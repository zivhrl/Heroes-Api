using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Models
{
    public static class SeedHeroes
    {
        public static void Seed(HeroesContext _context)
        {
            _context.Database.Migrate();
            if (_context.Heroes.Count() == 0)
            {
                ApplicationUser user1 = _context.Users.FirstOrDefault(user => user.UserName == "ziv");
                ApplicationUser user2 = _context.Users.FirstOrDefault(user => user.UserName == "rony");


                Hero hero1 = new Hero();
                Hero hero2 = new Hero();
                Hero hero3 = new Hero();
                Hero hero4 = new Hero();
                Hero hero5 = new Hero();
                Hero hero6 = new Hero();

                hero1.Id = Guid.NewGuid();
                hero1.Name = "Superman";
                hero1.SuitColors = "Blue, Red";
                hero1.StartedTraining = new DateTime(2021, 4, 5);
                hero1.Ability = Ability.ATTACKER;
                hero1.StartingPower = 450.5;
                hero1.CurrentPower = 657.8;
                hero1.TrainingCounter = 0;
                hero1.LastTrainingDate = new DateTime(2021, 11, 13);
                hero1.User = user1;


                hero2.Id = Guid.NewGuid();
                hero2.Name = "Defender";
                hero2.SuitColors = "Silver, black";
                hero2.StartedTraining = new DateTime(2021, 5, 5);
                hero2.Ability = Ability.DEFENDER;
                hero2.StartingPower = 200.0;
                hero2.CurrentPower = 367.8;
                hero2.TrainingCounter = 5;
                hero2.LastTrainingDate = new DateTime(2021, 11, 13);
                hero2.User = user1;



                hero3.Id = Guid.NewGuid();
                hero3.Name = "Rom";
                hero3.SuitColors = "Blue";
                hero3.StartedTraining = new DateTime(2021, 4, 5);
                hero3.Ability = Ability.ATTACKER;
                hero3.StartingPower = 250.7;
                hero3.CurrentPower = 560.9;
                hero3.TrainingCounter = 3;
                hero3.LastTrainingDate = new DateTime(2021, 11, 13);
                hero3.User = user1;


                hero4.Id = Guid.NewGuid();
                hero4.Name = "antiman";
                hero4.SuitColors = "Blue, Red";
                hero4.StartedTraining = new DateTime(2021, 4, 5);
                hero4.Ability = Ability.DEFENDER;
                hero4.StartingPower = 450.5;
                hero4.CurrentPower = 657.8;
                hero4.TrainingCounter = 0;
                hero4.LastTrainingDate = new DateTime(2021, 11, 13);
                hero4.User = user2;


                hero5.Id = Guid.NewGuid();
                hero5.Name = "Attecker";
                hero5.SuitColors = "Silver, black";
                hero5.StartedTraining = new DateTime(2021, 5, 5);
                hero5.Ability = Ability.ATTACKER;
                hero5.StartingPower = 200.0;
                hero5.CurrentPower = 367.8;
                hero5.TrainingCounter = 5;
                hero5.LastTrainingDate = new DateTime(2021, 11, 13);
                hero5.User = user2;



                hero6.Id = Guid.NewGuid();
                hero6.Name = "Mor";
                hero6.SuitColors = "Red";
                hero6.StartedTraining = new DateTime(2021, 4, 5);
                hero6.Ability = Ability.DEFENDER;
                hero6.StartingPower = 250.7;
                hero6.CurrentPower = 560.9;
                hero6.TrainingCounter = 3;
                hero6.LastTrainingDate = new DateTime(2021, 11, 13);
                hero6.User = user2;




                _context.Heroes.AddRange(hero1, hero2, hero3, hero5, hero6, hero4);
                _context.SaveChanges();
            }
        }
    }
}
