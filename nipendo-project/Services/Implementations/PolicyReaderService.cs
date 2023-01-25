using nipendo_project.Models;
using nipendo_project.Services.Interfaces;
using System;

namespace nipendo_project.Services.Implementations
{
    internal class PolicyReaderService : IPolicyReaderService
    {
        private readonly IPolicyFactory _policyFactory;

        public PolicyReaderService()
        {
            _policyFactory = new PolicyFactory();
        }

        public IPolicy GetDataFromJson(dynamic policyJson)
        {
            // Creating new policy object by using PolicyFactory

            PolicyType type = (PolicyType)Enum.Parse(typeof(PolicyType), policyJson.type.ToString());
            IPolicy policy = _policyFactory.Create(type);
            policy.Type = type;
            policy.FullName = policyJson.FullName;
            policy.DateOfBirth = policyJson.DateOfBirth == null ? DateTime.MinValue : policyJson.DateOfBirth;
            policy.LoadData(policyJson);
            return policy;
        }
    }
}
