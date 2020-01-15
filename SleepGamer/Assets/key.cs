using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour {

    public GameObject theKey;
    public GameObject theUI;
	public bool inTrigger;

    private void Start()
    {
        theUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            theUI.SetActive(true);  
			inTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            theUI.SetActive(false);
			inTrigger = false;
        }
    }

    public void getKey(bool getKey)
    {
        if (getKey)
        {
			if (inTrigger) 
			{
				door.hasKey = true;
				theKey.SetActive(false);
			}
        }
    }
}