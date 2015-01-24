using UnityEngine;
using System.Collections;

public class RickRollCameraController : MonoBehaviour {
	public Rick _rick;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = _rick.transform.position;
		transform.Translate (Vector3.forward * -10);
	}
}
