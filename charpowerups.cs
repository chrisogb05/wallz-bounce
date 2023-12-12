using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class charpowerups : MonoBehaviour
{
	public bool invincibility;
	public gameManager gm;
	public float originalSize;
	public float originalGravity;
	
	float smallerSize;

	public float originalMass;
	
	float smallerMass;
	Rigidbody2D rb;

	public Camera normalcam;
	public Camera invcam;

	public PostProcessVolume pp;

	bool ready = false;

	float currentvelocity;

	bool ividown = false;
	bool sdown = false;
	bool invdown = false;
	bool padown = false;
	bool bdown = false;
	bool ldown = false;

	public Color[] powerUpColors;
	public Color[] realPowerUpColors;
	public PostProcessVolume glow;

	int noofactive = 0;

	Color black = new Color(0, 0, 0, 0);

	int[] cont;

    // Start is called before the first frame update
    void Start()
    {
    	rb = GetComponent<Rigidbody2D>();
        originalSize = transform.localScale.x;
        originalGravity = rb.gravityScale;
        
        smallerSize = originalSize - 0.5f;
        originalMass = rb.mass;
        
        smallerMass = originalMass - 500f;


        
    }

    // Update is called once per frame
    void Update()
    {

    	if(gm.currentDurations[1] >= 0){
    		ividown = false;
    	}
    	if(gm.currentDurations[3] >= 0){
    		padown = false;
    	}
    	if(gm.currentDurations[4] >= 0){
    		invdown = false;
    	}
    	if(gm.currentDurations[5] >= 0){
    		sdown = false;
    	}

    	if(gm.currentDurations[0] >= 0){
    		bdown = false;
    	}

    	if(gm.currentDurations[2] >= 0){
    		ldown = false;
    	}

        for(int i = 0; i < gm.activePowerUps.Length; i++){
	    	if(gm.activePowerUps[i] != null){

	    		if(ividown == false){
			        if(gm.activePowerUps[i] == "Invincibility"){
			        	
			        	invincibility = true;

			        	//i = gm.activePowerUps.Length - 1;
			        	ividown = true;
			        }
			        else{
		        		
		        		invincibility = false;
		        	}
		        }

		        if(sdown == false){
		        	if(gm.activePowerUps[i] == "Size Down"){
				        	transform.localScale = new Vector2(smallerSize, smallerSize);
				        	rb.mass = smallerMass;
				        	//i = gm.activePowerUps.Length - 1;
				        	sdown = true;
				    }
			        else{
		        		
	        			transform.localScale = new Vector2(originalSize, originalSize);
	    				rb.mass = originalMass;
				        		
		        	}
		        }

		        if(invdown == false){
		        	

		        	if(gm.activePowerUps[i] == "Invert"){
		        		Debug.Log("wth");
		        		normalcam.enabled = false;
		        		invcam.enabled = true;
		        		//if(ready){

		        			pp.enabled = true;	
		        		//}

		        		//i = gm.activePowerUps.Length - 1;
		        		invdown = true;
		        	}
		        	else{
		        		
		        		normalcam.enabled = true;
		        		invcam.enabled = false;
		        		pp.enabled = false;
		        	}

		        }

		        if(ldown == false){
		        	if(gm.activePowerUps[i] == "Low Gravity"){
		        		rb.gravityScale = 2.2f;
		        		ldown = true;
		        	}
		        	else{
		        		rb.gravityScale = originalGravity;
		        	}
		        }

		        if(padown == false){
		        	if(gm.activePowerUps[i] == "Parachute"){
		        		currentvelocity = rb.velocity.y;

		        		if(currentvelocity < 0){
		        			rb.velocity = new Vector2(rb.velocity.x, currentvelocity / 1.25f);
		        		}
		        		else{
		        			rb.velocity = new Vector2(rb.velocity.x, currentvelocity);
		        		}

		        		//i = gm.activePowerUps.Length - 1;
		        		padown = true;
		        	}
		        }
    	}

    	/*if(ividown == true){
    		powerUpColors[1] = realPowerUpColors[1];
    		//cont[1] = 1;
    	}
    	else{
    		powerUpColors[1] = black;
    		//cont[1] = 0;
    	}

    	if(sdown == true){
    		powerUpColors[5] = realPowerUpColors[5];
    		//cont[5] = 1;
    	}
    	else{
    		powerUpColors[5] = black;
    		//cont[5] = 0;
    	}

    	if(padown == true){
    		powerUpColors[3] = realPowerUpColors[3];
    		//cont[3] = 1;
    	}
    	else{
    		powerUpColors[3] = black;
    		//cont[3] = 0;
    	}

    	if(invdown == true){
    		powerUpColors[4] = realPowerUpColors[4];
    		//cont[4] = 1;
    	}
    	else{
    		powerUpColors[4] = black;
    		//cont[4] = 0;
    	}

		if(bdown == true){
    		powerUpColors[0] = realPowerUpColors[0];
    		//cont[0] = 1;
    	}
    	else{
    		powerUpColors[0] = black;
    		//cont[0] = 0;
    	}    	

    	if(ldown == true){
    		powerUpColors[2] = realPowerUpColors[2];
    		//cont[2] = 1;
    	}
    	else{
    		powerUpColors[2] = black;
    		//cont[2] = 0;
    	}*/

    	/*for(int j = 0; j < gm.activePowerUps.Length; j++){
    		Debug.Log(powerUpColors[j]);

    		noofactive = cont[j];
    		Debug.Log(noofactive + " noo");
    	}*/
    	//noofactive = cont[0] + cont[1] + cont[2] + cont[3] + cont[4] + cont[5];


    	//if(noofactive > 0){
	    	/*var mixedcolor = new ColorParameter();
	    	mixedcolor.value = ((powerUpColors[0] + powerUpColors[1] + powerUpColors[2] + powerUpColors[3] + powerUpColors[4] + powerUpColors[5]) / noofactive);
	    	glow.profile.GetSetting<Bloom>().color.Override(mixedcolor);*/
	    //}
	    //else{
	    	var defaultcolor = new ColorParameter();
	    	defaultcolor.value = new Color(1, 0.7f, 0.7f, 1);
	    	glow.profile.GetSetting<Bloom>().color.Override(defaultcolor);
	    //}

	}
			    
		        
}}
		
