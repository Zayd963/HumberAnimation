using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;
public class FaceTracker : MonoBehaviour
{
    private WebCamTexture webcamTexture;
    private CascadeClassifier cascade;
    public OpenCvSharp.Rect faceRect;
    public bool faceExists = false;

    [SerializeField]
    private int minFaceNeighbours;
    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        webcamTexture = new WebCamTexture(devices[0].name, 1920, 1080, 60);
        webcamTexture.Play();
        GetComponent<Renderer>().material.mainTexture = webcamTexture;
        cascade = new CascadeClassifier(Application.streamingAssetsPath + "/haarcascade_frontalface_default.xml");
    }

    // Update is called once per frame
    void Update()
    {
        Mat frame = OpenCvSharp.Unity.TextureToMat(webcamTexture);
        FindNewFace(frame);
        Display(frame);
    }

    private void FindNewFace(Mat frame)
    {
        var faces = cascade.DetectMultiScale(frame, 1.1, minFaceNeighbours, HaarDetectionType.ScaleImage);

        if (faces.Length >= 1)
        {
            faceRect = faces[0];
            faceExists = true;
        }
        else
            faceExists = false;
    }

    private void Display(Mat frame)
    {
        if (faceExists)
        {
            frame.Rectangle(faceRect, new Scalar(255, 0, 0), 2);
            Texture newTexure = OpenCvSharp.Unity.MatToTexture(frame);
            GetComponent<Renderer>().material.mainTexture = newTexure;
        }
        else
            GetComponent<Renderer>().material.mainTexture = webcamTexture;
    }
    
}
