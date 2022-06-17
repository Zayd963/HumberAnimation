
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowFaceAr : MonoBehaviour
{
    private Transform face;
    public Text debugText;
    public Text sensitivityText;
    public Text zDepthText;

    [SerializeField]
    private Transform sphere;

    [SerializeField]
    private float sensitivity = 100;
    [SerializeField]
    private float zDepth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        face = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //if (face)
        //{
        //    transform.LookAt(face);


        //}

        if (face)
        {
            //transform.localEulerAngles = new Vector3(face.localEulerAngles.x, face.localEulerAngles.y + 180, face.localEulerAngles.z);
            Vector3 faceScreenposition = Camera.main.ViewportToScreenPoint(face.position);
            faceScreenposition.z = zDepth;
            Vector3 look = faceScreenposition / sensitivity;
            transform.LookAt(look);
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            debugText.text = faceScreenposition.ToString();
            sensitivityText.text = sensitivity.ToString();
            zDepthText.text = zDepth.ToString();

            sphere.position = new Vector3(look.x, 0, 10);
        }
    }

    public void AdjustSensitivityUp()
    {
        sensitivity += 10f;
    }

    public void AdjustSensitivityDown()
    {
        sensitivity -= 10f;
    }

    public void AdjustzDepthUp()
    {
        zDepth += 10f;
    }

    public void AdjustzDepthDown()
    {
        zDepth -= 10f;
    }
}
