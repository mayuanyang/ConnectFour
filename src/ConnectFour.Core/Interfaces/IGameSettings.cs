namespace ConnectFour.Core.Interfaces
{
	public interface IGameSettings
	{
		int BoardWidth { get; }
		int BoardHeight { get; }
		int NumberOfPlayers { get; }
		int WinningConnectCount { get; }
	}
}