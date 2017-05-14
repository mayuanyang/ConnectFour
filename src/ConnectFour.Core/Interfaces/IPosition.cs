namespace ConnectFour.Core.Interfaces
{
	public interface IPosition
	{
		ICounter Counter { get; }
		int IndexInColumn { get; }

		void SetCounter(ICounter counter);
	}
}