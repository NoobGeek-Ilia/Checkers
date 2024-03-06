using System.ComponentModel;
using UnityEngine;

public class CheckerInfo : MonoBehaviour, ISelectable
{
    public Color DefaultColor { get; set; }
    public Vector2 Coordinates { get; private set; }

    public void SetNewPosition(Vector2 coordinates)
    {
        Coordinates = coordinates;
        transform.position = Coordinates;
    }

    public void Init(Vector2 coordinates, Color color)
    {
        Coordinates = coordinates;
        transform.position = Coordinates;
        DefaultColor = color;
        ResetHighlight();
    }

    public void ResetHighlight()
    {
        GetComponent<SpriteRenderer>().color = DefaultColor;
    }

    public void SetHighlight(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }
}
