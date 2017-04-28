using UnityEngine;
using System.Collections;

public class TransformMovement : MonoBehaviour {

    public float speed = 2;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //Forma muy basica de moverse pero ERRONEA, ver TransformMovement2.cs
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
