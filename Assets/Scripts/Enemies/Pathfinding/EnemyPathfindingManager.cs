using System.Collections.Generic;
using TD_Shooter.GameGrid.Pathfinding;
using TD_Shooter.Pathfinding;
using UnityEngine;

public class EnemyPathfindingManager : MonoBehaviour
{
    public static EnemyPathfindingManager Instance { get; private set; }

    public List<GridNode> CurrentEnemyPath { get; private set; }

    [SerializeField] private Transform startingPosition;
    [SerializeField] private Transform targetPosition;

    void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Tried to create EnemyPathfindingManager when there was already one present in this level!");
            Destroy(gameObject);
            return;
        }
        Instance = this;

        CurrentEnemyPath = Pathfinding.FindPath(startingPosition.position, targetPosition.position);
    }
}
