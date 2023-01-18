using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class fire_constant : MonoBehaviour
{
    // Start is called before the first frame update
   
   public float fire_constant_value;
    // Update is called once per frame
 
   
   public IEnumerator fire()
    {
        for(int i=0;i<=1;i--)
        {
          if(fire_constant_value!=2.2f)  this.transform.DOScaleY(1,0.25f);
        else{this.transform.DOScaleY(1.5f,0.25f);}
        
            yield return new WaitForSeconds(0.25f);

            this.transform.DOScaleY(fire_constant_value,0.25f);
         
    
            yield return new WaitForSeconds(0.25f);
        }
        
    }
}
