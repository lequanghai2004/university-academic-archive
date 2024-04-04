namespace MidTerm
{
    internal class MinMaxSummary : SummaryStrategy
    {
        private int Minimum(List<int> numbers)
        {
            int min = numbers[0];
            foreach (int number in numbers)
            {
                if(number < min)
                {
                    min = number;
                }
            }
            return min;
        }
        private int Maximum(List<int> numbers)
        {
            int max = numbers[0];
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            return max;
        }
        public override void PrintSummary(List<int> numbers)
        {
            Console.WriteLine(Minimum(numbers));
            Console.WriteLine(Maximum(numbers));
        }
    }
}
