using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public static bool canMove;
	Vector3 moveDirection;
	public float moveSpeed = 8;
	public float jumpSpeed = 15;
	public float gravity = 20;
	public GameObject playerModel;
	public Animator animator;

	public static bool dashCasted;
	public static bool restart;
	public static bool pullCasted;
	public static bool speedUpCasted;
	public static bool blindCasted;
	private int initJump;
	public float pullTimer;

	public GameObject pullBackEffect;

	private float speedUpTimer;
	
	public float canMoveTimer;
	// Use this for initialization
	void Start () {
		playerModel = GameObject.FindGameObjectWithTag("playerSprite");
		animator = playerModel.GetComponent<Animator>();
		pullBackEffect = GameObject.Find("PullBackEffect");
		pullBackEffect.SetActive(false);
		speedUpTimer = 4;
		pullTimer = 0.75f;
		canMove = true;
		gravity = 20;
		canMoveTimer = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 7, gameObject.transform.position.z - 150);
		CharacterController controller = GetComponent<CharacterController> ();


		if(dashCasted)
		{
			pullTimer -= Time.deltaTime;
			gameObject.transform.position += new Vector3(Time.deltaTime * 15, Time.deltaTime * 3.5f, 0);
			if(pullTimer <= 0)
			{
				pullTimer = 0.75f;
				dashCasted = false;
			}
		}

		if(pullCasted)
		{
			pullBackEffect.SetActive(true);
			pullTimer -= Time.deltaTime;
			gameObject.transform.position -= new Vector3(Time.deltaTime * 40, -Time.deltaTime * 3.5f, 0);
			if(pullTimer <= 0)
			{
				pullBackEffect.SetActive(false);
				pullTimer = 0.75f;
				pullCasted = false;
			}
		}

		if(speedUpCasted)
		{
			moveSpeed = 12;
			speedUpTimer -= Time.deltaTime;

			if(speedUpTimer <= 0)
			{
				moveSpeed = 8;
				speedUpCasted = false;
				speedUpTimer = 4;
			}
		}

		if(blindCasted)
		{
			GameObject.Find("BlindEffect").renderer.enabled = true;
			speedUpTimer -= Time.deltaTime;
			if(speedUpTimer <= 0)
			{
				GameObject.Find("BlindEffect").renderer.enabled = false;
				blindCasted = false;
				speedUpTimer = 4;
			}
		}


		if(canMove)
		{
			if (controller.isGrounded) 
			{
				if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
				{
					moveDirection = new Vector3(1, 0, 0);
				}
				else
				{
					moveDirection = new Vector3(1, 0, 0);
				}


				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= moveSpeed;
				
				if (Input.GetButton ("Jump") || initJump == 2) {
					moveDirection.y = jumpSpeed;
					animator.CrossFade("Dog_Jump", 1, 0, 1 );
				}
			}
			else
			{
				moveDirection.x = 1;
				moveDirection.x *= moveSpeed;

				if(Input.GetButtonUp ("Jump") || initJump == 1)
				{
					moveDirection.y = 1;
					animator.CrossFade("Dog_Run", 0, 0, 1 );
					initJump = 0;
				}
			}

			// Apply gravity
			moveDirection.y -= gravity * Time.deltaTime;
			
			// Move the controller
			controller.Move(moveDirection * Time.deltaTime);
		}
		else
		{
			canMoveTimer -= Time.deltaTime;
			if(canMoveTimer <= 0)
			{
				canMoveTimer = 3;
				canMove = true;
			}
		}

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit ;
		if(Input.GetMouseButton(0))
		{
			if (Physics.Raycast (ray, out hit)) {
				if(hit.transform.name == "ButtonJump")
				{
					initJump = 2;
				}
			}
		}

		if(Input.GetMouseButtonUp(0))
		{
			if (Physics.Raycast (ray, out hit)) {
				if(hit.transform.name == "ButtonJump")
				{
					initJump = 1;
				}

				if(hit.transform.name == "uiHome")
				{
					Application.LoadLevel(0);
				}
			}
		}
	}
}


