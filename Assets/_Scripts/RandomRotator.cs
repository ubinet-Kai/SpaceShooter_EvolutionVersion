using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour 
{
	public float tumble; // so it can be controlLed by tumble data

	void Start()
	{
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * tumble;   //angular velocity is the velocity of rotating
	}

}
