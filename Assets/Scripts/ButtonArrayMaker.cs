using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonArrayMaker : MonoBehaviour
{
    public GameObject button_red;
    public GameObject button_green;
    public GameObject button_blue;
    Rigidbody2D rigidbody2d;
    GameObject button;
    bool button_ON = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!button_ON)
        {
            if(Input.GetMouseButtonDown(0))
            {
                GiveButton2();
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                
                button_ON = false;
            }    
        }
        
    }
    void GiveButton1()
    {
        GameObject who = GameObject.Find("Enemy");
        rigidbody2d = who.GetComponent<Rigidbody2D>();
        Vector2 position = rigidbody2d.position;
        button = Instantiate(button_red,position + Vector2.up*2f,
        Quaternion.identity);
        button_ON=true;
    } 
    void GiveButton2()
    {
        GameObject who = GameObject.Find("Enemy");
        button = button_red;
        EnemyController enemyController = who.GetComponent<EnemyController>();
        enemyController.GenerateButton(button,'r');
        button_ON=true;
    }
    void DeleteButton()
    {
        
    }


}
