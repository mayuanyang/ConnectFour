using ConnectFour.Core.Interfaces;

namespace ConnectFour.Core
{
	public class GameSettings : IGameSettings
	{
		public int BoardWidth { get; set; }
		public int BoardHeight { get; set; }
		public int NumberOfPlayers { get; set; }
		public int WinningConnectCount { get; set; }
	}
}