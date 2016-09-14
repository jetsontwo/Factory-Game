using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Box_Spawn : MonoBehaviour {

    public GameObject box;
    private int amount_pooled = 50;
    private int timer = 0;
    List<GameObject> boxes;

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
        if (timer >= 10)
        {
            Send_Box();
            timer = 0;
        }
        timer++;
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
}
