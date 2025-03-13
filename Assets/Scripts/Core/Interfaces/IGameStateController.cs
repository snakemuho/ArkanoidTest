using System;

namespace Core
{
    public interface IGameStateController
    {
        public Action OnStartGame { get; set; }
        public Action OnGameOver { get; set; }
        public Action OnWin { get; set; }
        public void StartGame();
        public void GameOver();
        public void Win();
    }
}