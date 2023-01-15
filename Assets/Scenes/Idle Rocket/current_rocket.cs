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
   
    public float maxfuel;
    public float maxheat;
    [Header("Ateş")]
    public GameObject Fire;
    [SerializeField]private GameObject[]Fire_rocket_now;
    [SerializeField]public Button start_button;
    [Header("Background")]
     public GameObject[]back;
    public void chosed(Rocket_Scriptable_object rocky)
    {
     rocket_sobj=rocky;
     
      Money_earing_constant=rocket_sobj.Money_earing_constant;


      maxfuel=rocket_sobj.Fuel;

      this.GetComponent<SpriteRenderer>().sprite=rocket_sobj.rocket_sprite;
    }
    public void Game_Start_Button()
    {

    Game_start=true;
    start_button.gameObject.SetActive(false);
    StartCoroutine(the_Button_transform());
     

    }
    IEnumerator the_Button_transform()
    {
        
         
         for(int a=0;a<=Leftbutton.Length-1;a++)
         {
            Leftbutton[a].transform.DOMoveX(-300,0.5f);
         }
          for(int a=0;a<=the_chosers.Length-1;a++)
         {
        the_chosers[a].transform.DOMoveX(-300,0.5f);
         }
         Rightpanel.transform.DOMoveX(1300,0.5f);

         this.transform.DOLocalMoveY(-1.5f,1);

         back[0].transform.DOLocalMoveY(-10,1); 
          back[1].transform.DOLocalMoveY(-22,4); 
     
         Fire_rocket_now=new GameObject[rocket_sobj.fire_positions.Length];

         for(int i=0;i<=rocket_sobj.fire_positions.Length-1;i++)
         {

         GameObject fire= Instantiate(Fire,rocket_sobj.fire_positions[i],Quaternion.identity);
     

         Fire_rocket_now[i]=fire;

         
         Fire_rocket_now[i].transform.parent = this.transform;

         Fire_rocket_now[i].GetComponent<fire_constant>().change_constant(1.4f);

         StartCoroutine(Fire_rocket_now[i].GetComponent<fire_constant>().fire());

         }
         yield return new WaitForSeconds(0.5f);
        StartCoroutine(rocketsize());
        
         yield break;
    }
    IEnumerator rocketsize()
    {
         this.transform.DOScale(new Vector3(1.05f,1.05f,0),0.75f);

         yield return new WaitForSeconds(1f);
         
         this.transform.DOScale(new Vector3(1f,1f,0),0.75f);
         
         yield return new WaitForSeconds(1f);
         
         yield return StartCoroutine(rocketsize());
    }
    //butona tıklandığında go to -1.5f

    // tıklanmadığında go to -2 again

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Game_start)
        {
            

        }
    }
    // constantları değiştiren fonksiyonlar burada
}
