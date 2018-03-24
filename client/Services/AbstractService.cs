using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Services
{
    abstract class AbstractService
    {
        private string comunicationProt;
        public string ComunicationProt { get => comunicationProt; set => comunicationProt = value; }

        abstract public string GenerateRequest(List<string> input);
    }
}
