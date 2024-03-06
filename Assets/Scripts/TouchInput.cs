using System;
using UnityEngine;

public class TouchInput : IInput
{
    public event Action<Vector2> ClickDown;

    public void ClickCheck()
    {
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                ClickDown?.Invoke(_touch.position);
            }
        }
    }
}
