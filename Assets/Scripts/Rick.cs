using UnityEngine;
using System.Collections;

public class Rick : MonoBehaviour {

    public Vector2 rickSpeed;

	// Use this for initialization
	void Start () {
		rigidbody2D.AddForce (rickSpeed);
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.DrawRay((Vector2)(transform.position),-Vector2.up);
	}

    void OnCollisionEnter2D(Collision2D coll){}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.tag == "Sam"){
			print("cockblocked");
			rigidbody2D.velocity = Vector2.zero;
		}
	}
}
