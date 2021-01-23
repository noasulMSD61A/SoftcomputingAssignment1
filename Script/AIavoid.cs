using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIavoid : MonoBehaviour
{
    
    Seeker seeker;
    GameObject[] AIobj;//array to store game objects

    // Start is called before the first frame update
    void Start()
    {
        AIobj = GameObject.FindGameObjectsWithTag("ai");//storing every gameobject with the tag ai                                        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject tes in AIobj)//traverse in array
        { 
            if (tes != gameObject)
            {
                float Avoidance = Vector3.Distance(tes.transform.position, this.transform.position);//distance between thae ais 

                if (Avoidance <= 2f) //if distance is less than 2
                {
                    Vector3 direction = transform.position - tes.transform.position;
                    transform.Translate(direction * 0.2f);
                }
            }

        }

    }


    //This script beneath work as well but i am not sure if it is a 100% correct


    /* public void newPath()
     {
         foreach (GameObject i in AI)
         { // traversing through the ai array
             AstarPath.active.UpdateGraphs(i.GetComponent<Collider>().bounds);

         }

     }


     IEnumerator pathcreate1()
     {
         while (true)
         {
             foreach (GameObject i in AI)
             { // traversing through the ai array
                 AstarPath.active.UpdateGraphs(i.GetComponent<BoxCollider2D>().bounds);
                 yield return seeker.IsDone();
             }
             yield return null;
         }


     }*/
}
