using UnityEngine;

public static class ColorSetter
{
    public static Color TileColor(bool isBaseColor)
    {
        if (isBaseColor)
            return Color.white;
        else 
            return Color.gray;
    }
}
