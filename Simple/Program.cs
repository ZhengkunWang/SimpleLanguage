using System;

namespace Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression expression = new Add(new Multiply(new Number(1), new Number(2)), new Multiply(new Number(3), new Number(4)));
            new Machine(expression).Run();
            Expression expression2 = new LessThan(new Number(5), new Add(new Number(2), new Number(2)));
            new Machine(expression2).Run();
            Console.Read();
        }
    }
    public abstract class Expression
    {
        public object Value { get; set; }

        public abstract bool Reducible();

        public virtual Expression Reduce()
        {
            return this;
        }
    }

    public class SimpleObject : Expression
    {
        public SimpleObject(object value)
        {
            this.Value = value;
        }

        public override bool Reducible()
        {
            return false;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class Number : SimpleObject
    {
        public Number(object value) : base(value) {}
    }

    public class Boolean : SimpleObject
    {
        public Boolean(object value) : base(value) {}
    }

    public class LessThan : TwoFactorOperator
    {
        public LessThan(Expression left, Expression right) : base(left, right)
        {
        }

        public override string ToString()
        {
            return $"{Left} < {Right}";
        }

        public override Expression Reduce()
        {
            if (Left.Reducible())
            {
                return new LessThan(Left.Reduce(), Right);
            }
            else if (Right.Reducible())
            {
               return new LessThan(Left, Right.Reduce());
            }
            else
            {
                return new Boolean(double.Parse(Left.Value.ToString()) < double.Parse(Right.Value.ToString()));
            }
        }
    }

    public class TwoFactorOperator : Expression
    { 
        public Expression Left { get; set; }

        public Expression Right { get; set; }

        public TwoFactorOperator(Expression left, Expression right)
        {
            this.Left = left;
            this.Right = right;
        }

        public override bool Reducible()
        {
            return true;
        }
    }

    public class Add : TwoFactorOperator
    {
        public Add(Expression left, Expression right) : base(left, right)
        {
        }

        public override string ToString()
        {
            return $"{Left} + {Right}";
        }

        public override Expression Reduce()
        {
            if (Left.Reducible())
            {
                return new Add(Left.Reduce(), Right);
            }
            else if(Right.Reducible())
            {
                return new Add(Left, Right.Reduce());
            }
            else
            {
                return new Number(double.Parse(Left.Value.ToString()) + double.Parse(Right.Value.ToString()));
            }
        }
    }

    public class Multiply : TwoFactorOperator
    {
        public Multiply(Expression left, Expression right) : base(left, right) { }

        public override string ToString()
        {
            return $"{Left} * {Right}";
        }
        public override Expression Reduce()
        {
            if (Left.Reducible())
            {
                return new Add(Left.Reduce(), Right);
            }
            else if(Right.Reducible())
            {
                return new Add(Left, Right.Reduce());
            }
            else
            {
                return new Number(double.Parse(Left.Value.ToString()) * double.Parse(Right.Value.ToString()));
            }
        }
    }

    public class Machine
    {
        public Machine(Expression expression)
        {
            Step(expression);
        }

        private Expression expression;

        public void Step(Expression expression)
        {
            this.expression = expression;
            Console.WriteLine(expression);
        }

        public Expression Run()
        {
            while (expression.Reducible())
            {
               Step(expression.Reduce()); 
            }

            return expression;
        }
    }
}
