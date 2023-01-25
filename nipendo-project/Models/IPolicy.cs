using System;

namespace nipendo_project.Models
{
    internal interface IPolicy
    {
        public PolicyType Type { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        void LoadData(dynamic policyJson);
        decimal Rate();
    }
}
