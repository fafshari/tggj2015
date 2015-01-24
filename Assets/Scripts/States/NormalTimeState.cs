using UnityEngine;
using System.Collections;

public class NormalTimeState : GameState {

    private Rick rick;

	// Use this for initialization
	void Awake () {
	    GameObject obj = GameObject.FindGameObjectWithTag("Rick");
		rick = (Rick)obj.GetComponent(typeof(Rick));
	}
	
	// Update is called once per frame
	public override void StateUpdate () {
        
        if(Input.GetButtonDown("BuildMode")){
            StateManager.GetInstance().SetState(typeof(SlowTimeState));
        }
	}

    public override void OnEnterState(){
        //rick.enabled = true;  //for coming back from a paused state
        Time.timeScale = 1.0f;
    }

    public override void OnLeaveState(){

    }

    public override void OnStateGUI(){

    }
}
