using UnityEngine;
using System.Collections;

public class DestroyByDamage : MonoBehaviour
{
	public GameObject healthCondition;
	private GameController gameController; 
	private GameObject[] healthElement;
	private int amounts;

	void Start () 
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

		amounts = gameController.currentHealth;

		for(int i = 0;  i < amounts; i++)
		{
			  Instantiate(healthCondition, new Vector3(i * 1.4f, 0.0f, 0.0f), Quaternion.identity);
		}
		healthElement = GameObject.FindGameObjectsWithTag("Health");
	}

	void Damaged()
	{		 
	  Destroy(healthElement[healthElement.Length]);
	}
}
