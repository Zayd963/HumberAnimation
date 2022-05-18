using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Transform follow;

    [SerializeField]
    private bool faceAwayFromTarget = false;


   
    // Start is called before the first frame update
    void Start()
    {
        follow = GameObject.FindGameObjectWithTag("Follow").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetToLookAt = new Vector3(follow.position.x, follow.position.y, follow.position.z);

        if (faceAwayFromTarget)
        {
            targetToLookAt.x *= -1;
            targetToLookAt.y *= -1;
        }


        transform.LookAt(targetToLookAt);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);



    }
}
