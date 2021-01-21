using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class customMove : MonoBehaviour
{

    Transform target; // a transform variable to store location of our target
    Path pathToFollow; // path variable to store the path created
    Seeker seeker;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;//storing enemy position
        AstarPath.active.Scan();//scanning the grid graph
        seeker = GetComponent<Seeker>();//this will find our path towards the enemy
        pathToFollow = seeker.StartPath(transform.position, target.position);//setting the path between our AI position and the enemy position
        StartCoroutine(moveTowards(this.transform));//this coroutine will make our player/AI move to the enemy position
    }

    IEnumerator moveTowards(Transform pos) 
    {
        while (true) //creation of infinte loop
        {
            List<Vector3> positns = pathToFollow.vectorPath;//creating a list of positions that converts our path to avector form
            for (int counter = 0; counter < positns.Count; counter++)//this loop is traversing for every posision with counter
            {
                while (Vector3.Distance(pos.position, positns[counter]) >= 0.5f)//while the distance of the enemy from the position of the ai is more than 0.5f
                {                                                            
                    pos.position = Vector3.MoveTowards(pos.position, positns[counter], 2f);//move the position of the ai to the position of the enemy
                    yield return new WaitForSeconds(0.2f);//wait 
                    pathToFollow = seeker.StartPath(pos.position, target.position);//making sure that the ai will not follow the path back when its done by removing the path
                    yield return seeker.IsDone();//making sure that the attempt to find it is done when it is on the enemy pos
                }
            }
            yield return null;
        }
    }
}

    





