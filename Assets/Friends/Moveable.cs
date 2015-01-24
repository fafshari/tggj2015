using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour {

    public bool hasFocus;

    Ray ray;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // makes the shape follow the mouse
        // TODO needs boundaries
        // TODO angle shapes either before or after placing them
	    if(hasFocus){
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 newVec = ray.origin;
            newVec.z = 0;
            gameObject.transform.position = newVec;

            if(Input.GetMouseButtonDown(0)){
                hasFocus = false;
				Destroy (this);
            }
        }
	}
}
