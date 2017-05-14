using System.Collections.Generic;

namespace ConnectFour.Core.Interfaces
{
	public interface IColumn
	{
		IEnumerable<IPosition> Positions { get; }
		int Index { get; }
		int Height { get; }
	}
}