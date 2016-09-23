using UnityEngine;
using System.Collections;

public class UI_Script : MonoBehaviour {
    public Upgrade_Menu um;
    public Transform conveyor_holder;
    public Build_Controller bc;
    public Box_Spawn bs;
    public GameObject build_grid, build_canvas;
    public GameObject created_conveyor, selected_object;
    private Collider2D created_conveyor_collider;
    private RaycastHit2D hit_collider;
    private bool build_window_open;
    private Vector3 mouselocation;
    private float x, y;

    public void Open_Upgrade_Window()
    {
        um.enabled = !um.enabled;
    }

    public void Create_Conveyor(GameObject conveyor_prefab)
    {
        created_conveyor = (GameObject) Instantiate(conveyor_prefab, conveyor_holder);
        created_conveyor.name = conveyor_prefab.name;
        created_conveyor_collider = created_conveyor.GetComponent<Collider2D>();
        selected_object = created_conveyor;

    }

    public void Open_Build_Window()
    {
        
        build_grid.SetActive(!build_grid.activeInHierarchy);
        build_canvas.SetActive(!build_canvas.activeInHierarchy);
        bc.enabled = !bc.enabled;
        build_window_open = !build_window_open;
        bs.Pause_Boxes();
    }

    void Update()
    {
        if (build_window_open)
        {
            if (selected_object != null)
            {
                selected_object.transform.position = new Vector3(mouselocation.x, mouselocation.y, 0);
                bc.conveyor_created = selected_object;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                print(mouselocation.x + "x " + mouselocation.y + "y");
                hit_collider = Physics2D.Raycast(new Vector2(mouselocation.x, mouselocation.y), Vector2.zero, 0f, 5);
                selected_object = hit_collider.collider.gameObject;
                BoxCollider2D bc = selected_object.GetComponent<BoxCollider2D>();
                bc.enabled = false;
            }
            mouselocation = Camera.current.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void Show_Build_Colliders()
    {

    }
}
