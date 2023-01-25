using System;

namespace nipendo_project.Models
{
    internal class Health : IPolicy
    {
        public PolicyType Type { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public decimal Deductible { get; set; }
        public void LoadData(dynamic policyJson)
        {
            Gender = policyJson.Gender;
            Deductible = policyJson.Deductible;
        }

        public decimal Rate()
        {
            decimal rating;
            if (string.IsNullOrEmpty(Gender))
            {
                throw new ArgumentException("Health policy must specify Gender");
            }
            if (Gender == "Male")
            {
                if (Deductible < 500)
                {
                    rating = 1000m;
                }
                rating = 900m;
            }
            else
            {
                if (Deductible < 800)
                {
                    rating = 1100m;
                }
                rating = 1000m;
            }

            return rating;
        }
    }
}
