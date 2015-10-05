using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class groundInstantiator : MonoBehaviour {

	public GameObject[] groundOptions;

	private List<GameObject> ground;
	private List<Vector2> groundTiles;
	private BoxCollider2D groundCollider;
	private Vector2 size;

	void Awake(){
		groundCollider = GetComponent<BoxCollider2D> ();
		size = groundCollider.size;
		CreateBoard ();
	}


	void CreateBoard(){
		int r;
		for(int x = 0; x < size.x; x++){
			for(int y = 0; y < size.y; y++){
				r = Random.Range (0, groundOptions.Length);
				Instantiate(groundOptions[r], new Vector2(gameObject.transform.position.x + x - ((size.x - 1) / 2), gameObject.transform.position.y + y - ((size.y - 1) / 2)), Quaternion.identity);
			}
		}
	}
}
