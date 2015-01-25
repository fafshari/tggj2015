using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour {

    public bool hasFocus;
	private bool _dragging;
    Ray ray;

	// Use this for initialization
	void Start () {
	
	}

	void OnEnable()
	{
		FingerGestures.OnDragBegin += HandleOnDragBegin;
		FingerGestures.OnDragMove += HandleOnDragMove;
		FingerGestures.OnDragEnd += HandleOnDragEnd;
	}

	void OnDisable()
	{
		FingerGestures.OnDragBegin -= HandleOnDragBegin;
		FingerGestures.OnDragMove -= HandleOnDragMove;
		FingerGestures.OnDragEnd -= HandleOnDragEnd;
	}

	void HandleOnDragEnd (Vector2 fingerPos)
	{
		_dragging = false;
	}

	void HandleOnDragMove (Vector2 fingerPos, Vector2 delta)
	{
		if (hasFocus && _dragging) {
			ray = Camera.main.ScreenPointToRay(fingerPos);
			Vector3 newVec = ray.origin;
			newVec.z = 0;
			gameObject.transform.position = newVec;
		}
	}

	void HandleOnDragBegin (Vector2 fingerPos, Vector2 startPos)
	{
		if (hasFocus) {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if(hit.collider.gameObject == this.gameObject)
			{
				_dragging = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
        // makes the shape follow the mouse
        // TODO needs boundaries
        // TODO angle shapes either before or after placing them

        
	}
}
