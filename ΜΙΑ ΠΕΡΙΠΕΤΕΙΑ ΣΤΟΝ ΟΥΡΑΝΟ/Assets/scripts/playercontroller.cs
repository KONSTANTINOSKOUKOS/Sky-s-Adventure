using UnityEngine;

public class playercontroller : MonoBehaviour
{
     public Rigidbody2D rb;
     public float speed;
     public float jump;
     Vector3 movement;

     bool shouldjump = false;
     public bool grounded = true;
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
/////////////////////////////////MOVEMENT/////////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            shouldjump = true;
            grounded = false;
            print("jumping");
        }

        if (!stopped)
        {
            movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, 0.0f) * speed * Time.deltaTime;
        }
////////////////////////////////ANIMATION//////////////////////////////////////////
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
        if (Input.GetAxisRaw("Horizontal") < 0 && facingright){//left pressed
            flip();
        }else if (Input.GetAxisRaw("Horizontal") > 0 && !facingright){//right pressed
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
            Destroy(gameObject, 1);
        }//LOSING LOGIC

        if (collision.collider.tag == "ground")
        {
            grounded = true;
            print("on ground");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            grounded = false;
            print("on air");
            //changeanim(standanim);
        }
    }

    /*void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            grounded = false;
            //changeanim(jumpanim);
        }
    }*/

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
