using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraTest : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultTexture;

    public RawImage background;
    public AspectRatioFitter fit;

    Texture2D texture1;
    Texture2D texture2;

    public Material webCamTarget1;
    public Material webCamTarget2;

    // Start is called before the first frame update
    void Start()
    {
        defaultTexture = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if(devices.Length == 0)
        {
            Debug.Log("No Camera Available");
            camAvailable = false;
            return;
        }

        for(int i = 0; i < devices.Length; i++)
        {
            if(!devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);

            }
        }

        

        if (backCam == null)
        {
            Debug.Log("No Back Cam");
            return;
        }

        backCam.Play();
        
       
        background.texture = backCam;
        camAvailable = true;

        texture1 = new Texture2D(backCam.width, backCam.height, TextureFormat.ARGB32, false);
        texture2 = new Texture2D(backCam.width / 2, backCam.height / 2, TextureFormat.ARGB32, false);

        webCamTarget1.mainTexture = texture1;
        webCamTarget2.mainTexture = texture2;


    }

    // Update is called once per frame
    void Update()
    {
        if (!camAvailable)
            return;

        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);


        Color[] pixels1 = backCam.GetPixels(0, 0, texture1.width, texture1.height);
        Color[] pixels2 = backCam.GetPixels(texture2.width / 2, texture2.height / 2, texture2.width, texture2.height);

        texture1.SetPixels(pixels1);
        texture1.Apply();

        texture2.SetPixels(pixels2);
        texture2.Apply();
        
    }
}
