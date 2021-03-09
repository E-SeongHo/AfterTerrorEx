using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
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
        if(!button_ON) // 현재 프레임에 어떤 오브젝트에도 버튼이 떠있지 않으면
        {
            if(Input.GetMouseButtonDown(0)) // 오브젝트중 가장 가까운 객체 선정
            {
                GiveButton2(); // 해당 오브젝트에 버튼 생성
            }
        }
        else // 현재 프레임에 어떤 오브젝트에 버튼이 떠있으면
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                DeleteButton('A');
                Debug.Log("A");
            } 
            if(Input.GetKeyDown(KeyCode.S))
            {
                DeleteButton('S');
                Debug.Log("S");
            }
            if(Input.GetKeyDown(KeyCode.D))
            {
                DeleteButton('D');
                Debug.Log("D");
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
        button_ON = true;
    } 
    void GiveButton2()
    {
        GameObject who = GameObject.Find("Enemy");
        button = button_red;
        EnemyController enemyController = who.GetComponent<EnemyController>();
        enemyController.GenerateButton(button,'r');
        button_ON = true;
    }
    void DeleteButton(char button)
    {
        GameObject who = GameObject.Find("Enemy");
        EnemyController enemyController = who.GetComponent<EnemyController>();
        // TryDelete : Delete 성공시 true 반환하므로 Delete 성공 시 button_ON = false로 설정
        button_ON = !(enemyController.TryDelete(button));
    }


}
