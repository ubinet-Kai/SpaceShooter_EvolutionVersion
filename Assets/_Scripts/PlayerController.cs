using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire; //default value is "0" 

	private GameController gameController; 

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null) 
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void Update()  //don't need physical update for shooting
	{
		if (!gameController.isGameWin)
		{
			if (Time.time > nextFire) 
			{ // indicates the time in the game; Input.GetButton ("Fire1") &&
				nextFire = Time.time + fireRate; //it will 	make shot get same distance value between next fire shot
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				GetComponent<AudioSource> ().Play ();  //remember this grammer
			}
		} 
		else 
		{
			return;
		}
	}


	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Rigidbody rb = GetComponent<Rigidbody> ();

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.velocity = movement * speed; //need fast speed, otherwise it would not move fast more than 1.0

		rb.position = new Vector3 
			(
				Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
			);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);  //rb.velocity.x is multipled by speed before 
	}   // in this grammer, when z is negative, it means that "clockwise",vice versa     
}      //for this case, x's area is "-1~1"
                                                           