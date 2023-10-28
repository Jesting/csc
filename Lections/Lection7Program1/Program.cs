namespace Lection7Program1;
class Program
{
    class Bits
    {
        public Bits(byte b)
        {
            this.Value = b;
        }
        public byte Value { get; private set; } = 0;

        private void CheckIndex(int index)
        {
            if (index > 7 || index < 0)
                throw new BitsException(index);
        }

        public bool this[int index]
        {
            get
            {
                CheckIndex(index); 
                return ((Value >> index) & 1) == 1;
            }
            set
            {
                CheckIndex(index);
                if (value == true)
                    Value = (byte)(Value | (1 << index));
                else
                {
                    var mask = (byte)(1 << index);
                    mask = (byte)(0xff ^ mask);
                    Value &= (byte)(Value & mask);
                }
            }
        }
  
    }

    static void Main(string[] args)
    {
        var bits = new Bits(0xF0);

        Console.WriteLine(bits[-1]);
        Console.WriteLine(bits[1]);
    }
}
