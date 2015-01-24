using UnityEngine;
using System.Collections;

public class Rick : MonoBehaviour {

    public float rickSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 v = rigidbody2D.velocity;
        v.x = rickSpeed;
	    rigidbody2D.velocity = v;
	}

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag == "Sam"){
            print("cockblocked");
            rickSpeed = 0;
        }
    }
}
