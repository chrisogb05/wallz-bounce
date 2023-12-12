using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signchanger : MonoBehaviour
{
	public scrollmanager sm;
	public GameObject up;
	public GameObject down;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sm.offset > 0){
        	up.SetActive(true);
        	down.SetActive(false);
        }
        else if(sm.offset < 0){
        	up.SetActive(false);
        	down.SetActive(true);
        }
        else{
        	up.SetActive(false);
        	down.SetActive(false);
        }
    }
}
