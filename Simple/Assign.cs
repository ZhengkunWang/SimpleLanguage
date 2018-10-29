using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    public class Assign : Expression
    {
        public Assign(string name, Expression expression)
        {
            this.name = name;
            this.expression = expression;
        }

        private string name;
        private Expression expression;

        public override string ToString()
        {
            return $"{name} = {expression}";
        }

        public override bool Reducible()
        {
            return true;
        }

        public override Context Reduce(Dictionary<string, Expression> environment)
        {
            if (expression.Reducible())
            {
                return new Context(new Assign(name, expression.Reduce(environment).Expression), environment);
            }
            else
            {
                environment[name] = expression;
                return new Context(new DoNothing(), environment);
            }
        }
    }
}
