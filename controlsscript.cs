using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlsscript : MonoBehaviour
{
	public Color invisible;

	[HideInInspector]
	public Color originalImageColor;
	[HideInInspector]
	public Color originalTextColor;

	Image image;
	public Text txt;

	public Animator panelAnimator;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        originalImageColor = image.color;
        originalTextColor = txt.color;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onMouseEnter(){
    	image.color = invisible;
    	txt.color = invisible;

    	panelAnimator.Play("panelpopup");
    }

    public void onMouseExitControlPanel(){
    	panelAnimator.Play("panelpopdown");
    	StartCoroutine(turnbackontime(0.175f));
    }

    public IEnumerator turnbackontime(float time){
    	yield return new WaitForSeconds(time);
    	image.color = originalImageColor;
    	txt.color = originalTextColor;
    }

    public void buttonvisible(){
    	image.color = originalImageColor;
    	txt.color = originalTextColor;
    }

    

    
}
