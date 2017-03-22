using UnityEngine;
using System.Collections;

public class TransformMovement2 : MonoBehaviour {

    public float speed = 2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontal
            +Vector3.forward * Time.deltaTime * speed * vertical);
    }
}
