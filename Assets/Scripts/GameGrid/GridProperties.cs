using UnityEngine;

namespace TD_Shooter.GameGrid
{
    [CreateAssetMenu(menuName = "GameGrid/GridProperties")]
    public class GridProperties : ScriptableObject
    {
        public int gridWidth = 1;
        public int gridHeight = 1;
        public float cellSize = 1;
    }
}