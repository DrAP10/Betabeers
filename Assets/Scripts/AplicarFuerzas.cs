using UnityEngine;
using System.Collections;

public class AplicarFuerzas : MonoBehaviour
{
    public GameObject impulse;
    public GameObject velocityChange;
    public GameObject force;
    public GameObject acceleration;

    public float fuerza = 20;
	// Use this for initialization
	void Start ()
    {
        impulse.GetComponent<Rigidbody>().AddForce(transform.up * fuerza, ForceMode.Impulse);
        velocityChange.GetComponent<Rigidbody>().AddForce(transform.up * fuerza, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        force.GetComponent<Rigidbody>().AddForce(transform.up * fuerza, ForceMode.Force);
        acceleration.GetComponent<Rigidbody>().AddForce(transform.up * fuerza, ForceMode.Acceleration);
    }
}
