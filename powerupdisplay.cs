using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerupdisplay : MonoBehaviour
{
	public gameManager gm;
	Slider slider;
	public string no;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(gm.gameState == "play"){

	    	if(no == "0"){
		        slider.maxValue = gm.powerUpDurations[0];
		        slider.value = gm.currentDurations[0];
		    }
		    if(no == "1"){
		    	slider.maxValue = gm.powerUpDurations[1];
		        slider.value = gm.currentDurations[1];
		    }
		    if(no == "2"){
		    	slider.maxValue = gm.powerUpDurations[2];
		        slider.value = gm.currentDurations[2];
		    }
		    if(no == "3"){
		    	slider.maxValue = gm.powerUpDurations[3];
		        slider.value = gm.currentDurations[3];
		    }
		    if(no == "4"){
		    	slider.maxValue = gm.powerUpDurations[4];
		        slider.value = gm.currentDurations[4];
		    }
		    if(no == "5"){
		    	slider.maxValue = gm.powerUpDurations[5];
		        slider.value = gm.currentDurations[5];
		    }
		}

    }
}
