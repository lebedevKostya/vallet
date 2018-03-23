using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class AuthService
    {
        
        private string _comunicationProt;



        public AuthService()
        {
            _comunicationProt = "1";
        }


        public string GenerateRequest(string[] inputHand)
        {
            string request = _comunicationProt + "," + inputHand[0] + "," + inputHand[1]; 
            return request;
        }
    }
}
