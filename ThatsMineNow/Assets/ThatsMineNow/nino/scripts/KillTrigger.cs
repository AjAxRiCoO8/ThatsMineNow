using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour {
    
     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy") && other.transform.rotation.y < 0.6)
        Destroy(other.gameObject);
    }
}
