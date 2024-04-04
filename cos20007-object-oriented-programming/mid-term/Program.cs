namespace MidTerm
{
    public class Program
    {
        static void Main1(string[] args)
        {
            DataAnalyser dA2 = new DataAnalyser(new List<int> { 1, 0, 4, 1, 7, 5, 7, 7, 9 }, "minmAX");
            DataAnalyser dA1 = new DataAnalyser(new List<int> { 1, 0, 4, 1, 7, 5, 7, 7, 9 });

            dA1.Summarize();
            dA2.Summarize();
        }
        static void Main(string[] args)
        {
            BusinessAnalyser bA2 = new BusinessAnalyser(new List<int> { 1, 0, 4, 1, 7, 5, 7, 7, 9 }, "MinMax");
            BusinessAnalyser bA1 = new BusinessAnalyser(new List<int> { 1, 0, 4, 1, 7, 5, 7, 7, 9 }, "Average");

            bA1.Summarize();
            bA2.Summarize();
        }
    }
}