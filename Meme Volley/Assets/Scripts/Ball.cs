using UnityEngine;
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

    // Use this for initialization
    void Start () {
	
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
}
