using UnityEngine;
using System.Collections;

public class SlowTimeState : GameState
{

		private int numJeffs, numBobs, numSteves, numSpeedyPeteys, numSamanthas;
		private bool showGUI;
		private Rick rick;
	private Moveable currentMovable;

	public float initialXPan = 0F;
	public float initialYPan = 0F;
	public float maxPan = 5F;
	public float minPan = -5F;

		// Use this for initialization
		void Awake ()
		{
				numJeffs = StateManager.GetInstance ().numJeffs;
				numBobs = StateManager.GetInstance ().numBobs;
				numSteves = StateManager.GetInstance ().numSteves;
				numSpeedyPeteys = StateManager.GetInstance ().numSpeedyPeteys;
				numSamanthas = StateManager.GetInstance ().numSamanthas;
				showGUI = true; //can't decide if GUI should show right away or not

				GameObject obj = GameObject.FindGameObjectWithTag ("Rick");
				rick = (Rick)obj.GetComponent (typeof(Rick));
				print ("happens");
		}
	
		// Update is called once per frame
		public override void StateUpdate ()
		{
	    
#if UNITY_EDITOR
				if (Input.GetButtonDown ("BuildMode")) {
						StateManager.GetInstance ().SetState (typeof(NormalTimeState));
				}
			if (Input.GetMouseButtonDown (1) && !showGUI) {
				print (showGUI);
				showGUI = true;
			} else if (Input.GetMouseButtonDown (1) && showGUI) {
				showGUI = false;
			}
#endif


		}

		public override void OnEnterState ()
		{
		initialXPan = Camera.main.transform.position.x;
		initialYPan = Camera.main.transform.position.y;
			Time.timeScale = 0f;
			Time.fixedDeltaTime = 0f;
			//Time.fixedDeltaTime = 0.02f * 0.02f;
			rick.inSlow = true;
		Camera.main.GetComponent<RickRollCameraController> ()._follow = false;
			print ("yo");

		FingerGestures.OnDragMove += HandleOnDragMove;

		}

		void HandleOnDragMove (Vector2 fingerPos, Vector2 delta)
		{
			delta *= -0.03f;
			if (currentMovable == null) {
				float newX = Camera.main.transform.position.x + delta.x;
			float newY = Camera.main.transform.position.y + delta.y;
			newX = Mathf.Clamp(newX, initialXPan - maxPan, initialXPan + maxPan);
			newY = Mathf.Clamp(newY, initialYPan - maxPan, initialYPan + maxPan);
			Camera.main.transform.position = new Vector3(newX, newY, Camera.main.transform.position.z);
			}

		}

		public override void OnLeaveState ()
		{
				rick.inSlow = false;
				if (currentMovable != null) {
						Destroy (currentMovable.gameObject);
				}
		
		Camera.main.GetComponent<RickRollCameraController> ()._follow = true;
			Time.timeScale = 1f;
			Time.fixedDeltaTime = 1f;
		FingerGestures.OnDragMove -= HandleOnDragMove;
		}

		public override void OnStateGUI ()
		{
				float x = 0.1f * Screen.width;
				float y = 0.85f * Screen.height;
				float w = 0.1f * Screen.width;
				float h = 0.1f * Screen.height;
		float mpadding = 0.01f * Screen.width;
				if (showGUI) {


		

			
		if(currentMovable == null)
			{
				if (GUI.Button (new Rect (x, y, w, h), "Back")) {
					StateManager.GetInstance ().SetState (typeof(NormalTimeState));
				}
				if (GUI.Button (new Rect (x += w + mpadding, y, w, h), "Jeff")) {
								if (numJeffs > 0) {
										GameObject go = (GameObject)Instantiate (Resources.Load ("Jeff", typeof(GameObject)));
										go.transform.position = new Vector3 (0, 0, 0);
										numJeffs--;
										currentMovable = go.GetComponent<Moveable> ();
										currentMovable.hasFocus = true;
								}
						}
			
		
				if (GUI.Button (new Rect (x += w + mpadding, y , w, h), "Steve")) {
								if (numSteves > 0) {
										GameObject go = (GameObject)Instantiate (Resources.Load ("Steve", typeof(GameObject)));
										go.transform.position = new Vector3 (0, 0, 0);
										numSteves--;
										currentMovable = go.GetComponent<Moveable> ();
										currentMovable.hasFocus = true;
								}
						}
				if (GUI.Button(new Rect(x += w + mpadding,y,w,h), "Bob")) {
                if(numBobs > 0){
			        GameObject go = (GameObject)Instantiate(Resources.Load("Bob", typeof(GameObject)));
//					BoxCollider2D bc2d = (BoxCollider2D)go.GetComponent<BoxCollider2D>();
//					bc2d.enabled = false;
                    go.transform.position = new Vector3(0,0,0);
                    numBobs--;
					currentMovable = go.GetComponent<Moveable>();
					currentMovable.hasFocus = true;
                }
		    }
			
				if (GUI.Button (new Rect (x += w + mpadding, y, w, h), "Samantha")) {
								if (numSamanthas > 0) {
										GameObject go = (GameObject)Instantiate (Resources.Load ("Samantha", typeof(GameObject)));
										go.transform.position = new Vector3 (0, 0, 0);
										numSamanthas--;
										currentMovable = go.GetComponent<Moveable> ();
										currentMovable.hasFocus = true;
								}
						}

				if (GUI.Button (new Rect (x += w + mpadding, y, w, h), "Speedy Petey")) {
								if (numSpeedyPeteys > 0) {
										GameObject go = (GameObject)Instantiate (Resources.Load ("SpeedyPetey", typeof(GameObject)));
										go.transform.position = new Vector3 (0, 0, 0);
										numSamanthas--;
										currentMovable = go.GetComponent<Moveable> ();
										currentMovable.hasFocus = true;

								}
						}
			}
			else {
				#if UNITY_EDITOR
				#else
				float padding = 10f;
				if (GUI.Button (new Rect (Screen.width - w, Screen.height - h, w, h), "OK")) {
					currentMovable.hasFocus = false;
					showGUI = true;
					currentMovable = null;
				}
				if(GUI.Button(new Rect(Screen.width - w * 2 - padding, Screen.height - h, w, h), "CANCEL"))
				{
					currentMovable.hasFocus = false;
					GameObject.Destroy(currentMovable.gameObject);
					showGUI = true;
					currentMovable = null;
				}
				#endif
			}
				} 

	}
}
