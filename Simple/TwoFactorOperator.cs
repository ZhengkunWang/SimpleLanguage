namespace Simple
{
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
}
