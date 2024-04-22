namespace ПР9
{
    public class Node
    {
        public char Operator { get; set; }
        public double Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(char op, Node left, Node right)
        {
            Operator = op;
            Left = left;
            Right = right;
        }
        public Node(double value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public double DIYA()
        {
            if (Operator == '\0') 
            {
                return Value;
            }
            else 
            {
                double leftValue = Left.DIYA();
                double rightValue = Right.DIYA();

                switch (Operator)
                {
                    case '+':
                        return leftValue + rightValue;
                    case '-':
                        return leftValue - rightValue;
                    case '*':
                        return leftValue * rightValue;
                    case '/':
                        if (rightValue == 0)
                            throw new DivideByZeroException("Ділення на нуль неможливе");
                        return leftValue / rightValue;
                    default:
                        throw new InvalidOperationException("Невідомий оператор");
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Node Derevo = new Node('*',
      new Node('+',
          new Node(5), new Node(3)),
      new Node('-',
          new Node(7), new Node(2)));
            Console.WriteLine($"(5+3)*(7-2)={Derevo.DIYA()}");
        }
    }
}
