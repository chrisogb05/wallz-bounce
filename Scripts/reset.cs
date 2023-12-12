using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
	gameManager gm;

	Vector2 startpos;
	Transform despawn;
    // Start is called before the first frame update
    void Awake()
    {
        startpos = transform.position;

        despawn = GameObject.Find("ParallaxMinimumPos").transform;

        gm = GameObject.Find("Endless Manager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(gm.gameState == "play"){

	    	if(GetComponent<spikemovement>().endless == true){
		        if(transform.position.x < despawn.position.x){
	    			Destroy(this.gameObject);
	    		}
		    }
	    	

	        if(Input.GetKeyDown("r") || gm.start == true){

		        if(GetComponent<spikemovement>() == null){
		        	transform.position = startpos;
		        }
		        else{
		        	if(GetComponent<spikemovement>().endless == true){
		        		Destroy(this.gameObject);
		        	}

		        	if(GetComponent<spikemovement>().endless == false){
		        		transform.position = startpos;
		        	}
		        }
	        }
	    }

	    

	    if(gm.start == true){
	    	gm.start = false;
	    	
	        if(GetComponent<spikemovement>() == null){
	        	transform.position = startpos;
	        }
	        else{
	        	if(GetComponent<spikemovement>().endless == true){
	        		Destroy(this.gameObject);
	        	}

	        	if(GetComponent<spikemovement>().endless == false){
	        		transform.position = startpos;
	        	}
	        }
	        
	    }
    }
}
