using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
	public GameObject spike;
	//public GameObject spikeEnd;
	public GameObject lowSpike;
	//public GameObject lowSpikeEnd;
	public GameObject midSpike;
	//public GameObject midSpikeEnd;
	public GameObject highSpike;
	//public GameObject highSpikeEnd;
	public gameManager gm;

	bool bigdone = true;

    // Start is called before the first frame update
    void Start()
    {
       
        //Debug.Log(lastSpikePlaced.transform.GetChild(1));
        //StartCoroutine(scale());
    }

    // Update is called once per frame
    void Update()
    {
    	if(gm.endless){
	    	if(bigdone){

	    		StartCoroutine(Sequence(/*8f*/));	
	    	}
            if(gm.gameState == "play"){
    	    	if(Input.GetKeyDown("r") || gm.start == true){

    	    		StopAllCoroutines();
    	    		bigdone = true;
    	    	}
            }
	    }
    }

    public void PlaceSpike(int type){
    	if(type == 0){
    		GameObject lastSpikePlaced = Instantiate(spike, transform.position, transform.rotation);
    	}
    	if(type == 1){
    		GameObject lastSpikePlaced = Instantiate(lowSpike, transform.position, transform.rotation);
    	}
    	if(type == 2){
    		GameObject lastSpikePlaced = Instantiate(midSpike, transform.position, transform.rotation);
    	}
    	if(type == 3){
    		GameObject lastSpikePlaced = Instantiate(highSpike, transform.position, transform.rotation);
    	}
    }

    public IEnumerator scale(){
	   	yield return new WaitForSeconds(2);

    	PlaceSpike(0);
    	yield return new WaitForSeconds(1.1f);
    	PlaceSpike(1);
    	yield return new WaitForSeconds(2f);
    	PlaceSpike(2);
    	yield return new WaitForSeconds(2.7f);
    	PlaceSpike(3);	
    }

    public IEnumerator triplelow(){
	   	yield return new WaitForSeconds(2);

    	PlaceSpike(0);
    	yield return new WaitForSeconds(0.8f);
    	PlaceSpike(0);
    	yield return new WaitForSeconds(0.8f);
    	PlaceSpike(0);
    	yield return new WaitForSeconds(1.6f);
    	PlaceSpike(1);	
    }

    public IEnumerator u(){
	   	yield return new WaitForSeconds(2);

    	PlaceSpike(2);
    	yield return new WaitForSeconds(1.2f);
    	PlaceSpike(0);
    	yield return new WaitForSeconds(1.2f);
    	PlaceSpike(2);
    }

    public IEnumerator doublemid(){
	   	yield return new WaitForSeconds(2);

    	PlaceSpike(2);
    	yield return new WaitForSeconds(1.7f);
    	PlaceSpike(2);
    	yield return new WaitForSeconds(1.7f);
    	PlaceSpike(1);
    }

    public IEnumerator twospike(){
	   	yield return new WaitForSeconds(2);

    	PlaceSpike(0);
    	yield return new WaitForSeconds(0.1f);
    	PlaceSpike(0);
    }

    public IEnumerator onemid(){
	   	yield return new WaitForSeconds(2);
    	PlaceSpike(2);
    }

    public IEnumerator Sequence(/*float waittime*/){
    	bigdone = false;
    	for(int i = 0; i < 3; i++){
	    	int obstacle = Random.Range(0,5);
	    	if(obstacle == 0){
		    	StartCoroutine(scale());
		    	yield return new WaitForSeconds(2f + 1.1f + 2.5f + 3f);
		    	//waits for the duration of the scale StartCoroutine
		    }
		    if(obstacle == 1){
		    	StartCoroutine(triplelow());
		    	yield return new WaitForSeconds(2f + 0.8f + 0.8f + 1.6f);
		    }
		    if(obstacle == 2){
		    	StartCoroutine(u());
		    	yield return new WaitForSeconds(2f + 1.6f + 1.6f);
		    }
		    if(obstacle == 3){
		    	StartCoroutine(doublemid());
		    	yield return new WaitForSeconds(2f + 1.7f + 1.7f);
		    }
		    if(obstacle == 4){
		    	StartCoroutine(twospike());
		    	yield return new WaitForSeconds(2f + 0.1f);
		    }
		    if(obstacle == 5){
		    	StartCoroutine(onemid());
		    	yield return new WaitForSeconds(2f);
		    }
		}
    	bigdone = true;
    }
}
