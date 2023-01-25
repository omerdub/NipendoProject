using nipendo_project.Models;

namespace nipendo_project.Services.Interfaces
{
    internal interface IPolicyReaderService
    {
        IPolicy GetDataFromJson(dynamic policyJson);
    }
}
