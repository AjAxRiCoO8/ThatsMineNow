using UnityEngine;
using System.Collections;

public class SoundsScript : MonoBehaviour {

    float timer = 0;
    float timerMax = 5;
    int random = 0;

    AudioSource audiosource;

    public AudioSource audio;
    public AudioSource GoAway;
    public AudioSource ThatsMineNow;


 void Start()
    {
        timer = 0;
       // audiosource = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timerMax)
        {
            // reset timer
            timer = 0;
            random = Random.Range(1, 3);
            // Do Stuff
            if ( random == 1)
            {
                audio.Play();
            }
            if (random == 2)
            {
                GoAway.Play();
            }
            if (random == 3)
            {
                ThatsMineNow.Play();
            }
            
        }
    }
}
