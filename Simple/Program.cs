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
            Expression sequencExpression = new Sequence(new Assign("x", new Add(new Number(1), new Number(1))), new Assign("y", new Add(new Variable("x"), new Number(3))));
            new Machine(sequencExpression, new Dictionary<string, Expression>()).Run();
            Expression whileExpression = new While(new LessThan(new Variable("x"), new Number(5)), new Assign("x", new Multiply(new Variable("x"), new Number(3))));
            new Machine(whileExpression, new Dictionary<string, Expression>()
            {
                ["x"] = new Number(1)
            }).Run();
            Console.WriteLine(new Number(23).Evaluate(new Dictionary<string, Expression>()).ToString());
            Console.WriteLine(new Variable("x").Evaluate(new Dictionary<string, Expression>() { ["x"]=new Number(23)}).ToString());
            Console.WriteLine(new LessThan(new Add(new Variable("x"), new Number(2)), new Variable("y")).Evaluate(new Dictionary<string, Expression>() { ["x"]=new Number(2), ["y"]=new Number(5)}).ToString());
            Console.Read();
        }
    }
}
