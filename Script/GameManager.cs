using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    GameObject AI;
    void Start()
    {
        

        AI = Resources.Load("AI") as GameObject;
        
        Instantiate(AI, new Vector3(5,5,0), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
