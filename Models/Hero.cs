using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Models
{
    public class Hero
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Ability Ability { get; set; }
        public DateTime StartedTraining { get; set; }
        public string SuitColors { get; set; }
        public double StartingPower { get; set; }
        public double CurrentPower { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime? LastTrainingDate { get; set; }
        public int TrainingCounter { get; set; }

        public void setTrainingCounter()
        {
            if (this.LastTrainingDate.GetValueOrDefault().Date < DateTime.Now.Date)
            {
                this.LastTrainingDate = DateTime.Now;
                this.TrainingCounter = 0;
            }
        }
    }
}
