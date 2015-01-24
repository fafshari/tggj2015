using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {
	
	private enum SwipeDirection{
		UP,
		DOWN,
		LEFT,
		RIGHT,
		NOSWIPE
	}
	
	private static SwipeDirection _swipeDirection = SwipeDirection.NOSWIPE;

	private static InputHandler instance;

    private InputHandler () {} 
	

    private static InputHandler Instance 

    {

        get 

            {

            if (instance == null) 

                {

               

                GameObject notificationObject = new GameObject("Singleton InputHandler");

				
                instance = (InputHandler) notificationObject.AddComponent(typeof(InputHandler));

                }

            return instance;

            }

    }


    public static InputHandler GetInstance()

    {

        return Instance;

    }
	
	public static bool GetInputDown(){
		GetInstance();
#if UNITY_EDITOR
		return Input.GetMouseButtonDown(0);	
#endif		
#if UNITY_IPHONE
		return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
#endif
	}
	
	public static bool GetInputUp(){
		GetInstance();
#if UNITY_EDITOR
		return Input.GetMouseButtonUp(0);
#endif		
#if UNITY_IPHONE
		return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;
#endif
	
	}
	
	public static bool GetInput(){
		GetInstance();
#if UNITY_EDITOR
		return Input.GetMouseButton(0);
#endif		
#if UNITY_IPHONE
		return Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary);
#endif
		
	}
	
	public static Vector2 GetInputPosition(){
		GetInstance();
#if UNITY_EDITOR
		return new Vector2(Input.mousePosition.x, (Screen.height - Input.mousePosition.y)); 
#endif		
#if UNITY_IPHONE
		return new Vector2(Input.GetTouch(0).position.x, (Screen.height - Input.GetTouch(0).position.y)); 	
#endif
		
		
	}
	
	public static Vector2 GetInputPosition(Vector2 originalPos){
		GetInstance();
		return new Vector2(originalPos.x, (Screen.height - originalPos.y)); 
	}
}
	