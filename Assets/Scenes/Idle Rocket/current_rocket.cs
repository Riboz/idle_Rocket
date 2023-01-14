using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class current_rocket : MonoBehaviour
{
    // Start is called before the first frame update
    public int score,money;
    public Rocket_Scriptable_object rocket_sobj; 
    [SerializeField] bool Game_start=false;
    [Header("Soldaki buttonlar")]
    [SerializeField] Button[] Leftbutton;
    public Image[] the_chosers;
  
    [Header("sağdaki alan")][SerializeField] GameObject Rightpanel;
    [Header("rocket parameters")]
    public int Money_earing_constant;
    public int offline_money_earing_constant;
    public float maxfuel;
    public float maxheat;
    public void chosed()
    {
     
      Money_earing_constant=rocket_sobj.Money_earing_constant;

      offline_money_earing_constant=rocket_sobj.offline_money_earing_constant;

      maxfuel=rocket_sobj.Fuel;

      this.GetComponent<SpriteRenderer>().sprite=rocket_sobj.rocket_sprite;
    }
    public void Game_Start_Button()
    {

    Game_start=true;
    StartCoroutine(the_Button_transform());

    }
    IEnumerator the_Button_transform()
    {
        
         
         for(int a=0;a<=Leftbutton.Length-1;a++)
         {
            Leftbutton[a].transform.DOLocalMoveX(-700,0.5f);
         }
          for(int a=0;a<=the_chosers.Length-1;a++)
         {
        the_chosers[a].transform.DOMoveX(-300,0.5f);
         }
         Rightpanel.transform.DOLocalMoveX(750,0.5f);
         yield break;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Game_start)
        {
         
        }
    }
    // constantları değiştiren fonksiyonlar burada
}
