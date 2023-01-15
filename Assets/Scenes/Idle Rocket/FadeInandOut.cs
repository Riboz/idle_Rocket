using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInandOut : MonoBehaviour
{
    public BackgroundScroller BackgroundScroller;
    public ScrollManager ScrollManager;
    
    public GameObject[] backgroundsList;
    public int pointInArray;
    
    public int bruhPls;
    public float levelTimer;
    void Start()
    {
        levelTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pointInArray = (int)levelTimer / 10;
        
        if (pointInArray != bruhPls)
        {
            backgroundsList[pointInArray].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            StartCoroutine(FadeIn(backgroundsList[pointInArray].GetComponent<SpriteRenderer>()));
            StartCoroutine(FadeOut(backgroundsList[pointInArray-1].GetComponent<SpriteRenderer>()));
            BackgroundScroller.nextScrollingPlane = true;
            ScrollManager.nextScrollingBackground = true;
        }
        

        bruhPls = pointInArray;

    }
    
    private IEnumerator FadeIn(SpriteRenderer spriteRenderer)
    {
        float alphaVal = spriteRenderer.color.a;
        Color tmp = spriteRenderer.color;
 
        while (spriteRenderer.color.a < 1)
        {
            alphaVal += 0.01f;
            tmp.a = alphaVal;
            spriteRenderer.color = tmp;
 
            yield return new WaitForSeconds(0.01f); // update interval
        }
    }
 
    private IEnumerator FadeOut(SpriteRenderer spriteRenderer)
    {
        float alphaVal = spriteRenderer.color.a;
        Color tmp = spriteRenderer.color;
        Debug.Log("annen");
 
        while (spriteRenderer.color.a > 0)
        {
            alphaVal -= 0.01f;
            tmp.a = alphaVal;
            spriteRenderer.color = tmp;
            
 
            yield return new WaitForSeconds(0.01f); // update interval
        }
    }
}
