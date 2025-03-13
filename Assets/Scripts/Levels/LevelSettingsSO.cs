using System.Collections.Generic;
using UnityEngine;
using Arkanoid.Bricks;

namespace Arkanoid.Levels
{
    [CreateAssetMenu(fileName = "newLevelSettings", menuName = "Level Settings/New level settings")]
    public class LevelSettingsSO : ScriptableObject
    {
        [Header("Объекты кирпичей и шанс их спавна.")]
        public List<BrickType> BrickTypes;
        
        [Header("Количество рядов и столбцов кирпичей на уровне.")]
        public int Rows;
        public int Columns;
        
        [Header("Расстояние между кирпичами.")]
        public float Spacing;

        [Header("Высота появления кирпичей.")]
        public float StartY;
        
        [Header("Возможные цвета кирпичей.")]
        public List<Color> ColorList;
    }
}