using System;
using UnityEngine;

public class TouchInputController : MonoBehaviour
{
    public event TileTappedDelegate TileTapped;

    public delegate void TileTappedDelegate(Transform tappedTile);

    private Touch _touch;

    void Update()
    {
        CheckTouch();
    }

    private void CheckTouch()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                SelectTile();
            }
        }
    }

    private void SelectTile()
    {
        Ray ray = Camera.main.ScreenPointToRay(_touch.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Tile")
            {
                Transform tappedTile = hit.collider.transform;
                TileTapped?.Invoke(tappedTile);
            }
        }
    }
}
