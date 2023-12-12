using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticktoground : MonoBehaviour
{
	Transform top;
	Transform bottom;
	public bool ceilingStructure;
	public bool floorStructure;
	yoffset offset;
   

    // Start is called before the first frame update
    void Start()
    {
        top = GameObject.Find("Top").transform;
        bottom = GameObject.Find("Bottom").transform;
        offset = GetComponent<yoffset>();
    }

    // Update is called once per frame
    void Update()
    {

        if(ceilingStructure){
        	transform.position = new Vector2(transform.position.x, top.position.y + offset.yOffset);
        }
        if(floorStructure){
        	transform.position = new Vector2(transform.position.x, bottom.position.y + offset.yOffset);
        }
    }
}
