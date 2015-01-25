using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour {

    private bool _hasFocus;
	public bool hasFocus {
				get{ return _hasFocus; }
				set {
						_hasFocus = value;
						if (_hasFocus)
								this.gameObject.layer = LayerMask.NameToLayer ("BuildMode");
						else
								this.gameObject.layer = LayerMask.NameToLayer ("Placed");
				}
		}
	private bool _dragging;
	private bool _rotating;
    Ray ray;

	// Use this for initialization
	void Start () {
	
	}

	void OnEnable()
	{
		FingerGestures.OnDragBegin += HandleOnDragBegin;
		FingerGestures.OnDragMove += HandleOnDragMove;
		FingerGestures.OnRotationMove += HandleOnRotationMove;
	}

	void HandleOnDragBegin (Vector2 fingerPos, Vector2 startPos)
	{
		if (hasFocus)
						lastVec = Vector3.zero;
	}


	void HandleOnRotationMove (Vector2 fingerPos1, Vector2 fingerPos2, float rotationAngleDelta)
	{
		if (hasFocus) {
			this.transform.Rotate(new Vector3(0,0,rotationAngleDelta));
			}
	}

	void OnDisable()
	{
		FingerGestures.OnDragBegin -= HandleOnDragBegin;
		FingerGestures.OnDragMove -= HandleOnDragMove;
		FingerGestures.OnRotationMove -= HandleOnRotationMove;
	}

	Vector3 lastVec = Vector3.zero;
	void HandleOnDragMove (Vector2 fingerPos, Vector2 delta)
	{
		if (hasFocus) {
			ray = Camera.main.ScreenPointToRay(fingerPos);
			Vector3 currentVec = ray.origin;
			Vector3 newVec = Vector3.zero;
			if(lastVec == Vector3.zero)
			{
				lastVec = currentVec;
				return;
			}
			else
			{
				newVec = currentVec - lastVec;
				lastVec = currentVec;
			}

			newVec.z = 0;
			gameObject.transform.position = new Vector3(newVec.x + gameObject.transform.position.x, gameObject.transform.position.y + newVec.y,0);
		}
	}

	public string mGUITEXT = "0";
	void OnGUI()
	{
		if (hasFocus) {
			GUI.Label(new Rect(0,0,300,50), mGUITEXT);
				}
	}


	
	// Update is called once per frame
	void Update () {
        // makes the shape follow the mouse
        // TODO needs boundaries
        // TODO angle shapes either before or after placing them
#if UNITY_EDITOR
	    if(hasFocus){
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 newVec = ray.origin;
            newVec.z = 0;
            gameObject.transform.position = newVec;

            if(Input.GetMouseButtonDown(0)){
                hasFocus = false;
                if(gameObject.tag == "Bob" || gameObject.tag == "Jeff" || gameObject.tag == "SpeedyPetey"){
				    BoxCollider2D bc2d = (BoxCollider2D)GetComponent<BoxCollider2D>();
				    bc2d.enabled = true;
				    Destroy (this);
                }
                else if(gameObject.tag == "Steve" || gameObject.tag == "Samantha"){
                    PolygonCollider2D pc2d = (PolygonCollider2D)GetComponent<PolygonCollider2D>();
                    pc2d.enabled = true;
                    Destroy(this);
                }
                
            }
        }
#endif
	}
}
