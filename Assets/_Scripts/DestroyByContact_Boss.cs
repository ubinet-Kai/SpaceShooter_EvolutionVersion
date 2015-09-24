using UnityEngine;
using System.Collections;

public class DestroyByContact_Boss : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	
	public int oneShotScoreValue;
	public int deadScoreValue;
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
	
	
	void OnTriggerEnter(Collider other){  						  

		if ((other.tag == "Boundary") || (other.tag == "Enemy") || (other.tag == "ItemIncline") || (other.tag == "ItemParallel"))   
		{                                                        
			return;             						        
		}
		
		Instantiate (explosion, transform.position, transform.rotation);
		
		if (other.tag == "Player") 
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation); 
			
			gameController.HealthControl(); 
			gameController.Damaged();
			
			if(gameController.currentHealth == 0) 
			{
				gameController.GameOver();
				Destroy (other.gameObject); 
			}

		}
		
		gameController.AddScore (oneShotScoreValue); //when collide happened
		
		if(other.tag == "PlayerBolt")
		{
			Destroy (other.gameObject);
			gameController.BossHealthControl();

			if(gameController.bossCurrentHealth <= 0)
			{
				Destroy (gameObject); 
				gameController.AddScore(deadScoreValue);
				gameController.GameWin();
			}
		}
	}	
}

/* note: remember that if want to evade collides between team-mate, should take advantage of the "tag" */
