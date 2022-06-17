using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] models;

    [SerializeField]
    private ParticleSystem smoke;

    private float timer = 0;
    
    public float timeToSwitchModels = 5f;

    private int currentModelIndex = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < models.Length; i++)
        {
            if (i == currentModelIndex)
            {
                models[i].SetActive(true);
            }
            else
                models[i].SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

      

        if (timer > timeToSwitchModels)
        {
            for (int i = 0; i < models.Length; i++)
            {
                if (i == currentModelIndex)
                {
                    models[i].SetActive(true);

                }
                else
                    models[i].SetActive(false);


            }
            smoke.Play();
            if (currentModelIndex < models.Length - 1)
            {
                StartCoroutine(ChangeModel());
            }
            else
            {
                currentModelIndex = 0;
            }

           
            timer = 0;
        }

        Debug.Log(currentModelIndex);
    }

    private IEnumerator ChangeModel()
    {
        yield return new WaitForSeconds(0.0f);
        currentModelIndex++;
    }
}
