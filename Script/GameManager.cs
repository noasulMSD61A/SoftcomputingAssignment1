using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    GameObject AI;
    GameObject Obstacles;
    void Start()
    {
        AI = Resources.Load("AI") as GameObject;
        Instantiate(AI, new Vector3(-40,40,0), Quaternion.identity);

        Obstacles = Resources.Load("Obstacle") as GameObject;
        for (int i = 0; i <= 4; i++)
        {
            Instantiate(Obstacles, new Vector3(Random.Range(-48f, 48f), Random.Range(-48f, 48f), 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
