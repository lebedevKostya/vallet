using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Services
{
    class RegService : AbstractService
    {
        public RegService()
        {
            ComunicationProt = "2";
        }


        public override string GenerateRequest(List<string> inputHand)
        {
            inputHand.Insert(0, ComunicationProt);
            string request = String.Join(",", inputHand);
            return request; ;
        }
    }
}
