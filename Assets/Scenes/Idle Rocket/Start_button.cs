using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Start_button : MonoBehaviour
{
    [SerializeField]private Text start_Text;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(the_text());
    }
  
     IEnumerator the_text()
     {
      while(true)
      {
        start_Text.transform.DOScale(new Vector3(1.2f,1.2f,0),1f);
        yield return new WaitForSeconds(1f);
        start_Text.transform.DOScale(new Vector3(1f,1f,0),1f);
        yield return new WaitForSeconds(1f);
      }
     }

    
}
