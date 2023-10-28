namespace Lection5Program2;
class Program
{
    static bool ValidParentheses(string s)
    {
        Stack<char> stack = new Stack<char>();
        foreach (var c in s)
        {
            if (c == '[') stack.Push(']');
            if (c == '(') stack.Push(')');
            if (c == '{') stack.Push('}');

            if ("])}".Contains(c))
            {
                if (stack.Count == 0)
                    return false;
                if (stack.Pop() != c)
                    return false;
            }
        }
        return stack.Count == 0;
    }


    static void Main(string[] args)
    {
        Console.WriteLine(ValidParentheses("(([]{}))()"));
        Console.WriteLine(ValidParentheses("()(({())))"));
    }
}

