﻿using System.Collections.Generic;
using System.Data;

namespace Simple
{
    public abstract class Expression
    {
        public object Value { get; set; }

        public abstract bool Reducible();

        public virtual Context Reduce(Dictionary<string, Expression> environment)
        {
            return new Context(this, environment);
        }
    }
}
