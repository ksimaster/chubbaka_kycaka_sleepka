using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    public static bool hasKey;
	public GameObject theUI;
	public GameObject theHinge;
	public bool inTrigger;
	public bool isOpen;
	public bool isInteracting;

	void Start()
	{
		theUI.SetActive (false);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (hasKey)
			{
				theUI.SetActive(true);  
				inTrigger = true;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (hasKey) 
			{
				theUI.SetActive(false);
				inTrigger = false;
			}
		}
	}

	public void Interacting(bool interacting)
	{
		if (!isInteracting) 
		{
			if (hasKey) 
			{
				isInteracting = true;
				interacting = false;
				StartCoroutine (reset ());
			}
		}
	}

	void Update()
	{
		if (isInteracting) 
		{
			if (!isOpen) 
			{
				var newRot = Quaternion.RotateTowards (theHinge.transform.rotation, Quaternion.Euler (0.0f, -90.0f, 0.0f), Time.deltaTime * 200);
				theHinge.transform.rotation = newRot;	

			} 
			else
			{
				var newRot = Quaternion.RotateTowards (theHinge.transform.rotation, Quaternion.Euler (0.0f, 0.0f, 0.0f), Time.deltaTime * 200);
				theHinge.transform.rotation = newRot;
			}
		}		
	}

	IEnumerator reset()
	{
		yield return new WaitForSeconds (1);
		isInteracting = false;

		if (!isOpen)
		{
			isOpen = true;
		} 
		else 
		{
			isOpen = false;
		}
	}
}