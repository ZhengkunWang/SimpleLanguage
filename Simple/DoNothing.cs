using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    public class DoNothing : Expression
    {
        public override string ToString()
        {
            return "do-nothing";
        }

        public override bool Reducible()
        {
            return false;
        }
    }
}
