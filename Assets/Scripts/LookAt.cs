using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Transform follow;

    // Start is called before the first frame update
    void Start()
    {
        follow = GameObject.FindGameObjectWithTag("Follow").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetToLookAt = new Vector3(follow.position.x, follow.position.y, follow.position.z);

        transform.LookAt(targetToLookAt);
    }
}
