using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1f;
    GameObject myButton;
    char myColor;

    //THIS OBJECT'S KEY
    //Red button key = A
    //Green button key = S
    //Blue button key = D


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1*speed*Time.deltaTime,0,0);

    }
    public void GenerateButton(GameObject button, char color)
    {
        Vector2 position = GetComponent<Rigidbody2D>().position;
        myButton = Instantiate(button, position + Vector2.up * 1.5f, Quaternion.identity);
        myButton.transform.parent = gameObject.transform;
        myColor = color;    
    }
    public void TryDelete(char colorKey)
    {
        //입력된 키가 뭔지 판단해서 해당 객체의 키와 일치하면 딜리트 허용
        if()
        myButton = null;
    }
}
