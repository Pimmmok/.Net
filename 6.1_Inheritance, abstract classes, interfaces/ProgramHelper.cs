namespace _6._1_Inheritance__abstract_classes__interfaces
{
    public class ProgramHelper : ProgramConverter, ICodeChecker
    {
        public bool CheckCodeSyntax(string line, string programmingLanguage)
        {
            return line.IndexOf(programmingLanguage) >= 0;
        }
    }
}
