using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    public FadeInandOut FadeInandOut;
    
    public GameObject[] scrollingBackgrounds;
    public bool nextScrollingBackground;
    public bool restartScroll;
    void Start()
    {
        
    }

    void Update()
    {
        if (nextScrollingBackground)
        {
            scrollingBackgrounds[FadeInandOut.pointInArray].SetActive(true);
            scrollingBackgrounds[FadeInandOut.pointInArray-1].SetActive(false);
            nextScrollingBackground = false;
        }

        if (restartScroll)
        {
            //scrollingBackgrounds[FadeInandOut.pointInArray].SetActive(false);
            scrollingBackgrounds[0].SetActive(true);
            restartScroll = false;
        }
    }
}
