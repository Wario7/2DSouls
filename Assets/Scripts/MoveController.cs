using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

	public float speed = 6f;
	public float jumpHeight = 700f;
	public Transform leftFoot;
	public Transform rightFoot;
	public float circleRadius = 0.2f;
	public LayerMask whatIsGround;
	public bool canMove = true;
//	public bool beingReflected = false;
	public bool onGround = true;
	
	public float notMovingRate;
	private float nextMove;
	
	public bool facingRight = true;
	Vector2 movement;
//	Animator anim;
	Rigidbody2D playerRigidbody;

	AttackController attackController;
	
	void Start () {
//		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody2D> ();
		attackController = GetComponent<AttackController>();
	}
	
	void FixedUpdate() //deals with physics update
	{
		float h = Input.GetAxisRaw ("Horizontal"); 
		//Edit -> Project Settings -> Input
		//Horizontal = a and d buttons
		float v = Input.GetAxisRaw ("Vertical");
		onGround = Physics2D.OverlapCircle(leftFoot.position, circleRadius, whatIsGround) ||
				   Physics2D.OverlapCircle(rightFoot.position, circleRadius, whatIsGround);
		if (canMove)
			Move (h, v);
		if (onGround && !attackController.engagedIntoBattle) { //TODO: and is not in attack animation..
			canMove = true;
		} else {
			canMove = false;
		}
		Animating (h, v);
	}
	
	void Update(){
		bool clickedJump = Input.GetKeyDown(KeyCode.Space);
		if (clickedJump && onGround)
			jump();
	}
	public void Move (float h, float v)
	{	
	
		//movement.Set (h, 0f);
		//playerRigidbody.AddForce (movement * speed, ForceMode2D.Force);
		playerRigidbody.velocity = new Vector2 (h * speed, playerRigidbody.velocity.y);
		if(h > 0f && !facingRight)
			flip();
		if (h < 0f && facingRight)
			flip ();
		
		
		//playerRigidbody.velocity = movement * speed;
		//movement = movement.normalized * speed * Time.deltaTime;
		//playerRigidbody.MovePosition (transform.position + movement); //current position + new movement
	}
	
	void jump(){
		onGround = false;
		canMove = false;
		playerRigidbody.velocity = new Vector2 ();
		playerRigidbody.AddForce (new Vector2(0, jumpHeight));
	}
	
	void flip(){
		facingRight = !facingRight;
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void Animating(float h, float v)
	{
//		bool walking = h != 0f || v != 0f;
		//anim.SetBool ("IsMoving", walking);
		
	}

	public void Attacked(){
		playerRigidbody.velocity = new Vector2();
		playerRigidbody.AddForce (new Vector2 (50 * (facingRight? 1:-1), 0), ForceMode2D.Force);
	}
}
