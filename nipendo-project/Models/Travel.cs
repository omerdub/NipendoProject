using System;

namespace nipendo_project.Models
{
    internal class Travel : IPolicy
    {
        public PolicyType Type { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public int Days { get; set; }
        public void LoadData(dynamic policyJson)
        {
            Country = policyJson.Country;
            Days = policyJson.Days;
        }

        public decimal Rate()
        {
            decimal rating;
            if (Days <= 0)
            {
                throw new ArgumentException("Travel policy must specify Days.");
            }
            if (Days > 180)
            {
                throw new ArgumentException("Travel policy cannot be more then 180 Days.");
            }
            if (string.IsNullOrEmpty(Country))
            {
                throw new ArgumentNullException("Travel policy must specify country.");
            }
            rating = Days * 2.5m;
            if (Country == "Italy")
            {
                rating *= 3;
            }
            return rating;
        }
    }
}
