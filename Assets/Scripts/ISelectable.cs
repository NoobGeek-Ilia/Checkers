using UnityEngine;
interface ISelectable
{
    public static Color SelectColor = Color.green;
    public Color DefaultColor { get; set; }
    void SetHighlight(Color color);
    void ResetHighlight();
}
