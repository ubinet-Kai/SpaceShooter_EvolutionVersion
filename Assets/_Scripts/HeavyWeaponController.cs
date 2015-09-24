using UnityEngine;
using System.Collections;

public class HeavyWeaponController : MonoBehaviour 
{
	public GameObject shotMissile;
	public Transform shotSpawn2;
	public Transform shotSpawn3;
	public float fireRate;
	public float delay;

	public AudioClip audioClip; // it has some problem, can not play effect sound normally. Need to revise this part
	private AudioSource audioSource;
	
	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);  
		audioSource = gameObject.GetComponent<AudioSource> ();
		//audioSource.clip = audioClip;
	}     										  
	
	void Fire () 
	{
		Instantiate(shotMissile, shotSpawn2.position, shotSpawn2.rotation);
		Instantiate(shotMissile, shotSpawn3.position, shotSpawn3.rotation);
		audioSource.PlayOneShot(audioClip, 1.0f);
		//GetComponent<AudioSource>().Play();
	}
}