using System.Collections.Generic;

namespace Simple
{
    public class Variable : Expression
    {
        public Variable(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Reducible()
        {
            return true;
        }

        public override Context Reduce(Dictionary<string, Expression> environment)
        {
            return new Context(environment[Name], environment);
        }
    }
}
