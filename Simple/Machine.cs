using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple
{
    public class Machine
    {
        public Machine(Expression expression, Dictionary<string, Expression> env)
        {
            this.environment = env;
            this.expression = expression;
        }

        private Expression expression;
        private Dictionary<string, Expression> environment;

        public void Step()
        {
            var context = expression.Reduce(environment);
            this.expression = context.Expression;
            this.environment = context.Environment;
        }

        public void Run()
        {
            while (expression.Reducible())
            {
                Console.WriteLine(expression + ", { " + string.Join(",", environment.Select(e => $"{e.Key} => {e.Value}").ToArray()) + " }");
                Step();
            }

            Console.WriteLine(expression + ", { " + string.Join(",", environment.Select(e => $"{e.Key} => {e.Value}").ToArray()) + " }");
        }
    }
}
