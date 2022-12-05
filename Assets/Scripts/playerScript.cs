using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class playerScript : MonoBehaviour
{
    [SerializeField] float minX, maxX, minY, maxY;
    [SerializeField] GameObject posXTxt, posYTxt;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 playerPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = new Vector2(Mathf.Clamp(playerPos.x, minX, maxX), Mathf.Clamp(playerPos.y, minY, maxY));

            posXTxt.GetComponent<TextMeshProUGUI>().SetText($"X={Math.Round(transform.position.x, 2)}");
            posYTxt.GetComponent<TextMeshProUGUI>().SetText($"Y={Math.Round(transform.position.y, 2)}");
        }
    }
    public Vector2 GetPosition(){
        return transform.position;
    }

    public void SetPosition(Vector2 pos){
        transform.position = pos;
    }
}
