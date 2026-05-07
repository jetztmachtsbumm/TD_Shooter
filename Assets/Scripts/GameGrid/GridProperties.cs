using UnityEngine;

namespace TD_Shooter.GameGrid
{
    [CreateAssetMenu(menuName = "GameGrid/GridProperties")]
    public class GridProperties : ScriptableObject
    {
        [Header("Grid dimensions")]
        public int gridWidth = 1;
        public int gridHeight = 1;
        public float cellSize = 1;

        [Space]

        [SerializeField] public LayerMask nodeOccupationLayer;
    }
}