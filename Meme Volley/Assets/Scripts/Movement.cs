using UnityEngine;
using System.Collections;
using System;

public class Movement : BaseMovement
{
    public string jumpButton = "Jump_P1";
    public string horizontalAxis = "Horizontal_P1";

    internal override float CalculateXMove()
    {
        return Input.GetAxis(horizontalAxis);
    }

    internal override bool ShouldJump()
    {
        return Input.GetButtonDown(jumpButton);
    }
}