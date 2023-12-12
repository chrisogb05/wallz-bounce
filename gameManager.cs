using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
	public string gameState;
	public float speed;
	public string[] activePowerUps;
	public string[] powerUps;

	public GameObject pauseMenu;
	public GameObject score;

	public bool start = false;

	bool loaded =false;	

	public float[] powerUpDurations;
	public float[] currentDurations;
	[HideInInspector]
	public bool[] isActiveThisFrame;

	public GameObject[] sliderz;

	int newestselectedPowerUp;

	public Animator a;

	public audiomanager am;

	public bool endless;
	public float decelerationRate;
	float originalSpeed;
	public float minimumSpeed;

	public Data da;

	public death d;
    // Start is called before the first frame update
    void Start()
    {
    	gameState = "menu";
        originalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
    	for(int t = 0; t < sliderz.Length; t++){
    		if(currentDurations[t] <= 0f){
    			sliderz[t].SetActive(false);
    		}
    		else{
    			sliderz[t].SetActive(true);	
    		}
    	}

    	if(start == false){
    		if(loaded == false){
    			loaded = true;
    			da.LoadPlayer();
    		}
    	}
    	else{
    		loaded = false;
    	}
    	if(gameState != "menu" && d.dead != true){
	    	if(Input.GetKeyDown("space")){
	    		
	    		if(gameState == "play"){    			
	    			gameState = "paused";
	    		}
	    		else if(gameState == "paused"){
	    			gameState = "play";
	    		}
	    	}
	    }
	   

    	if(gameState == "paused"){
    		//pause time
    		Time.timeScale = 0f;
    		pauseMenu.SetActive(true);
    		score.SetActive(false);

    		Cursor.visible = true;
    	}
    	else if(gameState == "play"){
    		//play time
    		Time.timeScale = 1f;
    		pauseMenu.SetActive(false);
    		score.SetActive(true);

    		Cursor.visible = false;
    	}

    	if(gameState == "play"){
	    	for(int i = 0; i < activePowerUps.Length; i++){

		        if(currentDurations[i] > 0){
		        	if(isActiveThisFrame[i] == false){
		        		a.Play("flash");
		        		am.Play("powerupstart");
		        		Debug.Log(activePowerUps[i] + " is now enabled");
		        	}
		        	isActiveThisFrame[i] = true;
		        	currentDurations[i] = currentDurations[i] - 1;
		        }
		        else{
		        	if(isActiveThisFrame[i]){
		        		a.Play("flash");
		        		am.Play("powerupend");
		        		Debug.Log(activePowerUps[i] + " is now disabled");
		        		isActiveThisFrame[i] = false;
		        	}
		        	activePowerUps[i] = "";
		        }
	        }

	        if(endless){
	        	if(speed > minimumSpeed){
	        		speed = speed - decelerationRate;	
	        	}

	        	if(Input.GetKeyDown("r") || start == true){
	        		am.Play("bgmusic");
	        		speed = originalSpeed;

	        		for(int i = 0; i < activePowerUps.Length; i++){
	        			currentDurations[i] = 0;
	        			activePowerUps[i] = "";
	        		}
	        	}
	        	
	        }
	    }
    }

    public void PlayGame(){
    	gameState = "play";
    	start = true;
    	a.Play("flash");
    	am.Play("startgame");
    	
    }
    public void ReturnToMenu(){
    	gameState = "menu";
    	Time.timeScale = 1f;
    	a.Play("flash");
    	am.Play("startgame");
    	
    }

    public void generatepowerup(){
    	newestselectedPowerUp = Random.Range(0, powerUps.Length);
    	activePowerUps[newestselectedPowerUp] = powerUps[newestselectedPowerUp];
    	currentDurations[newestselectedPowerUp] = powerUpDurations[newestselectedPowerUp];
    }
}
