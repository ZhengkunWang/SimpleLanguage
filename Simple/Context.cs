using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    public class Context
    {
        public Expression Expression { get; set; }
        public Dictionary<string, Expression> Environment { get; set; }

        public Context(Expression exp, Dictionary<string, Expression> env)
        {
            Expression = exp;
            Environment = env;
        }
    }
}
