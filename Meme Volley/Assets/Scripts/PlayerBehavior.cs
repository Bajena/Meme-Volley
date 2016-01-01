using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {
    public GameObject respawnPoint;
    public GameObject ballRespawnPoint;

    private Rigidbody2D _rigidBody2D
    {
        get
        {
            return GetComponent<Rigidbody2D>();
        }
    }

    public void Respawn()
    {
        _rigidBody2D.velocity = Vector2.zero;
        gameObject.transform.position = new Vector2(respawnPoint.transform.position.x, respawnPoint.transform.position.y);
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}