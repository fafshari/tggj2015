using UnityEngine;
using System.Collections;

public class Rick : MonoBehaviour {
	
	public Vector2 direction = Vector2.right;
    public Vector2 rickSpeed;
	public bool inSlow;
    public bool isAlive;

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
		if (!inSlow) {
			if (coll.gameObject.tag == "Carl") {
				// victory
				StateManager.NotifyRickInsideCarl();
				return;
			}
			if (coll.gameObject.tag == "Sam") {
					print ("cockblocked");
					rigidbody2D.velocity = Vector2.zero;
			}
			if (coll.gameObject.tag == "Speedy") {
					print ("lawdadasd");
					float angle = coll.transform.eulerAngles.z * Mathf.Deg2Rad;
					float sin = Mathf.Sin (angle);
					float cos = Mathf.Cos (angle);

					rigidbody2D.AddForce (new Vector2 (direction.x * cos - direction.y * sin,
                                 direction.x * sin + direction.y * cos) * 1000);

					AudioClip clip = Resources.Load ("slowmo") as AudioClip;
					print (clip);
					AudioSource.PlayClipAtPoint (Resources.Load ("slowmo") as AudioClip, transform.position, 1); 
			}
		}
	}
}
