using System.Diagnostics;

namespace TandemString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region MethodForGeneration
            Int32 NumOfString = 25;
            StringGenerator stringGenerator = new StringGenerator();
            var ListOfString = stringGenerator.GenerateStrings(NumOfString, 5);
            Console.WriteLine(string.Join(" ", ListOfString));
            #endregion

            Stopwatch sw = new Stopwatch();

            #region TestDataInput
            sw.Start();
            List<string> _teststring = new List<string>()
            {
                "4", "a", "abbaa", "bba", "abb"
            };
            Console.WriteLine(string.Join(" ", _teststring));
            #endregion

            #region MainCheckerMethod
            CheckTandemString checkTandemString = new CheckTandemString(_teststring);
            var data = checkTandemString.GetEnumOfString();
            if (data != null)
            {
                Console.WriteLine(string.Join("\n", data));
            }

            sw.Stop();
            Console.WriteLine("Total Time is " + sw.ElapsedMilliseconds + " ms");
            #endregion

            Console.ReadKey();
            
        }
    }
}
