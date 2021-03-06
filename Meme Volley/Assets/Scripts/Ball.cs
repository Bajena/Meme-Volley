﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private Rigidbody2D _rigidBody2D
    {
        get
        {
            return GetComponent<Rigidbody2D>();
        }
    }

    private bool isSleeping = true;

    public void Respawn(Vector2 respawnPoint)
    {
        isSleeping = true;
        gameObject.transform.position = respawnPoint;
    }
    
	// Update is called once per frame
	void FixedUpdate () {
	    if (isSleeping)
        {
            _rigidBody2D.Sleep();
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isSleeping = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var field= other.gameObject.GetComponent<Field>();
        if (field != null)
        {
            StateManager.Instance.scoreManager.PointLost(field.player);
        }
    }
}
