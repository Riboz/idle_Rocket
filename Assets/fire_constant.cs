using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class fire_constant : MonoBehaviour
{
    // Start is called before the first frame update
    float fire_constant_value;  
   
    // Update is called once per frame
 
    void Awake()
    {
      StartCoroutine(fire());
    }
   public IEnumerator fire()
    {
        for(int i=0;i<=1;i--)
        {
             this.transform.DOScaleY(1,0.5f);
            yield return new WaitForSeconds(0.5f);
                   this.transform.DOScaleY(1.6f,0.5f);
         
    
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
