using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public Rigidbody2D rb;
     public float speed;
     public float jump;
     Vector3 movement;

     bool shouldjump = false;
     bool grounded = true;
     bool facingright = true;
     bool stopped = false;

    public SpriteRenderer sp;

     public Animator animator;
     string currentanim;

    const string standanim = "player stand";
    const string walkanim = "player walk";
    const string jumpanim = "player jump";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            shouldjump = true;
        }

        if (!stopped)
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f) * speed * Time.deltaTime;
        }

        if (grounded)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                changeanim(walkanim);
            }
            else
            {
                changeanim(standanim);
            }
        }
        else
        {
            changeanim(jumpanim);
        }
/////////////////////////////FLIPPING/////////////////////////////////////////////
        if (Input.GetAxis("Horizontal") < 0 && facingright){//left pressed
            print("left");
            flip();
        }else if (Input.GetAxis("Horizontal") > 0 && !facingright){//right pressed
            print("right");
            flip();
        }
    }

    void FixedUpdate()
    {
        transform.position += movement;
        if (shouldjump)
        {
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            shouldjump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "door" || collision.collider.tag == "spike")
        {
            sp.enabled = false;
            stopped = true;
        }
        grounded = true;
        changeanim(standanim);
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

    void flip()
    {
        sp.flipX = !sp.flipX;
        facingright = !facingright;
    }

    void changeanim(string anim)
    {
        if (currentanim == anim) return;

        animator.Play(anim);

        currentanim = anim;
    }
}
