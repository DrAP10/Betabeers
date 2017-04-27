using UnityEngine;
using System.Collections;

public class AIPlayer : MonoBehaviour {
	float speed=5f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject nearBall = null;
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("ball"))
        {
            if (nearBall == null)
				nearBall = ball;
			else if (Mathf.Abs (Vector3.Distance (transform.position, ball.GetComponent<Transform> ().position)) <
			        Mathf.Abs (Vector3.Distance (transform.position, nearBall.GetComponent<Transform> ().position)))
				nearBall = ball;
		}
		if (nearBall == null)
			return;

        Vector3 v;
        Transform ballTransform = nearBall.transform;
        v = (Vector3.Scale(ballTransform.position, Vector3.Scale(transform.right,transform.right)) 
            - Vector3.Scale(transform.position, Vector3.Scale(transform.right, transform.right)));
        //Debug.Log(gameObject.name + ": " + ballTransform.position + ", " + transform.position + ", " + transform.right + ", " + v);
        if (v.magnitude < 0.1f)
            return;
        v = v.normalized * speed * Time.deltaTime;
        if ((Vector3.Scale(transform.position, Vector3.Scale(transform.right, transform.right)) + v).magnitude > 1.3f)
            return;
        transform.Translate(v , Space.World);
    }
}
