using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
	Vector3 velocity;
	public float speed=3f;
    bool fast = false;
    int lastPlayer;
    Marcador marcador;

    // Use this for initialization
    void Start () {
        marcador = Camera.main.GetComponent<Marcador>();
		velocity = (new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f))).normalized;
        lastPlayer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = velocity * speed * ((fast)?2:1);
    }
    void OnCollisionEnter(Collision collision)
	{
        velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);
        if (collision.gameObject.tag.Equals("Player"))
        {
            Vector3 hit = collision.contacts[0].normal;
            float hitAngle = Vector3.Angle(hit, collision.transform.forward);
            
            if (Mathf.Abs(hitAngle)<90f)
            {
                lastPlayer = collision.gameObject.GetComponent<Id>().playerId;
                Debug.Log(lastPlayer);
                if (lastPlayer == 1)
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                else if (lastPlayer == 2)
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                else if (lastPlayer == 3)
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                else if (lastPlayer == 4)
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            /*bool shooting = collision.gameObject.GetComponentInParent<Animation>().IsPlaying("Shoot");
            if (shooting)
                fast = true;
            else
                fast = false;*/
        }
    }
    
    void OnTriggerExit(Collider collider)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        /*TextMesh text= collider.transform.parent.transform.Find("Marcador").GetComponent<TextMesh>();
        int goles = System.Int32.Parse(text.text);
        if (goles>0)
            text.text= (goles-1).ToString();
        if(lastPlayer!=null)
        {
            text = lastPlayer.transform.Find("Marcador").GetComponent<TextMesh>();
            text.text = (System.Int32.Parse(text.text) + 1).ToString();
        }*/
        if(marcador.puntuacion[collider.GetComponent<Id>().playerId - 1]>0)
            marcador.puntuacion[collider.GetComponent<Id>().playerId-1]--;
        if(lastPlayer!=0)
            marcador.puntuacion[lastPlayer-1]++;
    }
}
