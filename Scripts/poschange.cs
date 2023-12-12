using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poschange : MonoBehaviour
{
	public scrollmanager s;
	public bool topMovement;
	public bool bottomMovement;
	public Transform topBarrier;
	public Transform bottomBarrier;

	Rigidbody2D rb;

	float position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(topMovement){
	    	//if(transform.position.y > 3f){	
		        	//transform.position = new Vector2(transform.position.x, position + s.offset);
    		if(transform.position.y > bottomBarrier.position.y){
		    		rb.velocity = new Vector2(rb.velocity.x, (-s.offset));
		    }

		    else{	
		    	if(-s.offset > 0){
		    		rb.velocity = new Vector2(rb.velocity.x, (-s.offset));
		    	}
		    	else{
		    		rb.velocity = new Vector2(0,0);
		    	}
		    }

		    if(transform.position.y >= topBarrier.position.y){
		    	
		    	if(-s.offset < 0){
		    		rb.velocity = new Vector2(rb.velocity.x, (-s.offset));
		    	}
		    	else{
		    		rb.velocity = new Vector2(0,0);
		    	}
		    }
		}
        

        if(bottomMovement){
	 		if(transform.position.y > bottomBarrier.position.y){
		    		rb.velocity = new Vector2(rb.velocity.x, (s.offset));
		    }

		    else{	
		    	if(s.offset > 0){
		    		rb.velocity = new Vector2(rb.velocity.x, (s.offset));
		    	}
		    	else{
		    		rb.velocity = new Vector2(0,0);
		    	}
		    }

		    if(transform.position.y >= topBarrier.position.y){
		    	
		    	if(s.offset < 0){
		    		rb.velocity = new Vector2(rb.velocity.x, (s.offset));
		    	}
		    	else{
		    		rb.velocity = new Vector2(0,0);
		    	}
		    }
        }
    }
}
