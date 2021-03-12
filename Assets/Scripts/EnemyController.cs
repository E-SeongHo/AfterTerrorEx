using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1f;
    public int maxHealth = 5;
    int currentHealth;
    public int health
    {
        get
        {
            return currentHealth;
        }
    } 
    GameObject myButton = null;
    char myColor;

    //THIS OBJECT'S KEY
    //Red button key = A
    //Green button key = S
    //Blue button key = D


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1*speed*Time.deltaTime,0,0);
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    static char ConvertColorToKey(char color)
    {   
        // myColor를 실인자로 주는 것을 원칙
        switch(color)
        {
            case 'r':
                return 'A';
            case 'g':
                return 'S';
            case 'b':
                return 'D';
        }
        return 'F'; // 예외경우 대비(그럴 일 없는데 컴파일 에러나니까 했다)
    }
    public void GenerateButton(GameObject button, char color)
    {
        Vector2 position = GetComponent<Rigidbody2D>().position;
        // 버튼 생성이 Enemy객체에 필요하면 myButton 오브젝트에 할당
        // Enemy의 자식객체로 구현하여 Enemy객체와 같이 움직이도록 구현
        GameObject newButton = Instantiate(button, position + Vector2.up * 1.5f, Quaternion.identity);
        myButton = newButton;
        myButton.transform.parent = gameObject.transform;
        myColor = color;    // 버튼의 색상 저장 -> Delete에 이용

    }
    public bool TryDelete(char colorKey)
    {
        //입력된 키가 뭔지 판단해서 이 객체의 해당 색깔 키와 일치하면 딜리트 허용
        if (colorKey == ConvertColorToKey(myColor))
        {
            //올바른 키 입력이면 Delete 허용
            //myButton = null;
            Destroy(myButton); // Destory보다는 null로 처리하고 안보이게 하는게 좋을듯?

            //버튼이 삭제 되었으면 true 반환
            return true;
        }
        else return false; // 올바르지 않은 키 입력이면 fasle 반환
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            // animator 처리 부분 (After Time)
        }
        // Clamp 메소드 이용, 최대값이 maxHealth넘지 못하게 구현 
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + " / " + maxHealth);
    } 
}
