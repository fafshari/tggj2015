using UnityEngine;
using System.Collections;

public class RickRollCameraController : MonoBehaviour {
	public Rick _rick;
	public bool _follow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				if (_follow) {
						transform.position = _rick.transform.position;
						transform.Translate (Vector3.forward * -10);
				}
		}
}
