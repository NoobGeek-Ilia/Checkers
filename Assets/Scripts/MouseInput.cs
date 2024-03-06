using System;
using UnityEngine;

public class MouseInput : IInput
{
    public event Action<Vector2> ClickDown;

    public void ClickCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickDown?.Invoke(Input.mousePosition);
        }
    }
}
