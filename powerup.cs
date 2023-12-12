using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
	public bool opened = false;
	gameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Endless Manager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
		if(opened){
			gm.generatepowerup();
			Destroy(gameObject);
		}        
    }

    public void OnTriggerEnter2D(Collider2D col){
    	if(col.gameObject.tag == "Player"){
    		if(col.gameObject.GetComponent<death>().dead == false){
	    		gm.generatepowerup();
	    		Destroy(gameObject);
	    	}
    	}
    }
}
