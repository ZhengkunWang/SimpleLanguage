using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    public class While : Expression
    {
        public While(Expression condition, Expression body)
        {
            this.condition = condition;
            this.body = body;
        }

        private Expression condition;
        private Expression body;

        public override string ToString()
        {
            return $"while ({condition}) {{ {body} }}";
        }

        public override bool Reducible()
        {
            return true;
        }

        public override Context Reduce(Dictionary<string, Expression> env)
        {
            return new Context(new If(condition, new Sequence(body, this), new DoNothing()), env);
        }
    }
}
