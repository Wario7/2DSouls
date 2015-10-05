using UnityEngine;
using System.Collections;

public class moveSword : MonoBehaviour {

	public bool facingRight;
	public GameObject sword;
	public Transform originalPosition;

	private float straight;


	void Start(){
		originalPosition.position = new Vector3 (-0.3f, -0.25f);

		facingRight = true;

		straight = 315;
	}

	//just animate sword positions. no need for rotations.
	void rotateSword(float angle){
		sword.transform.rotation = Quaternion.Euler(sword.transform.rotation.x, sword.transform.rotation.y, angle);
	}

	void originalSwordPosition(){
		sword.transform.position = originalPosition.position;
		sword.transform.rotation = originalPosition.rotation;
		sword.transform.localScale = originalPosition.localScale;
	}

	void attack1(){
		sword.transform.rotation = Quaternion.Euler(sword.transform.rotation.x, sword.transform.rotation.y, straight);
	}

	private void flip(){
		facingRight = !facingRight;
		Vector2 theScale = sword.transform.localScale;
		theScale.x *= -1;
		sword.transform.localScale = theScale;
	}

//	IEnumerator attack2(){
//		Quaternion swordRotation = sword.transform.rotation;
//		Quaternion newRotation = Quaternion.Euler (swordRotation.x, swordRotation.y, 10);
//		Quaternion.Lerp (swordRotation, newRotation, Time.time * 2);
//		yield return WaitForSeconds (2);
//	}

}