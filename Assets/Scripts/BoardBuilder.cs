using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardBuilder : MonoBehaviour
{
    [SerializeField] private Transform _tilePrefab;
    [SerializeField] private Transform _boardContainerParent;

    public void CreateBoard(int width, int height)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var pos = new Vector2(x, y);
                var isWhite = !IsEven(x + y);
                var tile = Instantiate(_tilePrefab, pos, Quaternion.identity, _boardContainerParent);
                var tileInfo = tile.GetComponent<TileInfo>();

                tileInfo.Init(pos, isWhite);
                SetTileColor(tile, isWhite);
                BoardInfo.Tiles.Add(tile);
            }
        }
    }

    private void SetTileColor(Transform tile, bool isWhite)
    {
        tile.GetComponent<SpriteRenderer>().color = ColorSetter.TileColor(isWhite);
    }
    private bool IsEven(int num) => 
        num % 2 == 0;
}
