using UnityEngine;
using System.Collections;

public class Conveyor_Switch : MonoBehaviour {

    public Sprite Sprite_1, Sprite_2;
    public string tag_1, tag_2;
    public bool switch_track;
    private SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        switch_track = false;
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (switch_track)
        {
            sr.sprite = Sprite_2;
            tag = tag_2;
        }
        else
        {
            sr.sprite = Sprite_1;
            tag = tag_1;
        }
	}

}
