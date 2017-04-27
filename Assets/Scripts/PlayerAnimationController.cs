using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {

    public float speed = 2f;
    Animator animator;
	// Use this for initialization
	void Start () {
        //animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontal
            + Vector3.forward * Time.deltaTime * speed * vertical);
        // NUEVO  
        /*animator.SetBool("Running", (horizontal != 0 || vertical != 0) ? true : false);
        float jump = Input.GetAxis("Jump");
        animator.SetBool("Jump", (jump > 0) ? true : false);*/
    }
}
