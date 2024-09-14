using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

[CreateAssetMenu]
public class Model : ScriptableObject
{
    public Vector2Int FieldSize => _fieldSize;
    private Vector2Int _fieldSize = new Vector2Int(x: 20, y: 20);
    public List<Vector2Int> Snake { get; set; }
    public Vector2Int Food { get; set; }
    public float TurnDuration { get; set; } = 0.6f;

    public event Action OnEatFood;
    private int _points;
    public int Points
    {
        get => _points;
        set {
            if (_points != value)
            {
                _points = value;
                OnEatFood?.Invoke();
            }
        }
    }

    public void Initialize(Vector2Int initializeDirection)
    {
        Points = 0;
        var snadeHead = new Vector2Int(x: FieldSize.x / 2, y: FieldSize.y / 2);
        var snakeBody = snadeHead - initializeDirection;
        Snake = new List<Vector2Int>
        {
            snadeHead,
            snakeBody,
            snakeBody - initializeDirection,
        };
    }
}
