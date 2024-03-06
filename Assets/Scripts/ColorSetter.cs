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

    public static Color CheckerColor(bool isBaseColor)
    {
        if (isBaseColor)
            return Color.blue;
        else
            return Color.red;
    }
}
