using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceilingspawner : MonoBehaviour
{
	public GameObject[] spikes;
	//public GameObject highSpikeEnd;
	public gameManager gm;
	float startspeed;
	public float maxspike;
	public GameObject powerUp;
	[SerializeField]
	float powerAvailable;

	bool done = true;
	bool done2 = true;
    // Start is called before the first frame update
    void Start()
    {
        startspeed = gm.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.endless){
	    	if(done){

	    		StartCoroutine(RandomSpike());	
	    	}
	    	if(done2){
	    		StartCoroutine(Power());
	    	}

	    	if(Input.GetKeyDown("r")){
	    		StopAllCoroutines();
	    		done = true;
	    		done2 = true;
	    	}
	    }

	    maxspike = spikes.Length * (1-(1 * ((gm.speed - gm. minimumSpeed) / (startspeed - gm.minimumSpeed))));
	    Debug.Log(Mathf.RoundToInt(maxspike));
    }

    IEnumerator RandomSpike(){
    	done = false;
    	Instantiate(spikes[Random.Range(0, Mathf.RoundToInt(maxspike))], transform.position, transform.rotation);
    	yield return new WaitForSeconds(0.8f);
    	
    	done = true;
    }

    IEnumerator Power(){
    	if(maxspike > powerAvailable){
    		done2 = false;
    		yield return new WaitForSeconds(Random.Range(2, 8));
	    	Instantiate(powerUp, new Vector2(transform.position.x, Random.Range(-6, 6)), new Quaternion (0,0,0,0));
	    	done2 = true;
	    }
    }
}



