using System.Collections.Generic;
using UnityEngine;

public class Model
{
    public Vector2Int FieldSize => _fieldSize;
    private Vector2Int _fieldSize = new Vector2Int(x: 20, y: 20);
    public List<Vector2Int> Snake { get; set; }
    public Vector2Int Food { get; set; }
    public float TurnDuration { get; set; } = 0.5f;
    public bool gameOver = false;
}
