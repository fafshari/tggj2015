using UnityEngine;
using System.Collections;

public class SlowTimeState : GameState {

    private int numJeffs,numBobs,numSteves,numSpeedyPeteys,numSamanthas;
    private bool showGUI;

    private Rick rick;

	// Use this for initialization
	void Start () {
	    numJeffs = StateManager.GetInstance().numJeffs;
        numBobs = StateManager.GetInstance().numBobs;
        numSteves = StateManager.GetInstance().numSteves;
        numSpeedyPeteys = StateManager.GetInstance().numSpeedyPeteys;
        numSamanthas = StateManager.GetInstance().numSamanthas;
        showGUI = true; //can't decide if GUI should show right away or not

        GameObject obj = GameObject.FindGameObjectWithTag("Rick");
		rick = (Rick)obj.GetComponent(typeof(Rick));
	}
	
	// Update is called once per frame
	public override void StateUpdate () {
	    

        if(Input.GetButtonDown("BuildMode")){
            StateManager.GetInstance().SetState(typeof(NormalTimeState));
        }

        if(Input.GetMouseButtonDown(1) && !showGUI){
            print(showGUI);
            showGUI = true;
        }
        else if(Input.GetMouseButtonDown(1) && showGUI){
            showGUI = false;
        }

	}

    public override void OnEnterState(){
        Time.timeScale = 0.02f;
        Time.fixedDeltaTime = 0.02f * 0.02f;
    }

    public override void OnLeaveState(){

    }

    public override void OnStateGUI(){

        if(showGUI){

            float x = 0.42f * Screen.width;
		    float y = 0.1f * Screen.height;
		    float w = 0.2f * Screen.width;
		    float h = 0.1f * Screen.height;
		
		    if (GUI.Button(new Rect(x,y,w,h), "Back")){
                StateManager.GetInstance().SetState(typeof(NormalTimeState));
            }
			
		
		    if (GUI.Button(new Rect(x,y+=0.15f * Screen.height,w,h), "Jeff")) {
                if(numJeffs > 0){
                    GameObject go = (GameObject)Instantiate(Resources.Load("Jeff", typeof(GameObject)));
                    go.transform.position = new Vector3(0,0,0);
                    numJeffs--;
                    showGUI = false;
                    go.GetComponent<Moveable>().hasFocus = true;
                }
		    }
		
		    if (GUI.Button(new Rect(x,y+=0.15f * Screen.height,w,h), "Steve")) {
                if(numSteves > 0){
			        GameObject go = (GameObject)Instantiate(Resources.Load("Steve", typeof(GameObject)));
                    go.transform.position = new Vector3(0,0,0);
                    numSteves--;
                    showGUI = false;
                    go.GetComponent<Moveable>().hasFocus = true;
                }
		    }
			
		    if (GUI.Button(new Rect(x,y+=0.15f * Screen.height,w,h), "Bob")) {
                if(numBobs > 0){
			        GameObject go = (GameObject)Instantiate(Resources.Load("Bob", typeof(GameObject)));
                    go.transform.position = new Vector3(0,0,0);
                    numBobs--;
                    showGUI = false;
                    go.GetComponent<Moveable>().hasFocus = true;
                }
		    }
			
		    if (GUI.Button(new Rect(x,y+=0.15f * Screen.height,w,h), "Samantha")) {
                if(numSamanthas > 0){
			        GameObject go = (GameObject)Instantiate(Resources.Load("Samantha", typeof(GameObject)));
                    go.transform.position = new Vector3(0,0,0);
                    numSamanthas--;
                    showGUI = false;
                    go.GetComponent<Moveable>().hasFocus = true;
                }
		    }
        }
    }
}
