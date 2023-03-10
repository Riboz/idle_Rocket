using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class current_rocket : MonoBehaviour
{
    // Start is called before the first frame update
   public audios aud;
   public ParticleSystem CaBoom;

    public Text Reward_money_text,score_text,cscore_text,collect_Score_text,money_Text;

    public int score,score_Current,money,current_money;
    public Rocket_Scriptable_object rocket_sobj; 
     public static bool Game_start=false,the_choser_activation;
    [SerializeField] bool tiklaniyor,canplay=false,restart_bool;
    [Header("Soldaki buttonlar")]
    [SerializeField] Button[] Leftbutton;
    public Image[] the_chosers;
  
    [Header("sağdaki alan")][SerializeField] GameObject Rightpanel,money_takes;

    [Header("rocket parameters")]

    public int Money_earing_constant;
   
    public float maxfuel,Current_fuel,timex,timey;
    public float maxheat,Current_heat,speed;
    [Header("Ateş")]
    public GameObject Fire;
    [SerializeField]public GameObject[]Fire_rocket_now;
    [SerializeField]public Button start_button,Gas_button;
    [Header("Background")]
     public GameObject[]back;
     [Header("THE_fUEL_HEAT")]
     public Slider Fuelsli,Heatsli;

     public FadeInandOut FadeInandOut;

     


     public float speedShopCost,fuelShopCost, interestShopCost = 1000;
     public Text speedShopCostText, fuelShopCostText, interestShopCostText;



void Start()
{
   score_text.text=PlayerPrefs.GetInt("Datascore")+"";
     money_Text.text=PlayerPrefs.GetInt("Moneydata")+"";
}

  void Awake()
  {

    Rightpanel.transform.DOMoveX(1300,0.5f);

    Application.targetFrameRate = 60;
    
    if (PlayerPrefs.HasKey("Datascore"))  //totalScoreKey anahtarıyla kaydedilmiş bir veri var mı ?
   {
            score = PlayerPrefs.GetInt("Datascore"); // totalScoreKey anahtarıyla kaydedilmiş veriyi getir
            score_text.text=score.ToString();
   }

     if (PlayerPrefs.HasKey("Moneydata"))  //totalScoreKey anahtarıyla kaydedilmiş bir veri var mı ?
   {
            money = PlayerPrefs.GetInt("Datascore"); // totalScoreKey anahtarıyla kaydedilmiş veriyi getir
           money_Text.text=money.ToString();
   }

  }
    public void chosed(Rocket_Scriptable_object rocky)
    { 
      aud.GetComponent<AudioSource>().loop=false;
      aud.GetComponent<AudioSource>().clip=aud.aiduo[4];
      aud.GetComponent<AudioSource>().Play();
      Rightpanel.transform.DOMoveX(550,0.5f);
      the_choser_activation=false;
      canplay=true;
      
      Heatsli.maxValue=100;

      rocket_sobj=rocky;
     
      Money_earing_constant=rocket_sobj.Money_earing_constant;

      maxfuel=rocket_sobj.Fuel;
      speed=rocket_sobj.speed;

      Fuelsli.maxValue=maxfuel;

      Fuelsli.value=maxfuel;

      Current_fuel=maxfuel;

      Current_heat=50;

      this.GetComponent<SpriteRenderer>().sprite=rocket_sobj.rocket_sprite;
      start_button.gameObject.SetActive(true);
     

    }
    public void Game_Start_Button()
    {
  if(canplay)
        {
    Game_start=true;
    cscore_text.gameObject.SetActive(true); 
     score_text.gameObject.SetActive(false);  
    start_button.gameObject.SetActive(false);
   
    StartCoroutine(the_Button_transform());
     
        }
    }
    IEnumerator the_Button_transform()
    {
     
aud.GetComponent<AudioSource>().loop=true;
      aud.GetComponent<AudioSource>().clip=aud.aiduo[2];
       aud.GetComponent<AudioSource>().Play();
      

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
          tiklaniyor=false;
          restart_bool=true;
           for( int i=0;i<=Fire_rocket_now.Length-1;i++)
      {
          StartCoroutine(Fire_rocket_now[i].GetComponent<fire_constant>().fire());
      }
         yield break;
        
    }
    
    //butona tıklandığında go to -1.5f

    // tıklanmadığında go to -2 again

    // Update is called once per frame
    public void fuelharca()
    {
      tiklaniyor=true;
                transform.DOScale(new Vector3(1.1f,1.1f,0),0.3f);
       
     }
    public void fuelharcama()
    {
       tiklaniyor=false;
      
                transform.DOScale(new Vector3(1f,1f,0),0.3f);
       
     }
    
    
    
    
    float timer_money;
    
    void FixedUpdate()
    {
        if(Game_start)
        {
          

          timer_money+=Time.deltaTime;
          cscore_text.text=""+score_Current;
          if(timer_money>0.15f)
          {
            score_Current+=(int)speed;
            
        current_money+=(int)speed*rocket_sobj.Money_earing_constant/20;
        timer_money=0;
          }
            
      
if(tiklaniyor)
{  
   
    
        Current_fuel-=10*Time.deltaTime;
       Fuelsli.value=Current_fuel;
        Current_heat+=50*Time.deltaTime;
      Heatsli.value=Current_heat;
      
      for( int i=0;i<=Fire_rocket_now.Length-1;i++)
      {
        if(Fire_rocket_now[i]!=null)
        {
          Fire_rocket_now[i].GetComponent<fire_constant>().fire_constant_value=2.2f;
        }
      }
    
      
}
else
{
     
   
      if(Current_heat>=0){Current_heat-=40*Time.deltaTime;}
       for( int i=0;i<=Fire_rocket_now.Length-1;i++)
      {
        
        if(Fire_rocket_now[i]!=null)
        {
       Fire_rocket_now[i].GetComponent<fire_constant>().fire_constant_value=1.3f;
        }
      
      }
         Heatsli.value=Current_heat;
}
       
     
      if(Heatsli.value>=90||Current_fuel<=-3||Heatsli.value<=0 ||speed<0)
      {
        
        // seçim ekranı yine gelsin falan filan fistan
        Game_start=false;
        canplay=false;
        Gas_button.gameObject.SetActive(false);
        if(restart_bool)
        {

          Restart();
           restart_bool=false;
        }
        // tıklama butonu kayıp olsun diğerleri geri gelsin
        // en son ki rekoru alsın 
      }
        }
    }
    public void Collect()
    {
      
       Destroy(destroying);
       FadeInandOut.restartBool = true;
       score_text.gameObject.SetActive(true); 
       if(score_Current>=score)
       {
        score=score_Current;
        score_text.text=score+"";

       }
       score_Current=0;

        the_choser_activation=true;
        
        rocket_sobj=null;
        
        back[0].transform.DOLocalMoveY(-3,1); 

        this.transform.DOLocalMoveY(-5.5f,1);
        
        money+=current_money;
        current_money=0;
        money_Text.text=money+"";
     
         for(int a=0;a<=Leftbutton.Length-1;a++)
         {
            Leftbutton[a].transform.DOMoveX(75,0.5f);
         }
         
         

              money_takes.SetActive(false);
              Fuelsli.value=Fuelsli.maxValue;
              Heatsli.value=Heatsli.minValue;
              aud.GetComponent<AudioSource>().clip=aud.aiduo[0];
              aud.GetComponent<AudioSource>().loop=false;
               aud.GetComponent<AudioSource>().Play();

               PlayerPrefs.SetInt("Datascore",score); 
               PlayerPrefs.SetInt("Moneydata",money); 
                

               PlayerPrefs.Save();


               
    }
    public ParticleSystem destroying;
    public void Restart()
    {
       destroying=Instantiate(CaBoom,this.transform.position,Quaternion.identity);
       aud.GetComponent<AudioSource>().loop=false;
       aud.GetComponent<AudioSource>().clip=aud.aiduo[5];
       aud.GetComponent<AudioSource>().Play();
         
     collect_Score_text.text="Score="+score_Current;
     cscore_text.gameObject.SetActive(false); 
     money_takes.SetActive(true);
     StartCoroutine(the_restart_scaler());

     Reward_money_text.text=current_money+"$";
    
     this.GetComponent<SpriteRenderer>().sprite=null;
      for(int i=0;i<=Fire_rocket_now.Length-1;i++)
         {
          Destroy(Fire_rocket_now[i],0.2f);
         }
     
    }
   public IEnumerator the_restart_scaler()
   {
    for(int i=0;i<=4;i++)
    {
      money_takes.transform.DOScale(1.05f,0.5f);
      yield return new WaitForSeconds(0.5f);
        money_takes.transform.DOScale(1f,0.5f);
        yield return new WaitForSeconds(0.5f);
    }

   }


   public void SpeedUpShop()
   {
    if (money >= speedShopCost)
    {
     rocket_sobj.speed = rocket_sobj.speed * 1.2f;
     speed = rocket_sobj.speed;
     Debug.Log(speedShopCost);
     speedShopCost = speedShopCost * 1.213f;
     Debug.Log(speedShopCost);
     money = money - (int)speedShopCost;
     speedShopCostText.text = ((int)speedShopCost).ToString();
     money_Text.text = money.ToString();
      aud.GetComponent<AudioSource>().clip=aud.aiduo[1];
      aud.GetComponent<AudioSource>().loop=false;
        aud.GetComponent<AudioSource>().Play();
    }
   }

   public void FuelShop()
   {
    if (money >= fuelShopCost)
    {
     rocket_sobj.Fuel += 5;
     maxfuel = rocket_sobj.Fuel;
     fuelShopCost = fuelShopCost * 1.213f;
     fuelShopCostText.text = ((int)fuelShopCost).ToString();
     money = money - (int) fuelShopCost;
     money_Text.text = money.ToString();
           aud.GetComponent<AudioSource>().clip=aud.aiduo[1];
           aud.GetComponent<AudioSource>().loop=false;
             aud.GetComponent<AudioSource>().Play();
           
    }
   }
   public void InterestShop()
   {
    if (money >= interestShopCost)
    {
     rocket_sobj.Money_earing_constant += 1;
     Money_earing_constant = rocket_sobj.Money_earing_constant;
     interestShopCost = interestShopCost * 1.5f;
     money = money - (int)interestShopCost;
     interestShopCostText.text = ((int)interestShopCost).ToString();
     money_Text.text = money.ToString();
           aud.GetComponent<AudioSource>().clip=aud.aiduo[1];
           aud.GetComponent<AudioSource>().loop=false;
             aud.GetComponent<AudioSource>().Play();
    }
   }
   
   
   
    // constantları değiştiren fonksiyonlar burada


}
