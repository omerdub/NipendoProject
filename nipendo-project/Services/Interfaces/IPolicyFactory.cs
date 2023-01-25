using nipendo_project.Models;

namespace nipendo_project.Services.Interfaces
{
    internal interface IPolicyFactory
    {
        IPolicy Create(PolicyType policyType);
    }
}
