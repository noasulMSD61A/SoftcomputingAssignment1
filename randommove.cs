using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randommove : MonoBehaviour
{
    // Use this for initialization

    public Transform targetPos; //assign these in inspector with "waypoint" gameobjects or something.
    public Transform startPos;

    bool towards = true;
    public float speed = 0.1f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (towards)
        {
            transform.LookAt(targetPos.position);
            transform.position += transform.forward * speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, targetPos.position) < 1.0f)
            {
                towards = false;
            }
        }
        else
        {
            transform.LookAt(startPos.position);
            transform.position += transform.forward * speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, startPos.position) < 1.0f)
            {
                {
                    towards = true;
                }
            }
        }
    }
}
