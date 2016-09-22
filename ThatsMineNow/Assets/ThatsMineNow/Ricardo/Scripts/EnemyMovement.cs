using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public GameObject ball;
	public GameObject gate;
	public float speed = 10000.0f;

	public bool walkToBall = true;

	bool reachedBall = false;
	bool ballIsChild = false;
	bool isHit = false;

	Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);

		ball = GameObject.FindWithTag ("Ball");
		gate = GameObject.FindWithTag ("Gate");
	}

	void Update() {

		Debug.Log (transform.eulerAngles);
		Debug.Log (IsStanding ());
		if (walkToBall && !reachedBall && !isHit && !ballIsChild) {
			WalkToObject (ball);
		}

		if (reachedBall && !ballIsChild && ball.transform.parent == null) {
			ball.transform.parent = transform;
			ball.transform.localPosition = new Vector3 (-0.61f, -0.057f, 0.4f);
			ballIsChild = true;
		} else if (reachedBall && !ballIsChild) {
			ballIsChild = true;
		}

		if (ballIsChild) {
			WalkToObject (gate);
		}

		if (!IsStanding() && isHit && rb.velocity.Equals(Vector3.zero)) {
			StandUp ();
            isHit = false;
        }

    }

    public void WalkToObject(GameObject gameObject)
    {
        Vector3 objectPosition = gameObject.transform.position;
        Vector3 pathVector = objectPosition - transform.position;
        pathVector.y = 0;

        rb.velocity = new Vector3(0, 0, 0);

        Vector3 normalizedPathVector = pathVector.normalized;

        if (pathVector.sqrMagnitude > 5)
        {
            rb.AddForce(normalizedPathVector * (speed * Time.deltaTime));
            transform.LookAt(objectPosition);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            reachedBall = false;
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            reachedBall = true;
        }
    }

    public void Freeze()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }

    public void Hit()
    {
        isHit = true;

        if (ballIsChild)
        {
            ballIsChild = false;
            ball.transform.parent = null;
            reachedBall = false;

        }
    }

    bool IsStanding()
    {
        return transform.eulerAngles.x == 0 && transform.eulerAngles.z == 0;
    }

    void StandUp()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

}
