using UnityEngine;
using System.Collections;

public class RigidbodyMovement : MonoBehaviour {
    Rigidbody rigidbody;
    //MOVE
    public float Speed = 10;
    Vector3 moveDirection;
    //JUMP
    public float Jump = 10f;
    public bool jumping = false;


    public float horizontalAngle = 270.0f;
    public float verticalAngle = 0.0f;

    // Use this for initialization
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumping)
            return;
        moveDirection = new Vector3(Speed * Input.GetAxis("Horizontal"), 0, Speed * Input.GetAxis("Vertical"));
        rigidbody.velocity = new Vector3(moveDirection.x, rigidbody.velocity.y, moveDirection.z);
        if (Input.GetAxis("Jump") > 0)
        {
            rigidbody.AddForce(Vector3.up * Jump, ForceMode.Impulse);
            jumping = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Equals("Plane"))
            jumping = false;
    }

    void OnCollisionLeave(Collision collision)
    {
        if (collision.gameObject.name.Equals("Plane"))
            jumping = true;
    }
}
