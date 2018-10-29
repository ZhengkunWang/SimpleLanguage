using System;
using System.Collections.Generic;

namespace Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Expression> env = new Dictionary<string, Expression>()
            {
                ["x"] = new Number(3),
                ["y"] = new Number(4),
            };
            Expression expression = new Add(new Multiply(new Number(1), new Number(2)), new Multiply(new Number(3), new Number(4)));
            new Machine(expression, env).Run();
            Expression expression2 = new LessThan(new Number(5), new Add(new Number(2), new Number(2)));
            new Machine(expression2, env).Run();
            Expression expression3 = new Add(new Variable("x"), new Variable("y"));
            new Machine(expression3, env).Run();
            Expression assignment = new Assign("x", new Add(new Variable("x"), new Number(1)));
            new Machine(assignment, new Dictionary<string, Expression>() { ["x"] = new Number(2) }).Run();
            Expression ifExpression = new If(new Variable("x"), new Assign("y", new Number(1)), new DoNothing());
            new Machine(ifExpression, new Dictionary<string, Expression>
            {
                ["x"] = new Boolean(false)
            }).Run();

            Console.Read();
        }
    }
}
