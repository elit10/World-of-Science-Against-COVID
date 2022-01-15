using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CustomCharacterController : MonoBehaviour
{
    private Vector3 startPos;
    public Vector3 currentPos;
    public float targetXPos = 0f;
    public float targetYPos = 0f;
    public int lineCount = 3;
    public int curLine;
    public float precision = 1f;
    public float platformRange = 2f;

    private float startVel;
    public float velocity;
    private Rigidbody rB;
    public bool isJumping;
    public float jumpDuration;

    public float newTarget;


    public float scaleVal
	{
		get
		{
            return transform.localScale.x;
		}

		set
		{
            transform.DOBlendableScaleBy(new Vector3(value,value,value), 1);
		}
	}

    private bool _isWalking;
    public bool isWalking 
    {
		get
		{
            return _isWalking;
		}
        
        set
		{
            if(!value)
			{
                velocity = 0;
				LevelManager.instance.Fail();
            }
			if (value) 
            {
                velocity = startVel;
                isListening = true;
				curLine = 0;
            }

            _isWalking = value;
		}
    
    }
    public bool isListening = true;

    #region Singleton
    public static CustomCharacterController instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            rB = GetComponent<Rigidbody>();
            
        }
    }
	#endregion

	private void Start()
	{
        startVel = velocity;
        currentPos = transform.position;
        isListening = true;

        startPos = transform.position;
        
    }

	void Update()
	{
        if(isWalking && isListening)
		{
            ListenInputs();
            SetPosition();
        }

    }


    public void Jump()
	{
        isJumping = true;
        StartCoroutine("JumpAnim");
	}
    IEnumerator JumpAnim()
	{
        Debug.Log("started");
        float alpha = 0;
        while(isJumping)
		{
            float radian = Mathf.Deg2Rad * alpha;
            currentPos.y = Mathf.Sin(radian) * 3;
            alpha += 300 * Time.deltaTime / jumpDuration;
            if(alpha > 180)
			{
                currentPos.y = 0;


                isJumping = false;
			}
            
            
            yield return null;
		}
        
        yield return null;
	}

    private void ListenInputs()
    {
        //targetXPos = currentPos.x + InputManager.instance.input.x * precision;

        targetYPos = InputManager.instance.input.y;


        if(SwipeManager.swipeRight)
		{
            curLine++; 
		}
        if(SwipeManager.swipeLeft)
		{
            curLine--;
		}

    }



    private void SetPosition()
    {
        targetXPos = curLine * platformRange;

        if (SwipeManager.swipeUp)
        {
            Jump();
            targetYPos = 0;
        }


        curLine = Mathf.Clamp(curLine, -(lineCount - 1) / 2, (lineCount - 1) / 2);
        currentPos.x = Mathf.Lerp(currentPos.x, targetXPos, Time.deltaTime * 5f);
        currentPos += Vector3.forward * Time.deltaTime * velocity;
        transform.position = Vector3.Lerp(transform.position,currentPos,Time.deltaTime * 10);
        
    }

    IEnumerator Rotate(float value)
    {
		gameObject.transform.eulerAngles = new Vector3(0, value, 0);
		yield return new WaitForSeconds(.3f);
		gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
		yield return null;
    }


    public void ResetLevel()
	{
        transform.position = startPos;
        currentPos = startPos;

        transform.localScale = new Vector3(1, 1, 1);
        ParticleController.instance.PlayParticle(ParticleController.instance.winParticles, false);
    }

    IEnumerator Damage(float val)
	{
        isListening = false;
        currentPos = currentPos + Vector3.back * val;

        float time = 0;

        while(!isListening && time < 2f)
		{
            transform.position = Vector3.Lerp(transform.position, currentPos, Time.deltaTime * 10);
            time += Time.deltaTime;
            yield return null;
        }
        time = 0;
        Debug.Log("waited");
        isListening = true;


	}


}
