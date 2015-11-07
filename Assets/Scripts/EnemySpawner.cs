using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] hazards;
	public int hazardCount;
	public Vector3 spawnValues;
	public Transform spawnPosition;
	public float spawnWait;
	public float startWait;
	public float waveWait;



	bool gameOver;
	bool restart;


	// Use this for initialization
	void Start () {

		gameOver = false;
		restart = false;
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
	if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
//				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
//				Vector3 spawnPosition = spawnValues;
				Quaternion spawnRotation = Quaternion.identity;
//				Instantiate (hazard, spawnPosition, spawnRotation);
				Instantiate (hazard, spawnPosition.position, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
//				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
}
