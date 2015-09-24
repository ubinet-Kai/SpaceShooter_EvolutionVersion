using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour
{
	public float scrollSpeed;
	public float tileSizeZ; // length of background -> scale Y(for player, this is Z axis)

	private Vector3 startPosition;
		
	void Start ()
	{
		startPosition = transform.position;
		Debug.Log ("test");
	}

	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ); //repeat based on the back ground size
		transform.position = startPosition + Vector3.forward * newPosition;
	}
}