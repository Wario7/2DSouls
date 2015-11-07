using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwapWeapons : MonoBehaviour {
	
	public GameObject[] listOfWeapons;

	public int iterator;

	private GameObject player;
	private int size;
	
	void Awake(){
		player = GameObject.FindGameObjectWithTag (Tags.player);
		size = listOfWeapons.Length;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.T) && !player.GetComponent<AttackController>().engagedIntoBattle) {
			SwitchWeapon();
		}
	}

	void SwitchWeapon(){
		//Instantiate new weapon
		int nextWeapon = (iterator + 1) % size;
		int lastChild = player.transform.childCount - 1;
		GameObject oldWeapon = player.transform.GetChild(lastChild).gameObject;
		GameObject newWeapon = listOfWeapons[nextWeapon];

		//attach new weapon
		GameObject weaponReference = (GameObject) Instantiate (newWeapon, oldWeapon.transform.position, oldWeapon.transform.rotation);
		weaponReference.transform.parent = oldWeapon.transform.parent;
		
		//destroy current weapon
		oldWeapon.SetActive(false);
		Destroy (oldWeapon);

		//reference created weapon in scene and put it in listOfWeapons
//		listOfWeapons [nextWeapon] = weaponReference;
		iterator = nextWeapon;

		//set anim weapon to nextWeapon
	}
}
