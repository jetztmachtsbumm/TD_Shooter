using UnityEngine;
using static UnityEngine.Rendering.STP;

namespace TD_Shooter.GameGrid
{
    public class GameGrid : MonoBehaviour
    {

        [SerializeField] private GridProperties gridProperties;

        public static GameGrid LevelInstance { get; private set; }

        void Awake()
        {
            if(LevelInstance != null)
            {
                Debug.LogError("Tried to create GameGrid when there was already one present in this level!");
                Destroy(gameObject);
            }
            LevelInstance = this;
        }

        public Vector3 GetSnappedPosition(Vector3 worldPos, Vector3 origin)
        {
            var x = Mathf.RoundToInt((worldPos.x - origin.x) / gridProperties.cellSize);
            var z = Mathf.RoundToInt((worldPos.z - origin.z) / gridProperties.cellSize);
            return new Vector3(x * gridProperties.cellSize + origin.x, worldPos.y, z * gridProperties.cellSize + origin.z);
        }

        public Vector2Int WorldToCell(Vector3 worldPos, Vector3 origin)
        {
            var x = Mathf.RoundToInt((worldPos.x - origin.x) / gridProperties.cellSize);
            var z = Mathf.RoundToInt((worldPos.z - origin.z) / gridProperties.cellSize);
            return new Vector2Int(x, z);
        }

        public Vector3 CellToWorld(Vector2Int cell, Vector3 origin, float y = 0f)
        {
            return new Vector3(cell.x * gridProperties.cellSize + origin.x, y, cell.y * gridProperties.cellSize + origin.z);
        }
    }
}

