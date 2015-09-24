using UnityEngine;
using System.Collections;

public class ItemEffect : MonoBehaviour {

	public GameObject shotMissile;
	public Transform shotSpawn2; //item-parallel
	public Transform shotSpawn3;
		
	public float durationTime;
	public float fireRate;
	private float nextFire;
	private float currentTime;

	private ItemGet itemGet;

	void Start () 
	{
		currentTime = 0;
	
		GameObject itemGetObject = GameObject.FindWithTag("Player");

		if (itemGetObject != null) 
		{
			itemGet = itemGetObject.GetComponent<ItemGet>();
		}
		if (itemGet == null) 
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void Update ()   
	{
		ShotParallel ();
	}

	void ShotParallel()
	{
		if (itemGet.isGet2) {
			currentTime += Time.deltaTime * 1; // count one second!  notice *1
			
//			if(itemGet.isGet2 && itemGet.isGet3)
//			{
//				currentTime = 0;
//				itemGet.isGet2 = false;
//				//itemGet.isGet3 = true;
//			} 
			
			if (currentTime < durationTime) {
				if (Time.time > nextFire) {
					nextFire = Time.time + fireRate; 
					Instantiate (shotMissile, shotSpawn2.position, shotSpawn2.rotation);
					Instantiate (shotMissile, shotSpawn3.position, shotSpawn3.rotation);
					GetComponent<AudioSource> ().Play (); 
				}
			} else {
				currentTime = 0;  // should reset the currentTime !!
				itemGet.isGet2 = false;
			}
		} else
		{
			currentTime = 0;
		}
		
	}

}

//	IEnumerator
//
//		while
//
//			Yield 10 ?
//
//				break;

