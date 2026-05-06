using UnityEngine;

[CreateAssetMenu(menuName = "GameGrid/GridProperties")]
public class GridProperties : ScriptableObject
{
    public float gridWidth = 10;
    public float gridHeight = 10;
    public float cellSize = 1;
}
