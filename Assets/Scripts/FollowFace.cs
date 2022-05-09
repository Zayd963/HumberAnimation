using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFace : MonoBehaviour
{
    private FaceTracker faceTracker;

    [SerializeField]
    private float xClampMin = -10f;
    [SerializeField]
    private float xClampMax = 10f;

    [SerializeField]
    private float yClampMin = -5f;
    [SerializeField]
    private float yClampMax = 5f;

    // Start is called before the first frame update
    void Start()
    {
        faceTracker = GameObject.FindGameObjectWithTag("FaceTracker").GetComponent<FaceTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (faceTracker.faceExists)
        {
            Vector3 facePositionOnScreen = new Vector3(faceTracker.faceRect.Center.X, faceTracker.faceRect.Center.Y,
                transform.position.z);

            Vector3 facePositionInWorld = Camera.main.ScreenToWorldPoint(facePositionOnScreen);
            Vector3 refVec = Vector3.zero;

            Vector3 targetPosition = new Vector3(facePositionInWorld.x, facePositionInWorld.y, transform.position.z);

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref refVec, 0.1f);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, xClampMin, xClampMax), 
                Mathf.Clamp(transform.position.y, yClampMin, yClampMax),
                transform.position.z);
        }

    }
}
