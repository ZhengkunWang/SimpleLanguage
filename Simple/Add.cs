﻿using System.Collections.Generic;

namespace Simple
{
    public class Add : TwoFactorOperator
    {
        public Add(Expression left, Expression right) : base(left, right)
        {
        }

        public override string ToString()
        {
            return $"{Left} + {Right}";
        }

        public override Context Reduce(Dictionary<string, Expression> environment)
        {
            if (Left.Reducible())
            {
                return new Context(new Add(Left.Reduce(environment).Expression, Right), environment);
            }
            else if (Right.Reducible())
            {
                return new Context(new Add(Left, Right.Reduce(environment).Expression), environment);
            }
            else
            {
                return new Context(new Number(double.Parse(Left.Value.ToString()) + double.Parse(Right.Value.ToString())), environment);
            }
        }

        public override Expression Evaluate(Dictionary<string, Expression> env)
        {
            return new Number(double.Parse(Left.Evaluate(env).Value.ToString()) + double.Parse(Right.Evaluate(env).Value.ToString()));
        }
    }
}
