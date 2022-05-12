namespace _6._1_Inheritance__abstract_classes__interfaces
{
    public class ProgramConverter : IConvertible
    {
        public string ConvertToCSharp(string line)
        {
            return new string(line + " converted to C# code.");
        }

        public string ConvertToVB(string line)
        {
            return new string(line + " converted to VB code.");
        }
    }
}
