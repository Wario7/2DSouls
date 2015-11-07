using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float speed = 1f;
	public float LEFT = -1;

	[HideInInspector]
	public bool canMove;

	Rigidbody2D playerRigidbody;

	// Use this for initialization
	void Start () {
		canMove = true;
//		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) {
			EnemyMovement ();
		}
	}

	void EnemyMovement(){
		playerRigidbody.velocity = new Vector2 (LEFT * speed, playerRigidbody.velocity.y);

	}
}
