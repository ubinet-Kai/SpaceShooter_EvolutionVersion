using UnityEngine;
using System.Collections;

public class ItemGet : MonoBehaviour 
{
	public bool isGet2; //if get the item-parallel
	public bool isGet3; //if get the item-incline

	void Start()
	{
		isGet2 = false;
		isGet3 = false;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "ItemParallel") 
		{
			Destroy(other.gameObject);
			//isGet = true;
			isGetItem2();
		} 
		else if (other.tag == "ItemIncline") 
		{
			Destroy(other.gameObject);
			//isGet = true;
			isGetItem3();
		}
	}

	void isGetItem2()
	{
		isGet2 = true;
		isGet3 = false;
	}

	void isGetItem3()
	{
		isGet3 = true;
		isGet2 = false;
	}
}
