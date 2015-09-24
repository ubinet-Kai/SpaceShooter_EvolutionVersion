using UnityEngine;
using System.Collections;

public class Mover_RollY : MonoBehaviour 
{
	public float rotationalSpeed;
	private float rollY;
	private int direction;

	void Start()  //rotation change to angle
	{
		rollY = 180.0f; // the reason why rollY is 180 is that the direction of boss is reverse
		direction = 1;
	}
	// Update is called once per frame
	void Update () 
	{
		rollY += direction * rotationalSpeed;
		transform.rotation = Quaternion.Euler (0.0f, rollY, 0.0f);

		if (rollY > 260.0f) {
			direction = -1;
		} else if(rollY < 100.0f) 
		{
			direction = 1;
		}
//
//			if (transform.rotation.y < 100.0f) 
//		{
//			direction = 1;
//		}
	}
}
