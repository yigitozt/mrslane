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
	// Use this for initialization
	void Start () {
		canMove = true;
		playerModel = GameObject.FindGameObjectWithTag("playerSprite");
		animator = playerModel.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z - 150);
		CharacterController controller = GetComponent<CharacterController> ();

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
				
				if (Input.GetButton ("Jump") || Input.touchCount > 0) {
					moveDirection.y = jumpSpeed;
					animator.CrossFade("Dog_Jump", 1, 0, 1 );
				}
			}
			else
			{
				moveDirection.x = 1;
				moveDirection.x *= moveSpeed;

				if(Input.GetButtonUp ("Jump"))
				{
					moveDirection.y = 1;
					animator.CrossFade("Dog_Run", 0, 0, 1 );

				}
			}

			// Apply gravity
			moveDirection.y -= gravity * Time.deltaTime;
			
			// Move the controller
			controller.Move(moveDirection * Time.deltaTime);
		}

	}
}
