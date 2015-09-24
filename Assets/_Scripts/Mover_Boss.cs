using UnityEngine;
using System.Collections;

public class Mover_Boss : MonoBehaviour 
{
	public float forwardSpeed;
	public float rightSpeed;

	private bool isMoveForward;

	public float tilt;
	private float rollZ; // tilt the boss ship
	private int direction; // direction of rotation
	private int directionX; //direction of position X

	Rigidbody rb;
		
		//private Mover_Boss_Forward 
		void Start()
		{
			rollZ = 0f;
			direction = 1;
		isMoveForward = true;
		directionX = 1;

		rb = GetComponent<Rigidbody> ();
			//rb.velocity = transform.right * speedRight; //The red axis of the transform in world space.(move horizontal) // no need to update the frame
		rb.velocity = transform.forward * forwardSpeed;
		}
		
		void FixedUpdate()
		{
		if (transform.position.z < 10.0f) 
		{
			forwardSpeed = 0;
			isMoveForward = false;
		}

		if (!isMoveForward) 
		{
			rollZ += direction * tilt; //rb.velocity.x * 

			rb.rotation = Quaternion.Euler (0.0f, 180.0f, rollZ);  //1   process: 1->2->1->3->1
			//if(rb.position.x <= 4.0f && rb.position.x >= -4.0f)
			//{
				rb.velocity = transform.right * rightSpeed * directionX;
			//}

			rb.position = new Vector3 (rb.position.x, 0.0f, 10.0f);
			
			if (rb.position.x > 4.0f) {   //2
				direction = 1;
				directionX = 1;
			} 
			else if (rb.position.x < -4.0f) 
			{//3
				direction = -1;
				directionX = -1;
			}
		}
	}
	

}