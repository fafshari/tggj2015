using UnityEngine;
using System.Collections;

public class SlowTimeState : GameState {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public override void StateUpdate () {
	    Time.timeScale = 0.1f;

        if(Input.GetButtonDown("BuildMode")){
            StateManager.GetInstance().SetState(typeof(NormalTimeState));
        }
	}

    public override void OnEnterState(){
        print("Slow time");
    }

    public override void OnLeaveState(){

    }

    public override void OnStateGUI(){

    }
}
