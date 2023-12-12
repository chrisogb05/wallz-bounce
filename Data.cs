using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
	public int score = 0;
	public int highScore;
	public int spikeScore;
	public int lowSpikeScore;
	public int midSpikeScore;
	public int highSpikeScore;
	public gameManager gm;

	public audiomanager am;

	bool beaten;

	death d;

    // Start is called before the first frame update
    void Start()
    {
        d = GetComponent<death>();
    }

    public void SavePlayer(){
    	SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer(){
    	PlayerData data = SaveSystem.LoadPlayer();

    	highScore = data.highscore;
    }

    // Update is called once per frame
    void Update()
    {
    	if(score > highScore){
    		highScore = score;
    		if(beaten == false){
    			am.Play("beathighscore");
    			beaten = true;
    		}

    	}
        if(Input.GetKeyDown("r") || gm.start == true){
        	score = 0;
        	beaten = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
    	if(other.gameObject.tag == "Score"){
    		
    		if(d.dead == false){  		
	    		if(other.gameObject.transform.parent.gameObject.name == "Spike(Clone)"){
	    			score = score + spikeScore;
	    			am.Play("scorepoint");
	    		}
	    		if(other.gameObject.transform.parent.gameObject.name == "Small Jumper Spike(Clone)"){
	    			score = score + lowSpikeScore;
	    			am.Play("scorepoint");
	    		}
	    		if(other.gameObject.transform.parent.gameObject.name == "Mid Jumper Spike(Clone)"){
	    			score = score + midSpikeScore;
	    			am.Play("scorepoint");
	    		}
	    		if(other.gameObject.transform.parent.gameObject.name == "High Jumper Spike(Clone)"){
	    			score = score + highSpikeScore;
	    			am.Play("scorepoint");
	    		}
	    	}
    	}
    }
}
