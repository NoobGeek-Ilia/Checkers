using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private IInput _input;
    public Action<Transform> OnSelectedTile;

    private void Start()
    {
        _input = new MouseInput();
        InputInit(_input);
    }

    private void Update()
    {
        _input.ClickCheck();
    }

    private void InputInit(IInput input)
    {
        _input = input;
        input.ClickDown += SelectTile;
    }

    private void SelectTile(Vector2 ClickPos)
    {
        var ray = Camera.main.ScreenPointToRay(ClickPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Tile")
            {
                var tile = hit.collider.transform;
                OnSelectedTile?.Invoke(tile);
                var tileInfo = tile.GetComponent<TileInfo>();
                Debug.Log(tileInfo.Coordinates);
            }
        }
    }
}
