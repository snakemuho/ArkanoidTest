using Doozy.Runtime.UIManager.Containers;
using Zenject;

public class UIController : IUIController
{
    [Inject(Id = "Gameplay")] private readonly UIView _gameplayView;
    [Inject(Id = "GameOver")] private readonly UIView _gameOverView;
    [Inject(Id = "YouWin")] private readonly UIView _youWinView;

    public void ShowGameplayView()
    {
        _gameplayView.Show();
        _gameOverView.Hide();
        _youWinView.Hide();
    }

    public void ShowGameOverView()
    {
        _gameplayView.Hide();
        _gameOverView.Show();
    }

    public void ShowYouWinView()
    {
        _gameplayView.Hide();
        _youWinView.Show();
    }
}