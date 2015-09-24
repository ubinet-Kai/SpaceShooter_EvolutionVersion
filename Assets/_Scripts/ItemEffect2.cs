using UnityEngine;
using System.Collections;

public class ItemEffect2 : MonoBehaviour {

	public GameObject shotMissile;

	public Transform shotSpawn4; //item-incline
	public Transform shotSpawn5;
	
	
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
		ShotIncline ();
	}
	
	void ShotIncline()
	{
		if (itemGet.isGet3) {
			currentTime += Time.deltaTime * 1; // count one second!  notice *1
			
//			if (itemGet.isGet2 && itemGet.isGet3) {
//				currentTime = 0;
//				itemGet.isGet3 = false;
//				//itemGet.isGet2 = true;
//			} 
			
			if (currentTime < durationTime) {
				if (Time.time > nextFire) {
					nextFire = Time.time + fireRate; 
					Instantiate (shotMissile, shotSpawn4.position, shotSpawn4.rotation);
					Instantiate (shotMissile, shotSpawn5.position, shotSpawn5.rotation);
					GetComponent<AudioSource> ().Play (); 
					//Debug.Log(currentTime);
					
				}
			} else {
				currentTime = 0;  // should reset the currentTime !!
				itemGet.isGet3 = false;
			}
		} 
		else 
		{
			currentTime = 0;
		}
	}
}
