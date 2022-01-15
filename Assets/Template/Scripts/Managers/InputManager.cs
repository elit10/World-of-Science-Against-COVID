using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PointerEventData eventData;

    #region Singleton
    public static InputManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
	#endregion



	//comment this part and uncomment the target segment



	public void OnPointerDown(PointerEventData _eventData) { }
	public void OnPointerUp(PointerEventData _eventData) { }

	//                  /||\
	//                //||||\\
	//              //||||||||\\
	//            //--||||||||--\\
	//          //----||||||||----\\
	//        //------||||||||-------\\
	//      //--------||||||||---------\\
	//    //----------||||||||-----------\\
	//  //------------||||||||-------------\\
	////--------------||||||||---------------\\


	#region ContinousInput
	////if we need to input as X, Y continuously, uncomment this block


	private Vector2 startPos;
	private Vector2 delta;
	public Vector2 change;
	public Vector2 input;
	public float maxDistance = 100f; // Change this to according the desired precision 

	//public void OnPointerDown(PointerEventData _eventData)
	//{
	//	eventData = _eventData;
	//	startPos = eventData.position;
	//}

	//public void OnPointerUp(PointerEventData _eventData)
	//{
	//	eventData = null;
	//	delta = Vector2.zero;
	//	startPos = Vector2.zero;
	//	input = Vector2.zero;
	//}


	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			startPos.x = Input.mousePosition.x;
			startPos.y = Input.mousePosition.y;
		}

		if(Input.GetMouseButton(0))
		{
			StartCoroutine(Change());
		}

		if(Input.GetMouseButtonUp(0))
		{
			delta = Vector2.zero;
			startPos = Vector2.zero;
			input = Vector2.zero;
			change = Vector2.zero;
		}

		if (startPos == Vector2.zero) return;


		Vector2 mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		delta = mouse - startPos;

		delta.x = Mathf.Clamp(delta.x, -maxDistance, maxDistance);
		delta.y = Mathf.Clamp(delta.y, -maxDistance, maxDistance);
		input = delta / maxDistance;

		

		//if (eventData == null) return;
		//delta = eventData.position - startPos;
		//delta.x = Mathf.Clamp(delta.x, -maxDistance, maxDistance);
		//delta.y = Mathf.Clamp(delta.y, -maxDistance, maxDistance);
		//input = delta / maxDistance;

		//Debug.Log(input);
	}

	IEnumerator Change()
	{
		
		Vector2 startPos = input;
		yield return null;

		if(input != Vector2.zero)
		{
			change = input - startPos;
		}

	}



	#endregion

	#region RaycastToPoint
	//private Vector2 target;
	//public RaycastHit hit;
	//public void OnPointerDown(PointerEventData _eventData)
	//{
	//	eventData = _eventData;
	//	target = eventData.position;
	//}

	//public void OnPointerUp(PointerEventData _eventData)
	//{
	//	eventData = null;
	//}

	//private void FixedUpdate()
	//{
	//	if (eventData == null) return;

	//	Ray ray = CameraManager.instance.cam.ScreenPointToRay(target); ;


	//	Physics.Raycast(ray, out hit);

	//}
	#endregion
}
