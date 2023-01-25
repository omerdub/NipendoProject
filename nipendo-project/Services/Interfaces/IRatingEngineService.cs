using nipendo_project.Models;
using static nipendo_project.Utils.Logger;

namespace nipendo_project.Services.Interfaces
{
    internal interface IRatingEngineService
    {
        decimal Rating { get; set; }
        void Rate(IPolicy policy, LogDelegate logger);
    }
}
