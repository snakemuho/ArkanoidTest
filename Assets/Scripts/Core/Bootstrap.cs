using Arkanoid.Ball;
using Arkanoid.Bricks;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private IGameStateController gameStateController;
        [Inject] private IUIController uiController;
        [Inject] private IBrickTracker brickTracker;
        [Inject] private IBallTracker ballTracker;
        [Inject] private BrickSpawner brickSpawner;
        [SerializeField] private BallMovement initialBall;
        
        private void Start()
        {
            brickTracker.OnNoBricksLeft += gameStateController.Win;
            ballTracker.OnNoBallsLeft += gameStateController.GameOver;

            gameStateController.OnStartGame += uiController.ShowGameplayView;
            gameStateController.OnGameOver += uiController.ShowGameOverView;
            gameStateController.OnWin += uiController.ShowYouWinView;
            
            brickSpawner.GenerateBricks();
            gameStateController.StartGame();
            initialBall.Launch();
        }
    }
}