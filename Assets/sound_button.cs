using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sound_button : MonoBehaviour
{
    // Start is called before the first frame update
    bool mute=true;
    public Sprite nomute,muted;
    public GameObject aha ,baha;

    // Update is called once per frame
   public void button_sound()
    {
         mute=!mute;
         if(mute)
         {
            aha.SetActive(false);
            baha.SetActive(false);
          this.GetComponent<Image>().sprite=muted;
         }
         else
         {
            aha.SetActive(true);
            baha.SetActive(true);
             this.GetComponent<Image>().sprite=nomute;
         }
    }
}
