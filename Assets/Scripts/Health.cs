using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	public float health = 100f;							// How much health the player has left.
	public float resetAfterDeathTime = 5f;				// How much time from the player dying to the level reseting.
	public float pushedBack;
	public AudioClip deathClip;							// The sound effect of the player dying.

	
	
//	private Animator anim;								// Reference to the animator component.
//	private DonePlayerMovement playerMovement;			// Reference to the player movement script.
//	private DoneHashIDs hash;							// Reference to the HashIDs.
//	private DoneSceneFadeInOut sceneFadeInOut;			// Reference to the SceneFadeInOut script.
//	private DoneLastPlayerSighting lastPlayerSighting;	// Reference to the LastPlayerSighting script.
	private float timer;								// A timer for counting to the reset of the level once the player is dead.
//	private bool dead;							// A bool to show if the player is dead or not.
	private SpriteRenderer sr;
	private Rigidbody2D rb;
	private EnemyAI enemyAI;
	private GameObject player;
	
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag (Tags.player);
		pushedBack = 3;
		enemyAI = GetComponent<EnemyAI> ();
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
	}
	
	
	void Update ()
	{
		// If health is less than or equal to 0...
		if(health <= 0f)
		{
			Destroy (gameObject);
		}
	}
	
	
	void PlayerDying ()
	{
		// The player is now dead.
//		dead = true;
		
		// Set the animator's dead parameter to true also.
//		anim.SetBool(hash.deadBool, playerDead);
		
		// Play the dying sound effect at the player's location.
		AudioSource.PlayClipAtPoint(deathClip, transform.position);
	}
	
	
	void PlayerDead ()
	{
		// If the player is in the dying state then reset the dead parameter.
//		if(anim.GetCurrentAnimatorStateInfo(0).nameHash == hash.dyingState)
//			anim.SetBool(hash.deadBool, false);
		
		// Disable the movement.
//		anim.SetFloat(hash.speedFloat, 0f);
//		playerMovement.enabled = false;
		
		// Reset the player sighting to turn off the alarms.
//		lastPlayerSighting.position = lastPlayerSighting.resetPosition;
		
		// Stop the footsteps playing.
//		GetComponent<AudioSource>().Stop();
	}
	
	
	void LevelReset ()
	{
		// Increment the timer.
		timer += Time.deltaTime;
		
		//If the timer is greater than or equal to the time before the level resets...
//		if(timer >= resetAfterDeathTime)
			// ... reset the level.
//			sceneFadeInOut.EndScene();
	}
	
	
	public void TakeDamage (float amount)
	{
		// Decrement the player's health by amount.
		health -= amount;
	}

	IEnumerator tookDamage(float time){
		float elapsedTime = 0;
		while (elapsedTime < time)
		{
			sr.material.color = Color.Lerp (sr.material.color, Color.red, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForSeconds (0.25f);
		elapsedTime = 0;
		while (elapsedTime < time)
		{
			sr.material.color = Color.Lerp (sr.material.color, Color.white, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		if (other.tag == "Weapon" && player.GetComponent<AttackController>().engagedIntoBattle)
		{
			Debug.Log("I'm not done yet!");
//			sr.material.color = Color.Lerp(originalColor, Color.red, Time.deltaTime * 3);
//			sr.material.color = Color.Lerp(Color.red, Color.white, Time.deltaTime);
			enemyAI.canMove = false;
			TakeDamage(50);
			StartCoroutine (tookDamage(0.25f));
			StartCoroutine (PushBack());
			//enemyAI.canMove = true;
		}
		
//		if (other.tag == "Player")
//		{
//			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
//			gameController.GameOver();
//		}
		
//		gameController.AddScore(scoreValue);
//		Destroy (other.gameObject);
//		Destroy (gameObject);
	}

	IEnumerator PushBack(){
		if(playerOnLeft())
			rb.AddForce (new Vector2 (pushedBack, 3), ForceMode2D.Impulse);
		else 
			rb.AddForce (new Vector2 (-pushedBack, 3), ForceMode2D.Impulse);
		yield return new WaitForSeconds (1f);
		enemyAI.canMove = true;
	}

	bool playerOnLeft(){
		Debug.Log ("x = " + player.transform.position.x);
		Debug.Log ("y = " + player.transform.position.y);
		Debug.Log((GameObject.FindGameObjectsWithTag (Tags.player)).Length);
//		GameObject.FindGameObjectWithTag (Tags.player).SetActive (false);

		return player.transform.position.x <= rb.transform.position.x;
	}
}
