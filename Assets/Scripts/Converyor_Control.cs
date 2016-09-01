using UnityEngine;
using System.Collections;

public class Converyor_Control : MonoBehaviour {


    public float speed_mod, speed;
    private Rigidbody2D rb;
    private GameObject touching_box;
    private Vector2 movement, dir_mod;
    private float dif_x, dif_y, move_x, move_y;
    private bool reached_center;


	// Use this for initialization
	void Start () {
        speed = .01f;
        speed_mod = 1;

        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //if (tag == "right")
        //{
        //    dir_mod = new Vector2(1f, 0);
        //}
        //else if (tag == "down")
        //{
        //    dir_mod = new Vector2(0, -1f);
        //}
        //else if (tag == "turn_down" || tag == "turn_right")
        //{
        //    dir_mod = new Vector2(0.5f, -0.5f);
        //}
        //movement = speed * speed_mod * dir_mod;
	    if(touching_box != null)
        {
            if (!reached_center)
            {
                if (touching_box.transform.position.x > transform.position.x + .01 || touching_box.transform.position.x < transform.position.x - .01)
                {
                    dif_x = transform.position.x - touching_box.transform.position.x;
                    move_x = Create_Center_Move_Values(dif_x);
                }
                else
                {
                    move_x = 0;
                }
                if (touching_box.transform.position.y > transform.position.y + .01 || touching_box.transform.position.y < transform.position.y - .01)
                {
                    dif_y = transform.position.y - touching_box.transform.position.y;
                    move_y = Create_Center_Move_Values(dif_y);
                }
                else
                {
                    move_y = 0;
                }


                if (move_x != 0 || move_y != 0)
                {
                    print(reached_center);
                    movement = new Vector2(move_x, move_y);
                }
                else
                {
                    reached_center = true;
                }
            }
            else
            {

                if (tag == "right")
                {
                    movement = new Vector2(1f, 0);
                }
                else if (tag == "down")
                {
                    movement = new Vector2(0, -1f);
                }
            }

            rb.velocity = movement;
        }
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        print("yo");
        touching_box = c.gameObject;
        reached_center = false;
        rb = touching_box.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
        rb.gravityScale = 0;
    }

    void OnTriggerExit2D(Collider2D c)
    {
        rb.velocity = new Vector2(0, 0);
        touching_box = null;  
    }

    private float Create_Center_Move_Values(float difference)
    {
        if(difference > 0)
        {
            return 1;
        }
        return -1;
    }
}
