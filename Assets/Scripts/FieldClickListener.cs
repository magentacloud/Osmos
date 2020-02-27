using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldClickListener : MonoBehaviour
{
    public Vector2 _clickTarget;
    public DateTime _clickInitialTime;
    public TimeSpan _dragTime;
    private void OnMouseDown()
    {
        _clickInitialTime = DateTime.Now;
    }
    private void OnMouseUp()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _clickTarget.x = target.x;
        _clickTarget.y = target.y;
        DateTime clickTerminalTime = DateTime.Now;
        _dragTime = clickTerminalTime.Subtract(_clickInitialTime);
    }
}
