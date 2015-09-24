using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;

	public int scoreValue;
	private GameController gameController; //global variable in this class
	
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


	void OnTriggerEnter(Collider other){  						   // can not run a loop like update, so the health logic should write in GameController script
		    							  						   // or create a individual function to count health condition	
		if ((other.tag == "Boundary") || (other.tag == "Enemy") || (other.tag == "ItemIncline") || (other.tag == "ItemParallel"))   // for this example, asteroid is inside boundary, so at the beginnning,
		{                                                          // if asteroid can identify the tag, then do nothing all the time.
			return;             						           //in other words, ignore the collision.
		}

		Instantiate (explosion, transform.position, transform.rotation);

		if (other.tag == "Player") // only if the player collides with Asteroid ! notice "tag"
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation); //in this situation, other means that "other object(player)", 

			gameController.HealthControl(); // be assulted
			gameController.Damaged(); // the life icon would disappear

			if(gameController.currentHealth == 0) //
			{
				gameController.GameOver();
				Destroy (other.gameObject); 
			}

			//Destroy (other.gameObject); //if this sentence only write here intstead of below the player's bolt will not be destroied
		}

		gameController.AddScore (scoreValue); //when collide happened

		if(other.tag == "PlayerBolt")
		{
			Destroy (other.gameObject);
		}

		//Destroy (other.gameObject); //shot would be destroied , the "other's" tag is not "Boundary", so it can be executed
		Destroy (gameObject); // asteroid would be destroied when objects first touch the collider

	}	
}

/* note: remember that if want to evade collides between team-mate, should take advantage of the "tag" */
