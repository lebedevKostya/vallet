using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class ResponseHandler
    {
        private string _answer;
        private string[] _afterParse = new string [4];

        public ResponseHandler(string answer)
        {
            _answer = answer;
            _afterParse = answer.Split(',');

        }


        public void DoAnswer()
        {
            if (_afterParse[0] == "1") { Console.WriteLine("GOOD"); }
            else if (_afterParse[0] == "2") { Console.WriteLine("BAD"); }
            else   { Console.WriteLine("Very Bad"); }
        }
    }
}
