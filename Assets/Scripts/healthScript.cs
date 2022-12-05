using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthScript : MonoBehaviour
{
    int health = 100;
    [SerializeField] GameObject healthBar, healthValue;

    public void NewValue(int val)
    {
        health += val;
        health = Mathf.Clamp(health, 0, 100);

        float posX = (health * 3 / 2) - 150;
        float width = health * 3;

        healthBar.GetComponent<RectTransform>().localPosition = new Vector2(posX, 0);
        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 16.362f);

        healthValue.GetComponent<TextMeshProUGUI>().SetText(health.ToString());
    }

    public int GetHealth(){
        return health;
    }

    public void SetHealth(int playerHealth){
        health = playerHealth;
        NewValue(0);
    }
}
