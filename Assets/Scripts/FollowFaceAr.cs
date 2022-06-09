
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowFaceAr : MonoBehaviour
{
    private Transform face;
    public Text debugText;

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
            transform.LookAt(faceScreenposition / 100);
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            debugText.text = faceScreenposition.ToString();
        }
    }
}
