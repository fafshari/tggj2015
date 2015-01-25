using UnityEngine;
using System.Collections;

public class WinState : GameState {
	public Rick rick;
	// Use this for initialization
	void Awake () {
		GameObject obj = GameObject.FindGameObjectWithTag("Rick");
		rick = (Rick)obj.GetComponent(typeof(Rick));
	}
	
	public override void StateUpdate () {
        
	}

    public override void OnEnterState(){
		rick.rigidbody2D.isKinematic = true;
		rick.rigidbody2D.velocity = Vector2.zero;
    }

    public override void OnLeaveState(){

    }

    public override void OnStateGUI(){
			
			float x = 0.42f * Screen.width;
			float y = 0.1f * Screen.height;
			float w = 0.2f * Screen.width;
			float h = 0.1f * Screen.height;
			
			if (GUI.Button(new Rect(x,y,w,h), "Next Level")){

			}
			if (GUI.Button(new Rect(x,y+=0.15f * Screen.height,w,h), "Restart Level")) {
				Application.LoadLevel(StateManager.GetInstance().levelNum);
			}
			if (GUI.Button(new Rect(x,y+=0.15f * Screen.height,w,h), "Quit")) {
				Application.Quit();
			}
			
		
    }
}
