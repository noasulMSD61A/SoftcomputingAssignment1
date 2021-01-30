using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Obstacle;
    private GameObject AI;


    void Start()
    {
        Obstacle = Resources.Load("Obstacle") as GameObject;
        AI = Resources.Load("AI") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddObstacle()
    {
        int xpos = Random.Range(-49, 49);
        int ypos = Random.Range(-49, 49);
        Instantiate(Obstacle, new Vector2(xpos, ypos), Quaternion.identity);
    }

    public void AddAI()
    {
        int xpos = Random.Range(-49, 49);
        int ypos = Random.Range(-49, 49);
        Instantiate(AI, new Vector2(xpos, ypos), Quaternion.identity);
    }

    public void scan()
    {
        AstarPath.active.Scan();
    }


}
