using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public Vector2 Coordinates { get; private set; }
    public bool IsWhite { get; private set; }
    public bool IsFull { get; set; }

    public void Init(Vector2 coordinates, bool isWhite)
    {
        Coordinates = coordinates;
        IsWhite = isWhite;
    }
}
