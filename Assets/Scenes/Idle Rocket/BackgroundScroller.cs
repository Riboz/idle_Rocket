using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public FadeInandOut backgroundScript;

    public GameObject[] scrollingPlaneObject;
    
    public float scrollSpeed = 1f;
    public float mainScrollSpeed = 1f;
    public float clickedScrollSpeed = 1.5f;
    public bool isHeldDown = false;
    public bool nextScrollingPlane;

    private float offset;
    private Material mat;   
    
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    
    void Update()
    {
        if (nextScrollingPlane)
        {
            Debug.Log("yani noluyo simdi aminakoyim?");
            
            //scrollingPlaneObject[backgroundScript.pointInArray].SetActive(true);
            //scrollingPlaneObject[backgroundScript.pointInArray-1].SetActive(false);
            nextScrollingPlane = false;
        }
        if (isHeldDown == true)
        { 
            scrollSpeed = clickedScrollSpeed;
            backgroundScript.levelTimer += Time.deltaTime;
        }
        else scrollSpeed = mainScrollSpeed;
        
        offset += (Time.deltaTime * scrollSpeed) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
    
    public void onPress ()
    {
        isHeldDown = true;
        Debug.Log(isHeldDown);
    }
   
    public void onRelease ()
    {
        isHeldDown = false;
        Debug.Log(isHeldDown);
    }
    
}
