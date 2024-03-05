using System.ComponentModel;
using UnityEngine;

public class CheckerInfo : MonoBehaviour, ISelectable
{
    public Vector2 Coordinates { get; private set; }

    public void Init(Vector2 coordinates)
    {
        Coordinates = coordinates;
    }

    public void ResetHighlight(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }

    public void SetHighlight(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }
}
