using UnityEngine;
using System.Collections;

public class NoRotation : MonoBehaviour
{
	// this script is used by when you want to freaze the rotation of child object
	Quaternion iniRot; 

	void Start()
	{
		iniRot = transform.rotation;
	}
	void Update()  //note this.
	{
		transform.rotation = iniRot;
	}
}
