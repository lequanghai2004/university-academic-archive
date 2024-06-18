using System.ComponentModel;
using System.Reflection;

namespace MidTerm
{
    internal class BusinessAnalyser
    {
        private List<int> _numbers = new List<int>();
        private SummaryStrategy _strategy;
        public BusinessAnalyser() : this(new List<int> { })
        {

        }
        public BusinessAnalyser(List<int> numbers, string strategy = "Average")
        {
            _numbers = numbers;
            try
            {
                Assembly assem = typeof(SummaryStrategy).Assembly;
                strategy = "MidTerm." + strategy + "Summary";

                SummaryStrategy? ins = assem.CreateInstance(strategy) as SummaryStrategy;
                if (ins != null) _strategy = ins;
                else throw new ArgumentException("Invalid strategy");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _strategy = new AverageSummary();
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


