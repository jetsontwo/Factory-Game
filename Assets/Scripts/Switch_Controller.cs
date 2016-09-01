using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Switch_Controller : MonoBehaviour {

    public Conveyor_Switch cs;
    private string cur_pos;
    public Sprite top_sprite, bottom_sprite;
    private Image im;
	
    void Start()
    {
        cur_pos = "top";
        im = GetComponent<Image>();
    }

	// Update is called once per frame
	void Update () {
	    if(cur_pos == "top")
        {
            im.sprite = top_sprite;
        }
        else
        {
            im.sprite = bottom_sprite;
        }
	}

    public void Change_Conveyor()
    {
        if(cur_pos == "top")
        {
            cs.switch_track = true;
            cur_pos = "bottom";
        }
        else
        {
            cs.switch_track = false;
            cur_pos = "top";
        }
    }
}
