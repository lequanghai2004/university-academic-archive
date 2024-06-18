namespace MidTerm
{
    internal class AverageSummary : SummaryStrategy
    {
        private float Average(List<int> numbers)
        {
            int sum = 0;

            foreach(int number in numbers)
            {
                sum += number;
            }

            return (float)sum / numbers.Count;
        }

        public override void PrintSummary(List<int> numbers)
        {
            Console.WriteLine(Average(numbers));
        }
    }
}
