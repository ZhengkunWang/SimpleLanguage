using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    public class If : Expression
    {
        public If(Expression condition, Expression consequence, Expression alternative)
        {
            this.condition = condition;
            this.consequence = consequence;
            this.alternative = alternative;
        }

        private Expression condition;
        private Expression consequence;
        private Expression alternative;

        public override string ToString()
        {
            return $"if ({condition}) {{ {consequence} }} else {{ {alternative} }}";
        }

        public override bool Reducible()
        {
            return true;
        }

        public override Context Reduce(Dictionary<string, Expression> env)
        {
            if (condition.Reducible())
            {
                return new Context(new If(condition.Reduce(env).Expression, consequence, alternative), env);
            }
            else
            {
                if (condition is Boolean && (bool) condition.Value == true)
                {
                    return new Context(consequence, env);
                }
                else
                {
                    return new Context(alternative, env);
                }
            }
        }
    }
}
