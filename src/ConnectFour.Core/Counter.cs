using ConnectFour.Core.Interfaces;

namespace ConnectFour.Core
{
	
	public class Counter : ICounter
	{
		public Counter(Symbol symbol)
		{
			Symbol = symbol;
		}

		public Symbol Symbol { get; private set; }
	}
}