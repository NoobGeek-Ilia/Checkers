using UnityEngine;

public class ColorSetter : MonoBehaviour
{
    [SerializeField] private Color FirstTileColor;
    [SerializeField] private Color SecondTileColor;
    [SerializeField] private Color FirstCheckerColor;
    [SerializeField] private Color SecondCheckerColor;
    public Color TileColor(bool isBaseColor)
    {
        if (isBaseColor)
            return FirstTileColor;
        else 
            return SecondTileColor;
    }

    public Color CheckerColor(bool isBaseColor)
    {
        if (isBaseColor)
            return FirstCheckerColor;
        else
            return SecondCheckerColor;
    }
}
