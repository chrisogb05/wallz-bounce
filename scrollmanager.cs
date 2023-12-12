using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollmanager : MonoBehaviour
{
	public float offset = 0f;
	public float sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	offset = (Input.GetAxisRaw("Vertical") * sensitivity);
    	//Debug.Log(Input.GetAxisRaw("Vertical") + " Offset = " + offset);
    	/*if(offset >= 0f){
        	print(Input.GetAxisRaw("Mouse ScrollWheel"));
        	offset
        }*/
    }
}
