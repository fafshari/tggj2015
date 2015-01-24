using UnityEngine;
using System.Collections;

public abstract class State : MonoBehaviour {


	
	public abstract void OnEnterState();
	public abstract void OnLeaveState();
	public abstract void OnStateGUI();
}
