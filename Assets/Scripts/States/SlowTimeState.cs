using UnityEngine;
using System.Collections;

public class SlowTimeState : GameState
{

		private int numJeffs, numBobs, numSteves, numSpeedyPeteys, numSamanthas;
		private bool showGUI;
		private Rick rick;
		private Moveable currentMovable;

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
	    

				if (Input.GetButtonDown ("BuildMode")) {
						StateManager.GetInstance ().SetState (typeof(NormalTimeState));
				}

				if (Input.GetMouseButtonDown (1) && !showGUI) {
						print (showGUI);
						showGUI = true;
				} else if (Input.GetMouseButtonDown (1) && showGUI) {
						showGUI = false;
				}

		}

		public override void OnEnterState ()
		{
				Time.timeScale = 0.02f;
				Time.fixedDeltaTime = 0.02f * 0.02f;
				rick.inSlow = true;
				print ("yo");
		}

		public override void OnLeaveState ()
		{
				rick.inSlow = false;
				if (currentMovable != null) {
						Destroy (currentMovable.gameObject);
				}
		}

		public override void OnStateGUI ()
		{
				float x = 0.42f * Screen.width;
				float y = 0.1f * Screen.height;
				float w = 0.2f * Screen.width;
				float h = 0.1f * Screen.height;

				if (showGUI) {


		
						if (GUI.Button (new Rect (x, y, w, h), "Back")) {
								StateManager.GetInstance ().SetState (typeof(NormalTimeState));
						}
			
		
						if (GUI.Button (new Rect (x, y += 0.15f * Screen.height, w, h), "Jeff")) {
								if (numJeffs > 0) {
										GameObject go = (GameObject)Instantiate (Resources.Load ("Jeff", typeof(GameObject)));
										go.transform.position = new Vector3 (0, 0, 0);
										numJeffs--;
										showGUI = false;
										currentMovable = go.GetComponent<Moveable> ();
										currentMovable.hasFocus = true;
								}
						}
		
						if (GUI.Button (new Rect (x, y += 0.15f * Screen.height, w, h), "Steve")) {
								if (numSteves > 0) {
										GameObject go = (GameObject)Instantiate (Resources.Load ("Steve", typeof(GameObject)));
										go.transform.position = new Vector3 (0, 0, 0);
										numSteves--;
										showGUI = false;
										currentMovable = go.GetComponent<Moveable> ();
										currentMovable.hasFocus = true;
								}
						}
						if (GUI.Button (new Rect (x, y += 0.15f * Screen.height, w, h), "Bob")) {
								if (numBobs > 0) {
										GameObject go = (GameObject)Instantiate (Resources.Load ("Bob", typeof(GameObject)));
										go.transform.position = new Vector3 (0, 0, 0);
										numBobs--;
										showGUI = false;
										currentMovable = go.GetComponent<Moveable> ();
										currentMovable.hasFocus = true;
								}
						}
		    if (GUI.Button(new Rect(x,y+=0.15f * Screen.height,w,h), "Bob")) {
                if(numBobs > 0){
			        GameObject go = (GameObject)Instantiate(Resources.Load("Bob", typeof(GameObject)));
					BoxCollider2D bc2d = (BoxCollider2D)go.GetComponent<BoxCollider2D>();
					bc2d.enabled = false;
                    go.transform.position = new Vector3(0,0,0);
                    numBobs--;
					showGUI = false;
					currentMovable = go.GetComponent<Moveable>();
					currentMovable.hasFocus = true;
                }
		    }
			
						if (GUI.Button (new Rect (x, y += 0.15f * Screen.height, w, h), "Samantha")) {
								if (numSamanthas > 0) {
										GameObject go = (GameObject)Instantiate (Resources.Load ("Samantha", typeof(GameObject)));
										go.transform.position = new Vector3 (0, 0, 0);
										numSamanthas--;
										showGUI = false;
										currentMovable = go.GetComponent<Moveable> ();
										currentMovable.hasFocus = true;
								}
						}

						if (GUI.Button (new Rect (x, y += 0.15f * Screen.height, w, h), "Speedy Petey")) {
								if (numSpeedyPeteys > 0) {
										GameObject go = (GameObject)Instantiate (Resources.Load ("SpeedyPetey", typeof(GameObject)));
										go.transform.position = new Vector3 (0, 0, 0);
										numSamanthas--;
										showGUI = false;
										currentMovable = go.GetComponent<Moveable> ();
										currentMovable.hasFocus = true;

								}
						}
				} 
		else {
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
		}
	}
}
