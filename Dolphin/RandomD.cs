using System;
using System.Text;

namespace Dolphin
{
    public class RandomD
    {
        public static string GenerateNewCode(int CodeLength)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < CodeLength; i++)
            {
                output.Append(random.Next(0, 9));
            }

            return output.ToString();
        }
    }
}
