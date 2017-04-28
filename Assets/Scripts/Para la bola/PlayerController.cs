using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed=10f;

    GUIStyle guiStyle;
    Marcador marcador;
    // Use this for initialization
    void Start ()
    {
        guiStyle = new GUIStyle();
        guiStyle.normal.textColor = Color.black;
        guiStyle.alignment = TextAnchor.MiddleCenter;
        guiStyle.fontSize = 100;
        marcador = Camera.main.GetComponent<Marcador>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(transform.right * speed * x * Time.deltaTime, Space.World);
    }

    void OnGUI()
    {
        guiStyle.normal.textColor = Color.blue;
        GUI.Label(new Rect(0, 0, 100, 100), marcador.puntuacion[0].ToString(), guiStyle);
        guiStyle.normal.textColor = Color.green;
        GUI.Label(new Rect(Screen.width - 100, 0, 100, 100), marcador.puntuacion[1].ToString(), guiStyle);
        guiStyle.normal.textColor = Color.red;
        GUI.Label(new Rect(0, Screen.height - 100, 100, 100), marcador.puntuacion[2].ToString(), guiStyle);
        guiStyle.normal.textColor = Color.yellow;
        GUI.Label(new Rect(Screen.width - 100, Screen.height - 100, 100, 100), marcador.puntuacion[3].ToString(), guiStyle);
    }
}
