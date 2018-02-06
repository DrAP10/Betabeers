using UnityEngine;
using System.Collections;

public class MirarAtras : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            transform.localEulerAngles = new Vector3(0, 180, 0);
        else if (Input.GetKeyUp(KeyCode.Mouse0))
            transform.localEulerAngles = new Vector3(0, 0, 0);

    }
}
