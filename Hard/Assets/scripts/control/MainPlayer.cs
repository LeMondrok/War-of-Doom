using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skills;

public class MainPlayer : MonoBehaviour
{
    private GameObject player;
    private Entity scriptPlayer;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode jump = KeyCode.Space;

    public heal h; 

    //private bool isFaceRight = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scriptPlayer = player.GetComponent<Entity>();

        this.GetComponent<Entity>().changeMana(1000);

        h = new heal(SkillType.TargetedAlly, 1, 10, 10);
    }

    void Flip()
    {
        
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(jump))
        {
            scriptPlayer.dir = Entity.Dir.jump;
            Debug.Log("asdfasdf");
        }

        if (Input.GetKeyDown(KeyCode.X))
            h.use(this.GetComponent<Entity>(), this.GetComponent<Entity>());
    }

    void LateUpdate()
    {
        //transform.LookAt();
    }
}
