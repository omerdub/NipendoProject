using nipendo_project.Models;
using nipendo_project.Services.Interfaces;
using System;

namespace nipendo_project.Services.Implementations
{
    internal class PolicyFactory : IPolicyFactory
    {
        public IPolicy Create(PolicyType policyType)
        {
            switch (policyType)
            {
                case PolicyType.Life:
                    return new Life();
                case PolicyType.Travel:
                    return new Travel();
                case PolicyType.Health:
                    return new Health();
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
