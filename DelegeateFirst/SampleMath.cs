namespace DelegeateFirst
{
    public class SampleMath
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        //ta metoda nie pasuje do wzoru naszego pierwszego delegata dlatego jak 
        //bedziemy chcieli ją przekazać to dostaniemt bład kompilatora
        public static string Subtract(int x, int y)
        {
            return (x - y).ToString();
        }
    }
}
