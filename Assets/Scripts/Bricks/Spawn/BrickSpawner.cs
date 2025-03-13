using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Arkanoid.Levels;

namespace Arkanoid.Bricks
{
    public class BrickSpawner : MonoBehaviour
    {
        [Inject] private IBrickTracker brickTracker;
        [Inject] private BrickFactory<BasicBrick> basicBrickFactory;
        [Inject] private BrickFactory<BrickExtraBall> extraBallFactory;
        [Inject] private BrickFactory<BrickPowerUp> powerUpFactory;
        [Inject] private LevelSettingsSO levelSettings;
        
        private Dictionary<GameObject, System.Func<GameObject, Vector3, Transform, Brick>> factoryMap;

        private void Awake()
        {
            factoryMap = new Dictionary<GameObject, System.Func<GameObject, Vector3, Transform, Brick>>
            {
                { levelSettings.BrickTypes[0].prefab, (prefab, pos, parent) => basicBrickFactory.Create(prefab, pos, parent) },
                { levelSettings.BrickTypes[1].prefab, (prefab, pos, parent) => extraBallFactory.Create(prefab, pos, parent) },
                { levelSettings.BrickTypes[2].prefab, (prefab, pos, parent) => powerUpFactory.Create(prefab, pos, parent) }
            };
        }

        public void GenerateBricks()
        {
            if (levelSettings.BrickTypes.Count == 0)
            {
                Debug.LogError("No brick types assigned!");
                return;
            }

            Vector2 brickSize = levelSettings.BrickTypes[0].prefab.GetComponent<BoxCollider2D>().size;
            float brickWidth = brickSize.x;
            float brickHeight = brickSize.y;

            float totalWidth = levelSettings.Columns * (brickWidth + levelSettings.Spacing);
            float startX = -totalWidth / 2 + (brickWidth / 2);

            int totalBricks = levelSettings.Rows * levelSettings.Columns;
            Dictionary<GameObject, int> brickCounts = DistributeBricks(totalBricks);

            for (int row = 0; row < levelSettings.Rows; row++)
            {
                for (int col = 0; col < levelSettings.Columns; col++)
                {
                    Vector3 position = new Vector3(startX + col * (brickWidth + levelSettings.Spacing),
                        levelSettings.StartY - row * (brickHeight * 0.5f + levelSettings.Spacing), 0);

                    GameObject selectedBrick = GetRandomBrickType(brickCounts);
                    if (selectedBrick == null) continue;

                    if (!factoryMap.TryGetValue(selectedBrick, out var factoryMethod))
                    {
                        Debug.LogError($"No factory found for prefab {selectedBrick.name}!");
                        continue;
                    }

                    Brick newBrick = factoryMethod(selectedBrick, position, transform);
                    brickTracker.AddBrick(newBrick.gameObject);
                    newBrick.Initialize(brickTracker);
                    newBrick.GetComponent<SpriteRenderer>().color = levelSettings.ColorList[Random.Range(0, levelSettings.ColorList.Count)];
                }
            }
            Debug.Log("Spawned bricks: " + brickTracker.GetCount());
        }

        private Dictionary<GameObject, int> DistributeBricks(int totalBricks)
        {
            Dictionary<GameObject, int> brickCounts = new Dictionary<GameObject, int>();

            foreach (BrickType brick in levelSettings.BrickTypes)
            {
                int count = Mathf.RoundToInt((brick.percentage / 100f) * totalBricks);
                brickCounts[brick.prefab] = count;
            }

            return brickCounts;
        }

        private GameObject GetRandomBrickType(Dictionary<GameObject, int> brickCounts)
        {
            List<GameObject> availableBricks = new List<GameObject>();

            foreach (var kvp in brickCounts)
            {
                if (kvp.Value > 0)
                {
                    for (int i = 0; i < kvp.Value; i++)
                        availableBricks.Add(kvp.Key);
                }
            }

            if (availableBricks.Count == 0)
                return null;

            GameObject selected = availableBricks[Random.Range(0, availableBricks.Count)];
            brickCounts[selected]--;
            return selected;
        }
    }
}
