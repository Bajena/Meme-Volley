using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            StateManager.Instance.ResetView();
            
        }
    }
}
