using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class StateManager : MonoBehaviour {
	
	private static StateManager instance;
	
	private StateManager(){}
	
	private static StateManager Instance{
		get{
			if(instance == null){
				GameObject obj = GameObject.FindGameObjectWithTag("GameManager");
				instance = (StateManager) obj.GetComponent(typeof(StateManager));
			}
			return instance;
		}
	}
	
	public static StateManager GetInstance(){
		return Instance;
	}
	
	public GameState mState;
	public GameState mPreviousState;
	
	public float x,y,w,h;

    // As long as each level is its own scene, each level will have a different amount
    public int numJeffs,numBobs,numSteves,numSpeedyPeteys,numSamanthas;
	
	// Use this for initialization
	void Awake () {
		mState = (NormalTimeState)gameObject.AddComponent(typeof(NormalTimeState));
		mState.OnEnterState();
		
	}
	
	void OnGUI(){
		
		//GUI.TextField(new Rect(x * Screen.width,y * Screen.height,w * Screen.width,h * Screen.height), "Myriad Arrows");
		
		mState.OnStateGUI();
	}
	
	void Update () {
		mState.StateUpdate();
	}
	
	public void SetState(System.Type cs){
		
		mPreviousState = mState;
		mState.OnLeaveState();
		
		if(cs.Equals(typeof(NormalTimeState))){
			if(gameObject.GetComponent(typeof(NormalTimeState)) != null){
				mState = (NormalTimeState)gameObject.GetComponent(typeof(NormalTimeState));	
			}
			else{
				mState = (NormalTimeState)gameObject.AddComponent(typeof(NormalTimeState));
			}
		}
		else if(cs.Equals(typeof(SlowTimeState))){
			if(gameObject.GetComponent(typeof(SlowTimeState)) != null){
				mState = (SlowTimeState)gameObject.GetComponent(typeof(SlowTimeState));
			}
			else{
				mState = (SlowTimeState)gameObject.AddComponent(typeof(SlowTimeState));
			}
		}
        else if(cs.Equals(typeof(MoveFriendState))){
            if(gameObject.GetComponent(typeof(MoveFriendState)) != null){
				mState = (MoveFriendState)gameObject.GetComponent(typeof(MoveFriendState));
			}
			else{
				mState = (MoveFriendState)gameObject.AddComponent(typeof(MoveFriendState));
			}
        }
		
		
		
		mState.OnEnterState();
	}
}
