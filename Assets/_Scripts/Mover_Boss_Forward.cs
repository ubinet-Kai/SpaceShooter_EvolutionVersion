using UnityEngine;
using System.Collections;

public class Mover_Boss_Forward : MonoBehaviour 
{
	public float forwardSpeed;
	public bool isMove;

	void Start () {
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * forwardSpeed;  // local z axis is also recognized as "forward"
		//GetComponent<Rigidbody>().velocity = transform.forward * speed;
		isMove = true;
	}

	void Update()
	{
		if (transform.position.z < 10.0f) 
		{
			forwardSpeed = 0;
			isMove = false;
		}
	}
}