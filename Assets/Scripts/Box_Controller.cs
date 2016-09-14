using UnityEngine;
using System.Collections;

public class Box_Controller : MonoBehaviour {

    public float speed_mod, speed;
    private Rigidbody2D rb;
    private GameObject touching_conveyor;
    private Vector2 movement, dir_mod;
    private float dif_x, dif_y, move_x, move_y;
    private bool reached_center;


    // Use this for initialization
    void Start()
    {
        speed = .01f;
        speed_mod = 1;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (touching_conveyor != null)
        {
            if (!reached_center)
            {
                if (transform.position.x > touching_conveyor.transform.position.x + .01 || transform.position.x < touching_conveyor.transform.position.x - .01)
                {
                    dif_x = touching_conveyor.transform.position.x - transform.position.x;
                    move_x = Create_Center_Move_Values(dif_x);
                }
                else
                {
                    move_x = 0;
                }
                if (transform.position.y > touching_conveyor.transform.position.y + .01 || transform.position.y < touching_conveyor.transform.position.y - .01)
                {
                    dif_y = touching_conveyor.transform.position.y - transform.position.y;
                    move_y = Create_Center_Move_Values(dif_y);
                }
                else
                {
                    move_y = 0;
                }


                if (move_x != 0 || move_y != 0)
                {
                    movement = new Vector2(move_x, move_y);
                }
                else
                {
                    reached_center = true;
                }
            }
            else
            {

                if (touching_conveyor.tag == "right" || touching_conveyor.tag == "end")
                {
                    movement = new Vector2(1f, 0);
                    
                }
                else if (touching_conveyor.tag == "down")
                {
                    movement = new Vector2(0, -1f);
                }
            }

            rb.velocity = movement;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag != "box")
        {
            touching_conveyor = c.gameObject;
            reached_center = false;
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0;
        }
    }

    private float Create_Center_Move_Values(float difference)
    {
        if (difference > 0)
        {
            return 1;
        }
        return -1;
    }
}
