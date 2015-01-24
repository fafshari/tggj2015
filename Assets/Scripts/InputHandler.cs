using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {
	void OnEnable () {
		FingerGestures.OnTap += OnTap;
	}
	void OnDisable () {
		FingerGestures.OnTap -= OnTap;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTap(Vector2 fingerPos)
	{
		StateManager.GetInstance ().mState.OnTap (fingerPos);
	}
}
