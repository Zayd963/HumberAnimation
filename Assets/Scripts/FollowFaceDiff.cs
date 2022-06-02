using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFaceDiff : MonoBehaviour
{
    private FaceTracker faceTracker;

    private float facePosition;

    [SerializeField]
    private float rotationSmoothing;

    private float currentPosition;
    private float lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        faceTracker = GameObject.FindGameObjectWithTag("FaceTracker").GetComponent<FaceTracker>();
        lastPosition = faceTracker.faceRect.Center.X;
        currentPosition = lastPosition;
    }

    // Update is called once per frame
    void Update()
    {
        

        currentPosition = faceTracker.faceRect.Center.X;

        float norm = currentPosition - lastPosition;

        float newRotation = Mathf.Clamp(transform.localEulerAngles.y - norm, -90, 90);
        float zero = 0;

        if (norm < 50)
        {
            //transform.localEulerAngles = new Vector3(0, Mathf.SmoothDamp(transform.localEulerAngles.y, newRotation,
               // ref zero, rotationSmoothing), 0);

            //transform.rotation = Quaternion.FromToRotation(transform.localEulerAngles,
            //    new Vector3(0, Mathf.SmoothDamp(transform.localEulerAngles.y, newRotation,
            //    ref zero, rotationSmoothing), 0));

            transform.rotation = Quaternion.AngleAxis(newRotation, Vector3.up);

            Debug.Log(norm);
        }

        

        lastPosition = currentPosition;
    }
}
