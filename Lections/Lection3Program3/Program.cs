namespace Lection3Program3;
class Program
{
    class Bits
    {
        public Bits(byte b)
        {
            this.Value = b;
        }
        public byte Value { get; private set; } = 0;
        public bool this[int index]
        {
            get
            {
                if (index > 7 || index < 0)
                    return false;
                return ((Value >> index) & 1) == 1;
            }
            set
            {
                if (index > 7 || index < 0) return;
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


        public static implicit operator byte(Bits b) => b.Value;
        public static explicit operator Bits(byte b) => new Bits(b);
    }

    static void Main(string[] args)
    {
        var bits = new Bits(10);
        byte b = bits;
        
        b = 20;
        bits = (Bits)b;
    }
}

