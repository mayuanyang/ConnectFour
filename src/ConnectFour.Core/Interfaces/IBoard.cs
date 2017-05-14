using System.Collections.Generic;

namespace ConnectFour.Core.Interfaces
{
    public interface IBoard
    {
        IEnumerable<IColumn> Columns { get; }
        int Height { get; }
        int Width { get; }
        bool CanPutCounterAt(int columnIndex);
        void PutCounterAt(int columnIndex, ICounter counter);
    }
}