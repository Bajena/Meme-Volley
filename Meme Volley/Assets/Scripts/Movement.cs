using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    // Update is called once per frame
	void Update () {
        float xPos = gameObject.transform.position.x + .1F * Input.GetAxis("Horizontal");
        gameObject.transform.position = new Vector3(xPos, -1.5F);
	}
}
