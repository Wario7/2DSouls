using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

	public float speed = 6f;
	public float jumpHeight = 700f;
	public Transform circle;
	public float circleRadius = 0.2f;
	public LayerMask whatIsGround;
	public bool canMove = true;
//	public bool beingReflected = false;
	public bool onGround = true;
	
	public float notMovingRate;
	private float nextMove;
	
	public bool facingRight = true;
	Vector2 movement;
	Animator anim;
	Rigidbody2D playerRigidbody;

	MoveController instance;
	
	void Start () {
		instance = this;
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	void FixedUpdate() //deals with physics update
	{
		float h = Input.GetAxisRaw ("Horizontal"); 
		//Edit -> Project Settings -> Input
		//Horizontal = a and d buttons
		float v = Input.GetAxisRaw ("Vertical");
		onGround = Physics2D.OverlapCircle(circle.position, circleRadius, whatIsGround);
		if (canMove)
			Move (h, v);
		if (onGround) { //TODO: and is not in attack animation..
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
	
	void Move (float h, float v)
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
}
