using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class KU4PatrolBehaviourScript : MonoBehaviour
{
    public List<Transform> waypoint;

    Seeker seeker;

    Path pathToFollow;
    







    // Start is called before the first frame update
    void Start()
    {





        seeker = GetComponent<Seeker>();
        StartCoroutine(pathing());


    }




    IEnumerator pathing()
    {
        
        
        pathToFollow = seeker.StartPath(transform.position, waypoint[1].position);
        yield return seeker.IsDone();
        StartCoroutine(updateGridGraph());
        StartCoroutine(movePlayer());


    }


    IEnumerator updateGridGraph()
    {
        while (true)
        {
            AstarPath.active.Scan();
            yield return null;
        }

    }



    //the code that is going to move my target.
    IEnumerator movePlayer()
    {


        print("Tomatoeesss");


        //Starting position , the list of positions & a boolean paramtere stating if the path is looped
        StartCoroutine(movePlayer(this.transform, waypoint, true));



        yield return null;

    }






    IEnumerator movePlayer(Transform t, List<Transform> points, bool loop)
    {
        List<Vector3> posns = pathToFollow.vectorPath;
        List<Transform> forwardpoints = points; // List of waypoints
        print("In Move Player");

        if (loop) // need to run idefinitely 
        {

            while (true)
            {
                for (int count = 0; count <= posns.Count; count++)
                {

                    foreach (Transform p in forwardpoints)
                    {



                        print(p + ": p position");

                        while (Vector3.Distance(t.position, p.position) >= 0.5f)

                        {
                            

                            t.position = Vector3.MoveTowards(posns[count], p.position, 1f);
                            yield return new WaitForSeconds(0.2f);
                            pathToFollow = seeker.StartPath(t.position, p.position);
                            yield return seeker.IsDone();
                            posns = pathToFollow.vectorPath;
                        }

                    }

                }

                //reverse point supplied here 1-5 reverse 5-1
                forwardpoints.Reverse();
                yield return null;

            }
        }



    }





}
