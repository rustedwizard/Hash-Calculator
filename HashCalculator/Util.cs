using System.Text;

namespace HashCalculator
{
    internal static class Util
    {
        public static string ByteArrayToString(byte[] input)
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in input)
            {
                result.Append(item.ToString("X2"));
            }
            return result.ToString();
        }
    }
}
