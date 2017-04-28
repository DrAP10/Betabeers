using UnityEngine;
using System.Collections;

public class AIPlayer : MonoBehaviour {
	float speed=5f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Buscamos la pelota mas cercana
		GameObject nearBall = null;
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            if (nearBall == null)
				nearBall = ball;
			else if (Mathf.Abs (Vector3.Distance (transform.position, ball.GetComponent<Transform> ().position)) <
			        Mathf.Abs (Vector3.Distance (transform.position, nearBall.GetComponent<Transform> ().position)))
				nearBall = ball;
		}
        //Si no hay pelotas no nos moveremos
		if (nearBall == null)
			return;

        //Nos movemos hacia la posición de la pelota
        Vector3 v;
        Transform ballTransform = nearBall.transform;

        //Esta forma de calcular la diferencia entre la posición de la pelota y nosotros solo funciona si nuestro
        //vector derecha es del tipo (0, 0, 1), (1, 0, 0), (0, 0, -1) o (-1, 0, 0)
        //ya que lo que hace es multiplicar estos por las posiciones del objeto para que luego al restar solo tengamos
        //el componente que nos interesa, porque los otros dos componentes se multiplican por 0.
        //El multiplicar el vector derecha por si mismo es para los casos en los que tenemos -1, así nos aseguramos que sea positivo
        v = (Vector3.Scale(ballTransform.position, Vector3.Scale(transform.right,transform.right)) 
            - Vector3.Scale(transform.position, Vector3.Scale(transform.right, transform.right)));
        //Ponemos una deadzone para que no se esten moviendo para diferencias muy pequeñas
        if (v.magnitude < 0.1f)
            return;

        //Normalizamos v y lo ponemos en funcion de la velocidad y el deltaTime
        v = v.normalized * speed * Time.deltaTime;
        //Ponemos un rango maximo por el que podemos desplazarnos
        if ((Vector3.Scale(transform.position, Vector3.Scale(transform.right, transform.right)) + v).magnitude > 1.3f)
            return;
        //Finalmente nos movemos
        transform.Translate(v , Space.World);
    }
}
