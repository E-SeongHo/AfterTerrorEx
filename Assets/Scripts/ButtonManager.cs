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
    List<GameObject> taggedObjects = new List<GameObject>(); // 초기화???
    GameObject target; // 버튼 생성시킬 객체선정 변수
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
            GameObject[] tagged = GameManager.Instance.MakeArrWithTag("Enemy");
            for(int i = 0; i < tagged.Length; i++)
            {
                taggedObjects.Add(tagged[i]);
            }
            target = GameManager.Instance.FindNearestObject(taggedObjects);           
            Debug.Log(target);
            GiveButton2(target); // 해당 오브젝트에 버튼 생성                      
        }
        else // 현재 프레임에 어떤 오브젝트에 버튼이 떠있으면
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                DeleteButton(target, 'A');
            } 
            if(Input.GetKeyDown(KeyCode.S))
            {
                DeleteButton(target, 'S');
            }
            if(Input.GetKeyDown(KeyCode.D))
            {
                DeleteButton(target, 'D');
            }
        }
        EnemyController enemyController = target.GetComponent<EnemyController>();
        if(enemyController.health <= 0)
        {
            taggedObjects.Remove(target);
            Debug.Log("suc");
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
    void GiveButton2(GameObject target)
    {
        int random = Random.Range(0,3);
        char color = 'r';
        switch(random)
        {
            case 0 :
                button = button_red;
                color = 'r';
                break;
            case 1 :
                button = button_green;
                color = 'g';
                break;
            case 2 :
                button = button_blue;
                color = 'b';
                break;
        }
        EnemyController enemyController = target.GetComponent<EnemyController>();
        enemyController.GenerateButton(button, color);
        button_ON = true;
    }
    void DeleteButton(GameObject target, char button)
    {
        EnemyController enemyController = target.GetComponent<EnemyController>();
        // TryDelete : Delete 성공시 true 반환하므로 Delete 성공 시 button_ON = false로 설정
        bool success = enemyController.TryDelete(button);
        if(success)
        {
            button_ON = false;
            enemyController.ChangeHealth(-1);
        }
    }


}
