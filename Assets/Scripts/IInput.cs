using System;
using UnityEngine;

interface IInput
{
    public event Action<Vector2> ClickDown;
    public void ClickCheck();
}
