﻿using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour {
    
     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        Destroy(other.gameObject);
    }
}
