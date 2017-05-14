using System;
using System.Collections.Generic;
using ConnectFour.Core.Interfaces;

namespace ConnectFour.Core
{
	public class GridFullArgs
	{
		public List<Tuple<int, Symbol>> MovesPlayed { get; set; }
	}
}