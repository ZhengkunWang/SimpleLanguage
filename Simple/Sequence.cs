using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    public class Sequence : Expression
    {
        public Sequence(Expression first, Expression second)
        {
            this.first = first;
            this.second = second;
        }

        private Expression first;
        private Expression second;
        public override string ToString()
        {
            return $"{first}; {second}";
        }

        public override bool Reducible()
        {
            return true;
        }

        public override Context Reduce(Dictionary<string, Expression> env)
        {
            if (first is DoNothing)
            {
                return new Context(second, env);
            }
            else
            {
                var context = first.Reduce(env);
                return new Context(new Sequence(context.Expression, second), context.Environment);
            }
        }
    }
}
