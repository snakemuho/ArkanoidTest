using System;
using UnityEngine;

namespace Core
{
    public class GameStateController : IGameStateController
    {
        public Action OnStartGame { get; set; }
        public Action OnGameOver { get; set; }
        public Action OnWin { get; set; }
        
        public void StartGame()
        {
            Time.timeScale = 1;
            OnStartGame?.Invoke();
        }

        public void GameOver()
        {
            Time.timeScale = 0;
            OnGameOver?.Invoke();
        }

        public void Win()
        {
            Time.timeScale = 0;
            OnWin?.Invoke();
        }
    }
}