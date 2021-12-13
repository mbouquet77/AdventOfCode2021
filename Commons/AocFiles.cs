namespace AOC2021
{
    public class AocFiles
    {
        public string[] GetArrayFromFile()
        {
            return File.ReadAllLines(@"..\..\..\..\input.txt");
        }
    }
}
