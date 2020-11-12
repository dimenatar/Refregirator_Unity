using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezerBehavior
{

    public double factFoodWeight;
    public bool isLocked = false;
    public string state = "Closed";
    public List<string> Foods = null;
    public double defaultTemperature = -273;
    public double factTemperature;
    public double maxFoodWeight = 15;
    public bool needSiren = false;


}

public class RefregiratorBehavior : MonoBehaviour
{
    public bool Locked;
    bool goOn = true;
    bool goOff = false;
    public Light Siren;
    public FreezerBehavior freezer;
    protected double factFoodWeight;
    protected bool isLocked = false;
    protected string state = "Closed";
    protected List<string> Foods = null;
    public GlobalTime globalTime;
    public SpriteRenderer spriteRenderer;

    protected double defaultTemperature = -273;
    protected double factTemperature;
    protected int startTempTime;
    public UnityEngine.UI.Text FreezerTemperature;
    public UnityEngine.UI.Text txt;
    public UnityEngine.UI.Text Kost;
    public Sprite RedLock;
    public Sprite BlueLock;
    protected bool needSiren = false;

    public double FactFoodWeight
    {
        get { return factFoodWeight; }
        set { factFoodWeight = value; }
    }
    public bool IsLocked
    {
        get { return isLocked; }
        set { isLocked = value; }
    }
    public string State
    {
        get { return state; }
        set { state = value; }
    }
    void Start()
    {
        Locked = false;
        freezer = new FreezerBehavior();
        Kost.text = "!LOCKED";
        globalTime = new GlobalTime();
        InvokeRepeating("UpdateTimer", 0, 0.5f);
        InvokeRepeating("LightControl", 0, 0.1f);
        InvokeRepeating("ControlMusic", 0, 5f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        factTemperature = defaultTemperature;
        freezer.factTemperature = freezer.defaultTemperature;
    }
    void Update()
    {
        //Debug.Log(globalTime.MinTime + "  HELP");
         //if (Kost.text == "LOCKED") Debug.Log("LOCKED");
    }

    public UnityEngine.UI.Text Temperature;
    protected double maxFoodWeight = 25;

     public void GetFood(Food food)
     {
        if (food.Weight + factFoodWeight<=maxFoodWeight)
        {
            factFoodWeight += food.Weight;
            Foods.Add(food.Name);
        }
     }
    public void OpenCloseDoor()
    {
        if (Kost.text == "!LOCKED")
        {
            GameObject Dor = GameObject.FindWithTag("Door");
            Animator anim = Dor.GetComponent<Animator>();
            anim.SetTrigger("OpenClose");
            if (state == "Opened") state = "Closed";
            else state = "Opened";
            if (state == "Opened")
            {
                startTempTime = globalTime.SecTime;
            }
        }
        else
        {

        }
    }
     protected float MaxTime = 3;
    public void ChangeLockedStatement()
    {
        if (Kost.text == "LOCKED")
        {
            if (globalTime.MinTime >= 6 || state == "Opened")
            {
                spriteRenderer.sprite = BlueLock;
                Kost.text = "!LOCKED";
            }
        }
        else
        {
            if (state != "Opened")
            {
                spriteRenderer.sprite = RedLock;
                Kost.text = "LOCKED";
            }
        }
    }
    public bool IsPlaying = false;
    void UpdateTimer()
    {
        Debug.Log(Jost + "До апдейта");
        if (TimePicked)
        globalTime.MinTime = Jost;
        if (globalTime.MinTime < 24)
        {
            if (globalTime.SecTime < 59)
            {
                globalTime.SecTime += 1;
            }
            else
            {
                if (globalTime.MinTime < 23)
                    globalTime.MinTime += 1;
                else globalTime.MinTime = 0;
                globalTime.SecTime = 0;
            }
        }
        else
        {
            globalTime.SecTime = 0;
            globalTime.MinTime = 0;
        }
        if (globalTime.SecTime >= 10 && globalTime.MinTime >= 10)
            txt.text = globalTime.MinTime + ":" + globalTime.SecTime;
        else if (globalTime.SecTime < 10 && globalTime.MinTime >= 10) txt.text = globalTime.MinTime + ":0" + globalTime.SecTime;
        else if (globalTime.MinTime < 10 && globalTime.SecTime >= 10) txt.text = "0" + globalTime.MinTime + ":" + globalTime.SecTime;
        else txt.text = "0" + globalTime.MinTime + ":0" + globalTime.SecTime;
        Debug.Log(globalTime.MinTime + "после апдейта");



        if (state == "Opened")
        {
            if (factTemperature < 100)
            factTemperature++;
            Debug.Log(factTemperature);
            Temperature.text = "Факт темп холодильника: " + (int)(factTemperature) + "C";
        }
        else
        {
            if (factTemperature > defaultTemperature)
            {
                factTemperature -= 0.1;
                Debug.Log(factTemperature);
                Temperature.text = "Факт темп холодильника: " + (int)(factTemperature) + "C";
            }
            else
            {
                factTemperature = defaultTemperature;
                //Temperature.text = "Факт темп холодильника: " + (int)(factTemperature) + "C";
            }
        }
        Debug.Log(defaultTemperature + "----Дефолт");
        //Temperature.text = "Факт темп холодильника: " + (int)(factTemperature) + "C";

        if (freezer.state == "Opened")
        {
            if (freezer.factTemperature < 100)
            {

                freezer.factTemperature = freezer.factTemperature+2;
                FreezerTemperature.text = (int)(freezer.factTemperature) + "C";

            }
        }
        else
        {
            if (freezer.factTemperature > freezer.defaultTemperature)
            {
                freezer.factTemperature -= 0.5;
                FreezerTemperature.text = (int)(freezer.factTemperature) + "C";
            }


        }
        
        if (factTemperature - defaultTemperature >= 3)
        {
            needSiren = true;

        }
        else
        {
            needSiren = false;

        }
        if (freezer.factTemperature - freezer.defaultTemperature >= 3)
        {
            needSiren = true;

        }
        else
        {
            needSiren = false;

        }
    }
    public void OpenCloseDoorFreezer()
    {
        if (Kost.text == "!LOCKED" || freezer.state == "Opened")
        {
            GameObject Dor = GameObject.FindWithTag("FreezerDoor");
            Animator anim = Dor.GetComponent<Animator>();
            anim.SetTrigger("OpenCloseFreezer");
            if (freezer.state == "Opened")
            {
                freezer.state = "Closed";
            }
            else
            {
                freezer.state = "Opened";
            }

        }
        else
        {

        }
    }
    AudioSource audioData;

    public void LightControl()
    {
        if (needSiren || freezer.needSiren)
        {
            if (!IsPlaying)
            {
                audioData = GetComponent<AudioSource>();
                audioData.Play();
                IsPlaying = true;
            }
            

            if (goOn)
            {
                if (Siren.range <= 1) Siren.range += 0.1f;
                else goOn = false;
            }
            else
            {
                if (Siren.range > 0) Siren.range -= 0.1f;
                else goOn = true;
            }
        }
        else 
        {
            //Siren.color = Color.white;

        }
    }
    public UnityEngine.UI.InputField foodName;
    public UnityEngine.UI.InputField foodWeight;

    public void GetFoodToRefregirator()
    {
        factTemperature += int.Parse(foodWeight.text);
    }
    public void GetFoodToFreezer()
    {
        freezer.factTemperature += int.Parse(foodWeight.text);
    }
    public Canvas firstCanvas;
    public void ShowFirstUI()
    {
        
        if (firstCanvas.scaleFactor == 1) firstCanvas.scaleFactor = 0.01f;
        else firstCanvas.scaleFactor = 1;
    }
    public Canvas secondCanvas;
    public void ShowSecondUI()
    {
        if (secondCanvas.scaleFactor == 1) secondCanvas.scaleFactor = 0.01f;
        else secondCanvas.scaleFactor = 1;
    }
    public void ControlMusic()
    {
        if (IsPlaying)
        {
            IsPlaying = false;
        }
    }
    public UnityEngine.UI.Scrollbar scrollbar;
    public int Jost;
    public bool TimePicked = false;
    public void GetMinutes()
    {
        TimePicked = true;
        Jost =   (int)(scrollbar.value*24);

    }
}



public class Food
{
    protected string name;
    protected double weight;

    public double Weight
    {
        get { return weight; }
    }
    public string Name
    {
        get { return name; }
    }
}

 public class Kartoshechka : Food
 {
    public Kartoshechka(string name, double weight)
    {
        this.name = name;
        this.weight = weight;
    }
}

public class GlobalTime
{

    private int minTime = 12;
    private int secTime = 0;
    public int MinTime
    {
        get { return minTime; }
        set { minTime = value; }
    }
    public int SecTime
    {
        get { return secTime; }
        set { secTime = value; }
    }
}


