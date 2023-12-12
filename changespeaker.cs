using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changespeaker : MonoBehaviour
{
	public Sprite unmuted;
	public Sprite muted;

	Image i;
    // Start is called before the first frame update
    void Start()
    {
        i = GetComponent<Image>();
    }

    public void toggleSprite(){

    	if(i.sprite == unmuted){
    		i.sprite = muted;
    		Debug.Log("muted");
    	}
    	else if(i.sprite == muted){
    		i.sprite = unmuted;
    		Debug.Log("unmuted");
    	}
    }
}
