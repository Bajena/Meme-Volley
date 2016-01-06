using UnityEngine;
using System.Collections;
using System;

public class ComputerMovement : BaseMovement
{
    public Ball ball;
    public EDifficulty difficulty = EDifficulty.Medium;

    private float moveThreshold;
    private float lastJump = 0;
    private float jumpDelay;

    internal override float CalculateXMove()
    {
        var posDiff = transform.position.x - ball.transform.position.x;
        if (Math.Abs(posDiff)< moveThreshold)
        {
            return 0f;
        }
        
        return posDiff > 0 ? -1f : 1f;
    }

    internal override bool ShouldJump()
    {
        return Time.time > lastJump + jumpDelay;
    }

    protected void Start()
    {
        SetDifficulty(difficulty);
    }

    private void SetDifficulty(EDifficulty difficulty)
    {
       switch (difficulty)
        {
            case EDifficulty.Easy:
                moveThreshold = .2f;
                jumpDelay = 1f;
                break;
            case EDifficulty.Medium:
                moveThreshold = .2f;
                jumpDelay = .5f;
                break;
            case EDifficulty.Hard:
                moveThreshold = .0f;
                jumpDelay = .3f;
                break;
        }
    }
}