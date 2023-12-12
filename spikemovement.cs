using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikemovement : MonoBehaviour
{
	public gameManager gm;
	Rigidbody2D rb;
    public bool endless;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(endless){
            gm = GameObject.Find("Endless Manager").GetComponent<gameManager>();
        }
        rb.velocity = new Vector2(-gm.speed, rb.velocity.y);
        
    }
}
