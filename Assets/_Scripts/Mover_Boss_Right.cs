using UnityEngine;
using System.Collections;

public class Mover_Boss_Right : MonoBehaviour 
{
	public float rightSpeed;
	
	public float tilt;
	private float rollZ; // tilt the boss ship
	private int direction; // direction of rotation

	//private Mover_Boss_Forward 

	Rigidbody rb;

	void Start()
	{
		rollZ = 0f;
		direction = 1;
		rb = GetComponent<Rigidbody> ();
		//rb.velocity = transform.right * speedRight; //The red axis of the transform in world space.(move horizontal) // no need to update the frame
		rb.velocity = transform.right * rightSpeed;
	}

	void FixedUpdate()
	{
		rollZ += direction * tilt; //rb.velocity.x * 

		rb.rotation = Quaternion.Euler (0.0f, 180.0f, rollZ);  //1   process: 1->2->1->3->1
	    transform.position = new Vector3 (rb.position.x, 0.0f, 10.0f);
			
		if (transform.position.x > 3.0f) 
		{   //2
			direction = 1;
			rb.velocity = transform.right * rightSpeed;
		} 
		else if (transform.position.x < -3.0f) 
		{//3
			direction = -1;
			rb.velocity = transform.right * -rightSpeed;
		}
	}
}
