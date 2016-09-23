using UnityEngine;
using System.Collections;

public class Build_Controller : MonoBehaviour {

    public GameObject conveyor_created, map_holder;
    private GameObject[] map;
    private bool has_been_built;
    private int cur_index = 0;
    private RaycastHit2D hit_collider;
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


	
	// Update is called once per frame
	void Update () {
        if (conveyor_created != null)
        {
            print(conveyor_created.gameObject.name);
            hit_collider = Physics2D.Raycast(conveyor_created.transform.position, Vector2.zero, 0f);
            print(hit_collider.collider.gameObject);
            if (Input.GetMouseButtonUp(0)){
                GameObject cur_location = hit_collider.collider.gameObject;
                Map_Position mp = cur_location.GetComponent<Map_Position>();
                if(mp.object_in_position == "")
                {
                    conveyor_created.transform.position = cur_location.transform.position;
                    BoxCollider2D bc = conveyor_created.GetComponent<BoxCollider2D>();
                    bc.enabled = true;
                    mp.object_in_position = conveyor_created.name;
                    ui.selected_object = null;
                    conveyor_created = null;
                }
            }

        }


    }
}
