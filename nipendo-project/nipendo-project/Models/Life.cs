using System;

namespace nipendo_project.Models
{
    internal class Life : IPolicy
    {
        public PolicyType Type { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsSmoker { get; set; }
        public decimal Amount { get; set; }
        public void LoadData(dynamic policyJson)
        {
            IsSmoker = policyJson.IsSmoker;
            Amount = policyJson.Amount;
        }

        public decimal Rate()
        {
            decimal rating;
            if (DateOfBirth == DateTime.MinValue)
            {
                throw new ArgumentException("Life policy must include Date of Birth.");
            }
            if (DateOfBirth < DateTime.Today.AddYears(-100))
            {
                throw new ArgumentException("Max eligible age for coverage is 100 years.");
            }
            if (Amount == 0)
            {
                throw new ArgumentException("Life policy must include an Amount.");
            }

            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < DateOfBirth.Day ||
                DateTime.Today.Month < DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = Amount * age / 200;
            if (IsSmoker)
            {
                rating = baseRate * 2;
            }
            rating = baseRate;

            return rating;
        }
    }
}
