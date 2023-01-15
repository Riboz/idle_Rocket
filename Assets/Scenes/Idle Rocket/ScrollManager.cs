using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    public FadeInandOut FadeInandOut;
    
    public GameObject[] scrollingBackgrounds;
    public bool nextScrollingBackground;
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
    }
}
