using UnityEngine;
using Zenject;

namespace Arkanoid.Bricks
{
    public class BrickFactory<T> : PlaceholderFactory<GameObject, Vector3, Transform, T>
        where T : Brick
    {
        private readonly DiContainer container;

        public BrickFactory(DiContainer container)
        {
            this.container = container;
        }

        public override T Create(GameObject prefab, Vector3 position, Transform parent)
        {
            GameObject instance = container.InstantiatePrefab(prefab, position, Quaternion.identity, parent);

            T brick = instance.GetComponent<T>();
            if (brick == null)
            {
                Debug.LogError($"Prefab {prefab.name} does not contain a component of type {typeof(T).Name}!");
                return null;
            }

            return brick;
        }
    }
}