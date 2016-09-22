using UnityEngine;
using System.Collections;

public class PushForce : MonoBehaviour {


    public float viewingDistance;
    public int cooldown;
    public float strength;

    RaycastHit hit;

    Vector3 forward;

    int cooldownTimer;
    bool canHit;

    // Use this for initialization
    void Update()
    {
        if (!canHit)
        {
            cooldownTimer++;

            if (cooldownTimer > cooldown)
            {
                cooldownTimer = 0;
                canHit = true;
            }
        }

        if (Input.GetMouseButton(0) && canHit)
        {
            canHit = false;
            forward = transform.TransformDirection(Vector3.forward) * viewingDistance;
            Debug.DrawRay(transform.position, forward, Color.green);

            if (Physics.Raycast(transform.position, forward, out hit))
            {

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(transform.forward * strength);

                    //activate the hit script of the enemy
                    GameObject enemy = hit.collider.gameObject;
                    EnemyMovement enemyMovement =  enemy.GetComponent<EnemyMovement>();
                    enemyMovement.Hit();

                }
            }
        }
    }
}

