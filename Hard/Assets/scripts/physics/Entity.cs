using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Entity: MonoBehaviour
{
    public enum Dir
    {
        left, right, up, down, stay, jump
    }

    public Dir dir = Dir.stay;
    public float speed = 10, jumpPower = 15;
    private Rigidbody2D body;
    private Vector2 direction;
    private double lX;
    private int mana = 0, health = 0;
    public bool faceLeft;
    public enum Axis { X = 0, XY = 1 };
    public Axis axis = Axis.X;
    public bool onGround = true;

    public void move()
    {
        if (dir == Dir.left)
        {
            direction = new Vector2(-1, 0);
        }

        if (dir == Dir.right)
        {
            direction = new Vector2(1, 0);
        }

        if (dir == Dir.stay)
        {
            direction = new Vector2(0, 0);
        }

        /*if(Input.GetKey(stop))
        {
            direction = new Vector2(0, 0);
        }*/
    }

    public void changeHealth(int x)
    {
        health += x;
    }

    public void changeMana (int x)
    {
        mana += x;
    }

    public int getMana()
    {
        return mana;
    }

    void Start()
    {
        Debug.Log("I am alive!");

        lX = this.transform.position.x;

        body = GetComponent<Rigidbody2D>();
        body.fixedAngle = true;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")
        {
            //body.drag = 10;
            onGround = true;
            //Debug.Log("YYY");
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")
        {
            //body.drag = 0;
            onGround = false;
            Debug.Log("xxx");
        }
    }

    void Update()
    {
        move();

        double tX = this.transform.position.x;

        if (tX > lX) faceLeft = false;
        else if (tX < lX) faceLeft = true;

        lX = tX;
    }

    void FixedUpdate()
    {
        body.AddForce(direction * body.mass * speed);

        if (body.velocity.x > speed)
        {
            body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed, body.velocity.y);
        }

        if (onGround && dir == Dir.jump)
        {
            body.velocity = new Vector2(0, jumpPower);
        }
        else if (body.velocity.y > speed)
        {
            body.velocity = new Vector2(body.velocity.x, Mathf.Sign(body.velocity.y) * speed);
        }
    }
}
