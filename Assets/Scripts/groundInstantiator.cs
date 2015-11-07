using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class groundInstantiator : MonoBehaviour {

	public GameObject[] groundOptions;
	public int length;
	public int width;


	void Awake(){
		CreateBoard ();
	}


	void CreateBoard(){
		int r;
		for(int x = 0; x < length; x++){
			for(int y = 0; y < width; y++){
				r = Random.Range (0, groundOptions.Length);
				Instantiate(groundOptions[r], new Vector3(gameObject.transform.position.x + x - ((length - 1f) / 2f), 
				                                          gameObject.transform.position.y + y - ((width - 1f) / 2f),
				            							  gameObject.transform.position.z),
				            							  Quaternion.identity);
			}
		}
	}
}
