using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nipendo_project.Services.Interfaces
{
    internal interface IJsonService
    {
        T Deserialize<T>(string path);
    }
}
