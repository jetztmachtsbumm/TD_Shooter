using System.Collections.Generic;
using TD_Shooter.GameGrid.Pathfinding;
using UnityEngine;

namespace TD_Shooter.GameGrid
{
    [DefaultExecutionOrder(-100)] //Ensure grid exists when other game components are loaded
    public class GameGrid : MonoBehaviour
    {
        public static GameGrid LevelInstance { get; private set; }

        [SerializeField] GridProperties gridProperties;

        public GridNode[,] GridNodes {  get; private set; }

        void Awake()
        {
            if(LevelInstance != null)
            {
                Debug.LogError("Tried to create GameGrid when there was already one present in this level!");
                Destroy(gameObject);
                return;
            }
            LevelInstance = this;

            GridNodes = new GridNode[gridProperties.gridWidth, gridProperties.gridHeight];
            for (var x = 0; x < gridProperties.gridWidth; x++)
            for (var y = 0; y < gridProperties.gridHeight; y++)
            {
                var nodeWorldX = transform.position.x + x * gridProperties.cellSize + gridProperties.cellSize / 2f;
                var nodeWorldZ = transform.position.z - y * gridProperties.cellSize - gridProperties.cellSize / 2f;

                GridNodes[x, y] = new GridNode(new Vector3(nodeWorldX, 0, nodeWorldZ), x, y);
            }
        }

        public GridNode GridNodeFromWorldPoint(Vector3 worldPos)
        {
            var gridWorldWidth = gridProperties.gridWidth * gridProperties.cellSize;
            var gridWorldHeight = gridProperties.gridHeight * gridProperties.cellSize;

            var percentX = Mathf.Clamp01((worldPos.x - transform.position.x) / gridWorldWidth);
            var percentY = Mathf.Clamp01((transform.position.z - worldPos.z) / gridWorldHeight);

            var x = Mathf.RoundToInt((gridProperties.gridWidth - 1) * percentX);
            var y = Mathf.RoundToInt((gridProperties.gridHeight - 1) * percentY);

            return GridNodes[x, y];
        }

        public List<GridNode> GetNeighboursOfGridNode(GridNode gridNode)
        {
            var neighbours = new List<GridNode>();

            int[,] directions = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };

            for (int i = 0; i < 4; i++)
            {
                int checkX = gridNode.gridX + directions[i, 0];
                int checkY = gridNode.gridY + directions[i, 1];

                if (checkX >= 0 && checkX < gridProperties.gridWidth && checkY >= 0 && checkY < gridProperties.gridHeight)
                    neighbours.Add(GridNodes[checkX, checkY]);
            }

            return neighbours;
        }
    }
}

