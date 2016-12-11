using UnityEngine;
using System.Collections;

public class UI_Script : MonoBehaviour {
    public Upgrade_Menu um;
    public Transform conveyor_holder;
    public Build_Controller bc;
    public Box_Spawn bs;
    public GameObject build_grid, build_canvas;
    public GameObject created_conveyor;
    private Collider2D created_conveyor_collider;
    private bool build_window_open, can_open_upgrade_window = true;

    public void Open_Upgrade_Window()
    {
        if (can_open_upgrade_window)
        {
            um.enabled = !um.enabled;
        }
    }

    public void Create_Conveyor(GameObject conveyor_prefab)
    {
        created_conveyor = (GameObject) Instantiate(conveyor_prefab, conveyor_holder);
        created_conveyor.name = conveyor_prefab.name;
        created_conveyor_collider = created_conveyor.GetComponent<Collider2D>();
        if (bc.conveyor_created)
        {
            if(bc.conveyor_created.tag != "Finish")
            {
                Destroy(bc.conveyor_created);
                bc.conveyor_created = created_conveyor;
            }
        }
        else
            bc.conveyor_created = created_conveyor;

    }

    public void Open_Build_Window()
    {

        if (um.enabled)
        {
            um.enabled = false;
        }
        
        build_grid.SetActive(!build_grid.activeInHierarchy);
        build_canvas.SetActive(!build_canvas.activeInHierarchy);
        bc.enabled = !bc.enabled;
        build_window_open = !build_window_open;
        bs.Pause_Boxes();
        can_open_upgrade_window = !can_open_upgrade_window;
        
        
    }
}
