using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public float plav = 1.4f;
    public Vector2 otstav = new Vector2(2f, 1f);

    private Transform player;
    private GameObject pl;
	// Use this for initialization
	void Start ()
    {
        findPlayer();
	}

    public void findPlayer()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
        player = pl.transform;

        if (pl.GetComponent<Entity>().faceLeft)
        {
            transform.position = new Vector3(player.position.x - otstav.x, player.position.y + otstav.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + otstav.x, player.position.y + otstav.y, transform.position.z);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 newPos;

        if (pl.GetComponent<Entity>().faceLeft)
            newPos = new Vector3(player.position.x - otstav.x, player.position.y + otstav.y, transform.position.z);
        else
            newPos = new Vector3(player.position.x + otstav.x, player.position.y + otstav.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newPos, plav * Time.deltaTime);
    }

    
}
