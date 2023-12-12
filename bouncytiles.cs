using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncytiles : MonoBehaviour
{
	public gameManager gm;
	PhysicsMaterial2D normalBounce;
	public PhysicsMaterial2D bouncy;
	
	CircleCollider2D playerbc;

    // Start is called before the first frame update
    void Start()
    {
        
        playerbc = GameObject.FindWithTag("Player").GetComponent<CircleCollider2D>();
        normalBounce = playerbc.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
    	for(int i = 0; i < gm.activePowerUps.Length - 1; i++){
	    	if(gm.activePowerUps[i] != null){

		        if(gm.activePowerUps[i] == "Bouncy Platforms"){
		        	
		        	playerbc.sharedMaterial = bouncy;
		        	i = gm.activePowerUps.Length - 1;
		        }
		        else{
	        		
	        		playerbc.sharedMaterial = normalBounce;
	        	}
			    
		        
		    }
		}
    }
}
