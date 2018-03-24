using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Services
{
    class AuthService : AbstractService
    {
        
        
        public AuthService()
        {
            ComunicationProt = "1";
        }


        public override string  GenerateRequest(List<String> inputHand)
        {
            inputHand.Insert(0, ComunicationProt);
            string request = String.Join(",", inputHand); 
            return request;
        }
    }
}
