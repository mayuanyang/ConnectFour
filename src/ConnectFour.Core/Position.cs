using System;
using ConnectFour.Core.Interfaces;

namespace ConnectFour.Core
{
	public class Position : IPosition, IComparable<IPosition>, IComparable
	{
		public Position(int indexInColumn)
		{
			IndexInColumn = indexInColumn;
		}

		public ICounter Counter { get; private set; }
		public int IndexInColumn { get; private set; }
		public void SetCounter(ICounter counter)
		{
		    Counter = counter ?? throw new ArgumentException("Counter cannot be null", nameof(counter));
		}

		public int CompareTo(IPosition other)
		{
			return IndexInColumn.CompareTo(other.IndexInColumn);
		}

		public int CompareTo(object obj)
		{
			if (obj == null)
				return 0;

			var otherSquare = obj as IPosition;
			if (otherSquare != null)
			{
				return IndexInColumn.CompareTo(otherSquare.IndexInColumn);
			}

			throw new ArgumentException("obj is not IPosition", nameof(obj));
		}
	}
}