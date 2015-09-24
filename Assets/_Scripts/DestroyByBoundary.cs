using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit(Collider other)  //when colliders leave boundary
	{
		Destroy (other.gameObject);
	}
}
