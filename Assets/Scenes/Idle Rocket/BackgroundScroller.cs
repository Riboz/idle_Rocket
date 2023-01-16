using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundScroller : MonoBehaviour
{
    public FadeInandOut backgroundScript;

    public GameObject[] scrollingPlaneObject;
    public current_rocket rocketing;
    public float scrollSpeed = 1f;
    public float mainScrollSpeed = 1f;
    public float clickedScrollSpeed = 1.5f;
    public bool isHeldDown = false;
    public bool nextScrollingPlane;

    private float offset;
    private Material mat;   
    bool  rocky=true;
    
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    
    void Update()
    {
        if(!current_rocket.Game_start)
        {
            mainScrollSpeed=0;
        }
         else
         {
            mainScrollSpeed=5f;
         }
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
        
        if(rocky)
        {
        for(int i=0;i<=rocketing.Fire_rocket_now.Length-1;i++)
        {
             rocketing.Fire_rocket_now[i].GetComponent<fire_constant>().change_constant(2f);
             StartCoroutine(rocketing.Fire_rocket_now[i].GetComponent<fire_constant>().fire());
        }
        rocky=false;
        }
                 rocketing.gameObject.transform.DOScale(new Vector3(1.1f,1.1f,0),0.3f);
        Debug.Log(isHeldDown);
       
    }
   
    public void onRelease ()
    {
        isHeldDown = false;
        Debug.Log(isHeldDown);
        if(!rocky)
        {
       for(int i=0;i<=rocketing.Fire_rocket_now.Length-1;i++)
        {
             rocketing.Fire_rocket_now[i].GetComponent<fire_constant>().change_constant(1.2f);

             StartCoroutine(rocketing.Fire_rocket_now[i].GetComponent<fire_constant>().fire());
        }
        rocky=true;
        
     }
                  rocketing.gameObject.transform.DOScale(new Vector3(1f,1f,0),0.3f);
    }
}
