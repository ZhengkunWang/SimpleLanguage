namespace Simple
{
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

}
