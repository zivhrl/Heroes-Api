using Heroes_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Dtos
{
    public class HeroDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Ability Ability { get; set; }
        public DateTime StartedTrainingDate { get; set; }
        public string SuitColors { get; set; }
        public double StartingPower { get; set; }
        public double CurrentPower { get; set; }
        public bool CanTrain { get; set; }
        public DateTime? LastTrainingDate { get; set; }
        public int TrainingCounter { get; set; }
    }
}
