using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{ 
    public bool isHeldDown = false;
   
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
