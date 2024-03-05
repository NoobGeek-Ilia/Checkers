using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private const float DEFAULT_POS_Z = -10;  
    private void Start()
    {
        SetStartPosition();
    }

    private void SetStartPosition()
    {
        float halfTileWidth = BoardInfo.TILE_WIDTH / 2;
        float halfTileHeight = BoardInfo.TILE_HEIGHT / 2;

        var x = (BoardInfo.WIDTH / 2) - halfTileWidth;
        var y = (BoardInfo.HEIGHT / 2) - halfTileHeight;
        var z = DEFAULT_POS_Z;

        transform.position = new Vector3(x, y, z);
    }
}
