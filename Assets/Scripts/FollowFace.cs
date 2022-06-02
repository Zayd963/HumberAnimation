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

    private Transform mainCamera;

    private float previousFaceSize;
    private float currentFaceSize;

    // Start is called before the first frame update
    void Start()
    {
        faceTracker = GameObject.FindGameObjectWithTag("FaceTracker").GetComponent<FaceTracker>();
        mainCamera = Camera.main.transform;
        previousFaceSize = 1;
        currentFaceSize = previousFaceSize;
    }

    // Update is called once per frame
    void Update()
    {
        currentFaceSize = (faceTracker.faceRect.Size.Height);
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

           

          
            //float norm = (currentFaceSize - previousFaceSize);
            //float step = 5 * Time.deltaTime;

            //if (norm > differenceNeededToChangeCameraDepth || norm < -differenceNeededToChangeCameraDepth) 
            //{
            //    mainCamera.position = Vector3.SmoothDamp(mainCamera.position, new Vector3(0, 0,
            //        Mathf.Clamp(mainCamera.position.z - norm, -3.2f, 6f)), ref refVec, cameraSmoothing);
            //}
            //mainCamera.position = new Vector3(0, 0, mainCamera.position.z);


        }

        previousFaceSize = currentFaceSize;
    }
}
