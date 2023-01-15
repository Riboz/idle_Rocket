using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class background_behaviour : MonoBehaviour
{
    public GameObject[] BackgroundArray;
    [SerializeField] private Color canvasgroupA, canvasgroupB;

    [SerializeField] private int pointInArray;

    public float fadeInVariable = 0;
    public float fadeOutVariable = 1;
    
    void Start()
    {
        pointInArray = -1;
        BackgroundArray[0].SetActive(true);
        //BackgroundArray[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
    }

    
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            pointInArray += 1;
            SetCanvasGroups();
        }
        FadeOut(canvasgroupA);
        FadeIn(canvasgroupB);
    }

    public void FadeIn(Color canvasgroup)
    {
        if (canvasgroup.a < 1)
        {
            fadeInVariable += Time.deltaTime / 2;
            canvasgroup = new Color(1, 1, 1, fadeInVariable);
        }

        fadeInVariable = 1;
    }

    public void FadeOut(Color canvasgroup)
    {
        if (canvasgroup.a > 0)
        {
            fadeOutVariable -= Time.deltaTime / 2;
            canvasgroup = new Color(1, 1, 1, fadeOutVariable);
        }

        fadeOutVariable = 0;
    }

    public void SetCanvasGroups()
    {
        canvasgroupA = BackgroundArray[pointInArray].GetComponent<SpriteRenderer>().color;
        canvasgroupA = new Color(1, 1, 1, 1);
        canvasgroupB = BackgroundArray[pointInArray+1].GetComponent<SpriteRenderer>().color;
        canvasgroupB = new Color(1, 1, 1, 0);
        BackgroundArray[pointInArray].SetActive(true);
        BackgroundArray[pointInArray+1].SetActive(true); 
    }
}
