using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaixaEletronicoTest
{
    public class SaqueException: Exception
    {
        public SaqueException(string msg):base(msg) {
        
        }
    }
}
