using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    private Vector2 playerPos;
    private Vector2 areaPos;

    public GameObject area;
    public GameObject player;
    public GameObject button;

    bool isAreaRotated = false;
    bool isMouseButtonDown = false; 


    void Start()
    {
        Debug.Log("Main Events - starting");

        area = GameObject.Find("Area");
        player = GameObject.Find("Player");
        button = GameObject.Find("Button");
        button.gameObject.SetActive(false);

        playerPos = player.GetComponent<Transform>().position;
        
        //körív beállítása a játékoshoz viszonyítva
        //area = körív
        areaPos = playerPos;
        areaPos.y -= 2; 
        area.GetComponent<Transform>().position = areaPos;
    }

    void Update()
    {
        //lenyomás / tartás
        if(Input.GetMouseButtonDown(0) || isMouseButtonDown)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 inputWorldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            area.GetComponent<areaRotation>().setPlayerPosition(playerPos);
            area.GetComponent<areaRotation>().Rotate(inputWorldPosition);

            isMouseButtonDown = true;
            isAreaRotated = true;
        }

        //elengedés
        if(Input.GetMouseButtonUp(0))
        {
            isMouseButtonDown = false;
        }
    }
}
