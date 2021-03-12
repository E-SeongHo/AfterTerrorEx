using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    static GameManager instance;
    public static GameManager Instance
    {
        get {return instance;}
    }
    GameObject mainCharacter;
    
    private void Awake() 
    {
        mainCharacter = GameObject.Find("Tongkee");

        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[] MakeArrWithTag(string tag)
    {
        GameObject[] tagged = GameObject.FindGameObjectsWithTag(tag);
        return tagged;
    }
    public GameObject FindNearestObject(List<GameObject> tagged)
    {
        GameObject nearestTarget = null;
        float minDistance = Mathf.Infinity; 
        Vector2 currentPos= mainCharacter.GetComponent<Transform>().position;
        foreach(GameObject target in tagged)
        {
            Vector2 targetPos = target.GetComponent<Transform>().position;
            float distance = Vector2.Distance(targetPos, currentPos);
            if(distance < minDistance)
            {
                minDistance = distance; // 거리값 필요시 사용
                nearestTarget = target;
            } 
        }
        return nearestTarget;
    }
}
