using UnityEngine;

namespace TD_Shooter.GameGrid.Pathfinding
{
    public class GridNode
    {
        public bool occupied;
        public Vector3 worldPosition;
        public int gridX, gridY;

        public int gCost;
        public int hCost;
        public int fCost => gCost + hCost;

        public GridNode parent;

        public GridNode(Vector3 worldPosition, int gridX, int gridY)
        {
            this.worldPosition = worldPosition;
            this.gridX = gridX;
            this.gridY = gridY;

            //Check if occupied
        }
    }
}
