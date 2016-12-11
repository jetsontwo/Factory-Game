using UnityEngine;
using System.Collections;

public class Build_Controller : MonoBehaviour {

    public GameObject conveyor_created, map_holder;
    //public ArrayList path;
    public GameObject start_looker;
    private GameObject[] map;
    private bool has_been_built;
    private int cur_index = 0;
    private RaycastHit2D[] pickup_hit_collider;
    private RaycastHit2D place_hit_collider, looker_hit_collider;
    private Vector3 mouselocation;
    private Map_Position mp_pickup_loc;
    public UI_Script ui;


    void Start()
    {
        map = new GameObject[64];
        foreach(Transform child in map_holder.transform)
        {
            map[cur_index] = child.gameObject;
            cur_index++;
        }
    }

    void OnDisable()
    {
        //path = new ArrayList();
        //path.Add(new float[] { -5, 2 });
        //path.Add(new float[] { -4, 2 });
        //int count = 0;
        //looker_hit_collider = Physics2D.Raycast(new Vector2(-4, 2), Vector2.right, 1.25f, 3);
        //do
        //{
        //    print(count);
        //    print(looker_hit_collider.collider);
        //    if (looker_hit_collider.collider != null)
        //    {
        //        float loc_x = looker_hit_collider.collider.gameObject.transform.position.x;
        //        float loc_y = looker_hit_collider.collider.gameObject.transform.position.y;
        //        string loc_tag = looker_hit_collider.collider.gameObject.tag;
        //        Vector2 loc_dir = Vector2.zero;
        //        path.Add(new float[] { loc_x, loc_y });
        //        if (loc_tag == "right")
        //        {
        //            loc_dir = Vector2.right;
        //            loc_x += 1;
        //        }
        //        else if (loc_tag == "down")
        //        {
        //            loc_dir = Vector2.down;
        //            loc_y -= 1;
        //        }
        //        looker_hit_collider = Physics2D.Raycast(new Vector2(loc_x, loc_y), loc_dir, 0.25f, 3);
        //    }
        //    else
        //    {
        //        //path.Add("end");
        //        print("1");
        //        break;
        //    }
        //    count++;
        //}
        //while (looker_hit_collider.collider.gameObject.tag != "Finish" && count < 50);

        //foreach(float[] fl in path)
        //{
        //    print(fl[0] + " " + fl[1]);
        //}

    }


	
	// Update is called once per frame
	void LateUpdate () {



        if (conveyor_created != null)
        {
            conveyor_created.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
            
            if (Input.GetMouseButtonDown(0))
            {
                place_hit_collider = Physics2D.Raycast(conveyor_created.transform.position, Vector2.zero);
                if (place_hit_collider.collider)
                {
                    GameObject cur_location = place_hit_collider.collider.gameObject;
                    Map_Position mp = cur_location.GetComponent<Map_Position>();
                    if (cur_location.tag == "Trash")
                    {
                        Destroy(conveyor_created);
                        conveyor_created = null;
                    }
                    else if (mp.object_in_position == "")
                    {
                        conveyor_created.transform.position = cur_location.transform.position;
                        BoxCollider2D bc = conveyor_created.GetComponent<BoxCollider2D>();
                        bc.enabled = true;
                        mp.set_object(conveyor_created.name);
                        conveyor_created = null;
                    }
                }

                
                
            }

        }
        else if (Input.GetMouseButtonDown(0))
        {

            pickup_hit_collider = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            int both_set = 0;
            foreach(RaycastHit2D rh in pickup_hit_collider)
            {
                if(rh.collider.tag == "grid")
                {
                    mp_pickup_loc = rh.collider.gameObject.GetComponent<Map_Position>();
                    both_set++;
                }
                else
                {
                    conveyor_created = rh.collider.gameObject;
                    both_set++;
                }
                if (both_set == 2)
                    break;
            }
            BoxCollider2D bc = conveyor_created.GetComponent<BoxCollider2D>();
            bc.enabled = false;
            mp_pickup_loc.set_object("");
            mp_pickup_loc = null;
        }



    }
}
