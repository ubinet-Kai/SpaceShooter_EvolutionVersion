using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour 
{
	public GameObject[] itemBoxes;
	public float startWait;
	public float waveWait;
	public Vector3 spawnValues;

	//public GameObject itemBoxParallelMissile;

	 void Start()
	{
		StartCoroutine(SpawnWaves ());
	}
	
	 IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);  //give user time to get ready
		
		while (true) 
		{
			GameObject itemBox = itemBoxes[Random.Range(0, itemBoxes.Length)]; 
			 Vector3 spawnPosition = new Vector3
				(
					Random.Range (-spawnValues.x, spawnValues.x), 
					spawnValues.y, 
					spawnValues.z
				);
			//create objects randomly based on "range"
			Quaternion spawnRotation = Quaternion.identity;  // no rotation at all

			Instantiate(itemBox, spawnPosition, spawnRotation);	
			//yield return new WaitForSeconds (spawnWait); //wait until the other asteroid comes out
			yield return new WaitForSeconds(waveWait);	
		}
	}

}