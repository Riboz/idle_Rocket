using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundScroller : MonoBehaviour
{
    public FadeInandOut backgroundScript;
    public bool can_;

    public GameObject[] scrollingPlaneObject;
    public current_rocket rocketing;
    public float scrollSpeed = 1f;
    public  static float mainScrollSpeed = 1f;
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
        if(current_rocket.Game_start)
        {
            mainScrollSpeed=20;
    
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
      else
      {
         mainScrollSpeed=0;
         
      }

    }
    
    public void onPress ()
    {
       
if(current_rocket.Game_start)
        {
     
        isHeldDown = true;
        
        }
    }
    
   
    public void onRelease ()
    { 
if(current_rocket.Game_start)
        {

        isHeldDown = false;
       
        }
    }
}
