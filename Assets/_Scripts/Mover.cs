using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	// Use this for initialization
	public float speed;


	void Start () {
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;  // local z axis is also recognized as "forward"
		//GetComponent<Rigidbody>().velocity = transform.forward * speed;

	}

	//void Update(){

//		Vector3 x = new Vector3 ();

		//transform.position = new Vector3 (0,0, Time.deltaTime * 0.1f);

	//}
	

}
