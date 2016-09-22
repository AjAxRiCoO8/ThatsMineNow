using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    
    public GameObject bullet;
    AudioSource audio;



    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        
        

    }
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(Input.GetButtonDown("Fire1"))
        {
            audio.Play();
            Instantiate(bullet, transform.position, transform.rotation);
            
            

           
        }

	}
}
