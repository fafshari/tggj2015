using UnityEngine;
using System.Collections;

public abstract class GameState : MonoBehaviour {

	public abstract void OnEnterState();
	public abstract void OnLeaveState();
	public abstract void OnStateGUI();
	
	public virtual void StateUpdate(){}
}
