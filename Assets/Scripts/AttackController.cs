using UnityEngine;
using System.Collections;

public class AttackController : MonoBehaviour {

	//TODO:
	//1- fix edge movement bug
	//2- put delay between each attack DONE
	//3- reduce sheath sword time DONE
	//4- fix bug when sword is sheathed and attack is clicked DONE

	public bool engagedIntoBattle;
	public float attackRate;
	public float sheathSwordWaitTime;

	Animator anim;
	AnimatorStateInfo asi;
	MoveController moveController;
	HashIDs hash;
	Rigidbody2D rb; 
	float nextAttack;

	void Awake () {
		sheathSwordWaitTime = 0.5f;
		moveController = GetComponent<MoveController> ();
		anim = GetComponent<Animator> ();
		engagedIntoBattle = false;
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		rb = GetComponent<Rigidbody2D> ();

		anim.SetBool (hash.sword, true);
	}

	void FixedUpdate () {
		asi = anim.GetCurrentAnimatorStateInfo(0);

//		if (Input.GetButton ("Fire1")) {
//			Debug.Log("yaaaaar");
//		}

		if (Input.GetButton ("Fire1") && Time.time > nextAttack && !anim.GetBool(hash.stoppedAttackBool)) {
			nextAttack = Time.time + attackRate;
			Attack ();
		}
		//if Scavenger is not in idle position (or moving) AND not engaged in battle, sheath Scavenger's sword.
		if (!engagedIntoBattle && !asi.IsTag (Tags.idle)) {
			SheathSword();
		}

		if (asi.IsTag (Tags.idle)) {
			returnToIdle();
		}
			
	}

	private void Attack(){
		engagedIntoBattle = true;
//		StopCoroutine(returnSword());
		StopAllCoroutines();
		//or if(asi.nameHash == hash.idle)
		if(asi.IsTag("idle")){
			//1st Attack
			Debug.Log ("UNREAL RNG GOING ON RIGHT NOW");
			anim.SetBool(hash.attackBool, true);
		}
		else if(asi.IsTag(Tags.attack)){
			//2nd Attack
			anim.SetBool(hash.attack2Bool, true);
			anim.SetBool(hash.attackBool, false);
		}
		else if(asi.IsTag(Tags.attack2)){
			//3rd Attack
			anim.SetBool(hash.attack3Bool, true);
			anim.SetBool(hash.attack2Bool, false);
		}
		else if(asi.IsTag(Tags.attack3)){
			//Complete combo
			anim.SetBool(hash.attackBool, true);
			anim.SetBool(hash.attack3Bool, false);
		}

		if (moveController.onGround) {
			moveController.Attacked();
		}

		moveController.canMove = false; //In MoveController, check is attacking?
		StartCoroutine (returnSword());
	}

	private void SheathSword(){
		anim.SetBool(hash.attackBool, false);
		anim.SetBool(hash.attack2Bool, false);
		anim.SetBool(hash.attack3Bool, false);
		anim.SetBool(hash.stoppedAttackBool, true);

		if(moveController.onGround){
			moveController.canMove = true;
		}
	}

	private void returnToIdle(){
		anim.SetBool (hash.stoppedAttackBool, false);
	}
	
	IEnumerator returnSword(){
		yield return new WaitForSeconds (sheathSwordWaitTime);
		engagedIntoBattle = false;
	}
}
