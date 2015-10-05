using UnityEngine;
using System.Collections;

public class AttackController : MonoBehaviour {

	Animator anim;
	AnimatorStateInfo asi;
	bool engagedIntoBattle;

	MoveController moveController;

	HashIDs hash;
	
	void Awake () {
		moveController = GetComponent<MoveController> ();
		anim = GetComponent<Animator> ();
		engagedIntoBattle = false;
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
	}

	void Update () {
		asi = anim.GetCurrentAnimatorStateInfo(0);
		if (Input.GetButton ("Fire1")) {
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
		//StopCoroutine(returnSword());
		StopAllCoroutines();
		//or if(asi.nameHash == hash.idle)
		if(asi.IsTag(Tags.idle)){
			//1st Attack
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

		moveController.canMove = false; //In MoveController, check is attacking?
		StartCoroutine (returnSword());
	}

	private void SheathSword(){
		anim.SetBool(hash.attackBool, false);
		anim.SetBool(hash.attack2Bool, false);
		anim.SetBool(hash.attack3Bool, false);
		anim.SetBool(hash.stoppedAttackBool, true);
		moveController.canMove = true; //TODO:if Scavenger sheathes sword in air..
	}

	private void returnToIdle(){
		anim.SetBool (hash.stoppedAttackBool, false);
	}
	
	IEnumerator returnSword(){
		yield return new WaitForSeconds (1f);
		engagedIntoBattle = false;
	}
}
