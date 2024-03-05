using System.Collections.Generic;
using UnityEngine;

public class BoardInfo : MonoBehaviour
{
    public static List<Transform> Tiles = new();

    public const int WIDTH = 8;
    public const int HEIGHT = 8;

    public const float TILE_WIDTH = 1;
    public const float TILE_HEIGHT = 1;
}