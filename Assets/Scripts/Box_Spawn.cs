using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Box_Spawn : MonoBehaviour {

    public GameObject box;
    public int boxes_per_second = 0;
    private int amount_pooled = 105;
    private float timer = 0;
    private List<GameObject> boxes;

    void Start()
    {
        
        boxes = new List<GameObject>();
        for(int i = 0; i < amount_pooled; i++)
        {
            GameObject obj = (GameObject)Instantiate(box, transform);
            obj.SetActive(false);
            boxes.Add(obj);
        }
        PlayerPrefs.SetInt("money", 0);
    }
    void LateUpdate()
    {
        if(boxes_per_second > 0)
        {
            if (timer >= (1.0 / boxes_per_second))
            {
                Send_Box();
                timer = 0;
            }
            timer += Time.deltaTime;
        }
        
    }

    void OnMouseUp()
    {
        Send_Box();
    }

    public void Send_Box()
    {
        for(int i = 0; i < boxes.Count; i++)
        {
            if (!boxes[i].activeInHierarchy)
            {
                boxes[i].transform.position = transform.position;
                boxes[i].transform.rotation = transform.rotation;
                Rigidbody2D rb = boxes[i].GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(0, 0);
                rb.gravityScale = 1;
                boxes[i].SetActive(true);
                break;

            }
        }
    }

    public void Pause_Boxes()
    {
        for (int i = 0; i < boxes.Count; i++)
        {
            boxes[i].SetActive(false);
        }
    }
}
