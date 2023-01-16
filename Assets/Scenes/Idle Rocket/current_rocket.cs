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
     public static bool Game_start=false;
    [SerializeField] bool tiklaniyor,canplay=false;
    [Header("Soldaki buttonlar")]
    [SerializeField] Button[] Leftbutton;
    public Image[] the_chosers;
  
    [Header("sağdaki alan")][SerializeField] GameObject Rightpanel;

    [Header("rocket parameters")]

    public int Money_earing_constant;
   
    public float maxfuel,Current_fuel;
    public float maxheat,Current_heat;
    [Header("Ateş")]
    public GameObject Fire;
    [SerializeField]public GameObject[]Fire_rocket_now;
    [SerializeField]public Button start_button,Gas_button;
    [Header("Background")]
     public GameObject[]back;
     [Header("THE_fUEL_HEAT")]
     public Slider Fuelsli,Heatsli;






    public void chosed(Rocket_Scriptable_object rocky)
    {
        canplay=true;
        Heatsli.maxValue=100;

      rocket_sobj=rocky;
     
      Money_earing_constant=rocket_sobj.Money_earing_constant;

      maxfuel=rocket_sobj.Fuel;

      Fuelsli.maxValue=maxfuel;
      Fuelsli.value=maxfuel;

      Current_fuel=maxfuel;

      Current_heat=0;

      this.GetComponent<SpriteRenderer>().sprite=rocket_sobj.rocket_sprite;
    }
    public void Game_Start_Button()
    {
  if(canplay)
        {
    Game_start=true;

    start_button.gameObject.SetActive(false);
   
    StartCoroutine(the_Button_transform());
     
        }
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
         
     
         Fire_rocket_now=new GameObject[rocket_sobj.fire_positions.Length];

         for(int i=0;i<=rocket_sobj.fire_positions.Length-1;i++)
         {

         GameObject fire= Instantiate(Fire,rocket_sobj.fire_positions[i],Quaternion.identity);
     

         Fire_rocket_now[i]=fire;

         
         Fire_rocket_now[i].transform.parent = this.transform;

        

         

         }
         yield return new WaitForSeconds(0.5f);
        
          Gas_button.gameObject.SetActive(true);
         yield break;
        
    }
    
    //butona tıklandığında go to -1.5f

    // tıklanmadığında go to -2 again

    // Update is called once per frame
    public void fuelharca()
    {
      tiklaniyor=true;
    }
    public void fuelharcama()
    {
       tiklaniyor=false;
    }
    
    
    
    
    void FixedUpdate()
    {
        if(Game_start)
        {
            
if(tiklaniyor)
{
    
        Current_fuel-=2*Time.deltaTime;
       Fuelsli.value=Current_fuel;
        Current_heat+=30*Time.deltaTime;
      Heatsli.value=Current_heat;
}
else
{
      if(Current_heat>=0){Current_heat-=30*Time.deltaTime;}
         Heatsli.value=Current_heat;
}
       
     
      if(Heatsli.value>=90||Current_fuel<=0)
      {
        Game_start=false;
        // seçim ekranı yine gelsin falan filan fistan
        // tıklama butonu kayıp olsun diğerleri geri gelsin
        // en son ki rekoru alsın 
      }
        }
    }
    // constantları değiştiren fonksiyonlar burada
}
