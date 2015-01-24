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

        //Debug.DrawRay((Vector2)(transform.position),-Vector2.up);
	}

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag == "Sam"){
            print("cockblocked");
            rickSpeed = 0;
        }
        if(coll.gameObject.tag == "Bob"){
            print("boing");
            rickSpeed = -(2*rickSpeed); //only do this if Rick hits Bob from the side
            //needs more code to check if hit from top
        }
    }
}
