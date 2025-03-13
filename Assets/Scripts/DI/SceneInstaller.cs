using Arkanoid.Audio;
using Arkanoid.Ball;
using Arkanoid.Bricks;
using Arkanoid.Levels;
using Core;
using Doozy.Runtime.UIManager.Containers;
using Arkanoid.Player;
using UnityEngine;
using Zenject;

namespace Arkanoid.DI
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private LevelSettingsSO levelSettings;
        [SerializeField] private AudioClipPlayer audioClipPlayer;
        [SerializeField] private BrickSpawner brickSpawner;
        [SerializeField] private PlayerInputHandler playerInputHandler;
        
        [SerializeField] private UIView gameplayView;
        [SerializeField] private UIView gameOverView;
        [SerializeField] private UIView youWinView;
        
        public override void InstallBindings()
        {
            BindFactories();
            BindInterfaces();
            BindInstances();
            BindUI();
        }

        private void BindFactories()
        {
            Container.BindFactory<GameObject, Vector3, Transform, BasicBrick, BrickFactory<BasicBrick>>()
                .AsSingle();
            Container.BindFactory<GameObject, Vector3, Transform, BrickExtraBall, BrickFactory<BrickExtraBall>>()
                .AsSingle();
            Container.BindFactory<GameObject, Vector3, Transform, BrickPowerUp, BrickFactory<BrickPowerUp>>()
                .AsSingle();
        }

        private void BindInterfaces()
        {
            Container.Bind<IBrickTracker>().To<BrickTracker>().AsSingle();
            Container.Bind<IBallTracker>().To<BallTracker>().AsSingle();
            Container.Bind<IUIController>().To<UIController>().AsSingle();
            Container.Bind<IGameStateController>().To<GameStateController>().AsSingle();
        }

        private void BindInstances()
        {
            Container.Bind<LevelSettingsSO>().FromInstance(levelSettings).AsSingle();
            Container.Bind<BrickSpawner>().FromInstance(brickSpawner).AsSingle();
            Container.Bind<PlayerInputHandler>().FromInstance(playerInputHandler).AsSingle();
            Container.Bind<AudioClipPlayer>().FromInstance(audioClipPlayer).AsSingle();
        }

        private void BindUI()
        {
            Container.Bind<UIView>().WithId("Gameplay").FromInstance(gameplayView);
            Container.Bind<UIView>().WithId("GameOver").FromInstance(gameOverView);
            Container.Bind<UIView>().WithId("YouWin").FromInstance(youWinView);
        }
    }
}