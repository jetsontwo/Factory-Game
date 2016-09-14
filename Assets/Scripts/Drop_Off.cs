using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Drop_Off : MonoBehaviour {

    public int price_per_box;
    private int current_money;
    public Text score;

    void Update()
    {
        current_money = PlayerPrefs.GetInt("money");
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        score.text = "Money: $" + (current_money + price_per_box);
        PlayerPrefs.SetInt("money", current_money + price_per_box);
        Destroy(c.gameObject);
        
    }
}
