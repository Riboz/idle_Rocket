using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class the_Button_interaction : MonoBehaviour
{
    // Start is called before the first frame update
    public Image rocket_scroll,planet_scroll,option_scroll;
    public Button rocketb,planetb,optionb;
    public void rocket_panel()
    {
        StartCoroutine(rocket_button());
        rocketb.enabled=false;
        optionb.enabled=false;
        planetb.enabled=false;
        
    }
     public void planet_panel()
    {
        StartCoroutine(planet_button());
        rocketb.enabled=false;
        optionb.enabled=false;
        planetb.enabled=false;
        
    }
    public void option_panel()
    {
        StartCoroutine(option_button());
        rocketb.enabled=false;
        optionb.enabled=false;
        planetb.enabled=false;
        
    }
    public void exit_buttons()
    {
        StartCoroutine(exit_button());
        rocketb.enabled=true;
        optionb.enabled=true;
        planetb.enabled=true;
        
    }
    public IEnumerator exit_button()
    {
         rocket_scroll.transform.DOMoveX(-200,0.5f);
         planet_scroll.transform.DOMoveX(-250,0.5f);
         option_scroll.transform.DOMoveX(-200,0.5f);
         yield break;
    }
   public IEnumerator rocket_button()
   {
     rocket_scroll.transform.DOMoveX(150,0.5f);
     yield break;
   }
   public IEnumerator planet_button()
   {
     planet_scroll.transform.DOMoveX(200,0.5f);
     yield break;
   }
   public IEnumerator option_button()
   {
     option_scroll.transform.DOMoveX(150,0.5f);
     yield break;
   }

}
