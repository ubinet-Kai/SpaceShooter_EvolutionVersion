using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
	public GameObject bossEnemy;

	public float startWait;
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
			Vector3 spawnPosition = new Vector3
				(
				    spawnValues.x, 
					spawnValues.y, 
					spawnValues.z
				 );
			//create objects randomly based on "range"
			Quaternion spawnRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);  // no rotation at all
			
			Instantiate(bossEnemy, spawnPosition, spawnRotation);	
			//yield return new WaitForSeconds (spawnWait); //wait until the other asteroid comes out
			//yield return new WaitForSeconds(waveWait);
			break;
		}
	}
	
}