namespace MidTerm
{
    internal class DataAnalyser
    {
        private List<int> _numbers = new List<int>();
        private SummaryStrategy _strategy;
        public DataAnalyser() : this(new List<int> { })
        {

        }
        public DataAnalyser(List<int> numbers, string strategy = "averaGE")
        {
            _numbers = numbers;
            strategy = strategy.Trim().ToLower();

            switch (strategy)
            {
                case "minmax":
                    _strategy = new MinMaxSummary();
                    break;
                default:
                    _strategy = new AverageSummary();
                    break;
            }
        }
        public SummaryStrategy Strategy
        {
            get { return _strategy; }
            set { _strategy = value; }
        }
        public void AddNumber(int num)
        {
            _numbers.Add(num);
        }
        public void Summarize()
        {
            _strategy.PrintSummary(_numbers);
        }
    }
}
