using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
	// Here we store the hash tags for various strings used in our animators
	[HideInInspector]
	public int attackBool, attack2Bool, attack3Bool, stoppedAttackBool, sword, axe;

	void Awake ()
	{
//		dyingState = Animator.StringToHash("Base Layer.Dying");
//		locomotionState = Animator.StringToHash("Base Layer.Locomotion");
//		shoutState = Animator.StringToHash("Shouting.Shout");
//		deadBool = Animator.StringToHash("Dead");
//		speedFloat = Animator.StringToHash("Speed");
//		sneakingBool = Animator.StringToHash("Sneaking");
//		shoutingBool = Animator.StringToHash("Shouting");
//		playerInSightBool = Animator.StringToHash("PlayerInSight");
//		shotFloat = Animator.StringToHash("Shot");
//		aimWeightFloat = Animator.StringToHash("AimWeight");
//		angularSpeedFloat = Animator.StringToHash("AngularSpeed");
//		openBool = Animator.StringToHash("Open");

		sword = Animator.StringToHash ("Sword");
		axe = Animator.StringToHash ("Axe");

		attackBool = Animator.StringToHash("attack");
		attack2Bool = Animator.StringToHash("attack2");
		attack3Bool = Animator.StringToHash("attack3");
		stoppedAttackBool = Animator.StringToHash("stoppedAttack");

	}
}