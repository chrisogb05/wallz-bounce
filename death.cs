using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
	SpriteRenderer sr;
	charpowerups powerup;
	public bool dead = false;
	public gameManager gm;

	public Data sc;

	public audiomanager am;

	bool played = false;

	public GameObject deathmsg;
	public GameObject hiscore;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        powerup = GetComponent<charpowerups>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(gm.gameState == "play"){
	        if(Input.GetKeyDown("r") || gm.start == true){
	        	sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
	        	dead = false;
	        	played = false;
	        }
	        if(powerup.invincibility){

	        	sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.4f);
	        }
	        else{
	        	if(dead == false){
	        		sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
	        	}
	        }
	        
	    }

	    if(dead){
        	if(gm.gameState == "play"){
        		deathmsg.SetActive(true);
        		hiscore.SetActive(true);
        	}
        }
        else{
        	deathmsg.SetActive(false);
        	hiscore.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
    	
    	if(col.gameObject.tag == "Dangerous"){
    		if(powerup.invincibility == false){
    			
    			dead = true;
	    		sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
	    		//this.gameObject.SetActive(false);
	    		if(gm.gameState == "play"){
		    		if(played == false){
		    			if(sc.score == sc.highScore){
		    				sc.SavePlayer();
		    				am.Play("highscoredeath");
		    			}
		    			else{
		    				am.Play("deathsound");
		    			}
		    			played = true;
		    		}
		    	}
	    	}
    	}
    }
}
