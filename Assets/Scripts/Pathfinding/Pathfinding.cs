using System.Collections.Generic;
using TD_Shooter.GameGrid.Pathfinding;
using UnityEngine;

namespace TD_Shooter.Pathfinding
{
    public static class Pathfinding
    {

        public static List<GridNode> FindPath(Vector3 startPos, Vector3 targetPos)
        {
            var grid = GameGrid.GameGrid.LevelInstance;

            foreach (var node in grid.GridNodes)
            {
                node.gCost = int.MaxValue;
                node.hCost = 0;
                node.parent = null;
            }

            var startNode = grid.GridNodeFromWorldPoint(startPos);
            var targetNode = grid.GridNodeFromWorldPoint(targetPos);

            startNode.gCost = 0;
            startNode.hCost = GetDistance(startNode, targetNode);

            var openNodes = new List<GridNode>(); //Use List for indexed access
            var closedNodes = new HashSet<GridNode>(); //Use HashSet for fast hash lookup

            openNodes.Add(startNode);

            while (openNodes.Count > 0)
            {
                var current = openNodes[0];
                for (var i = 1; i < openNodes.Count; i++)
                {
                    if (openNodes[i].fCost < current.fCost ||
                       (openNodes[i].fCost == current.fCost && openNodes[i].hCost < current.hCost))
                    {
                        current = openNodes[i];
                    }
                }

                openNodes.Remove(current);
                closedNodes.Add(current);

                if(current == targetNode)
                {
                    return RetracePath(startNode, targetNode);
                }

                foreach(var neighbour in grid.GetNeighboursOfGridNode(current))
                {
                    if (neighbour.occupied || closedNodes.Contains(neighbour)) continue;

                    var newCostToNeighbour = current.gCost + GetDistance(current, neighbour);

                    if (newCostToNeighbour < neighbour.gCost || !openNodes.Contains(neighbour))
                    {
                        neighbour.gCost = newCostToNeighbour;
                        neighbour.hCost = GetDistance(neighbour, targetNode);
                        neighbour.parent = current;

                        if (!openNodes.Contains(neighbour))
                        {
                            openNodes.Add(neighbour);
                        }
                    }
                }
            }

            return null;
        }

        private static List<GridNode> RetracePath(GridNode startNode, GridNode targetNode)
        {
            var path = new List<GridNode>();
            GridNode current = targetNode;

            while(current != startNode)
            {
                path.Add(current);
                current = current.parent;
            }

            path.Reverse();
            return path;
        }

        private static int GetDistance(GridNode a, GridNode b)
        {
            return (Mathf.Abs(a.gridX - b.gridX) + Mathf.Abs(a.gridY - b.gridY)) * 10;
        }
    }
}