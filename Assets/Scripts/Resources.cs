using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    public int gold;
    int neededGold = 10;
    int goldPerSecond = 1;
    public Text goldText;
    public Text neededGoldText;

    public int wood;
    int neededWood = 10;
    int woodPerSecond = 1;
    public Text woodText;
    public Text neededWoodText;
    public int woodNeededForFood;
    public Text woodNeededForFoodtext;

    public int stone;
    int neededStone = 10;
    int stonePerSecond = 1;
    public Text stoneText;
    public Text neededStoneText;

    public int upgrades;
    int neededUpgrades = 5;
    public int level = 1;
    public Text levelText;
    public Text neededUpgradesText;
    public Text upgradesText;

    public int meat;
    public int cookedMeat;
    int meatPerSecond = 1;
    int upgradeOvenStone = 100;
    int upgradeOvenWood = 50;
    public Text meatText;
    public Text upgradeOvenText;
    public Text cookedMeatText;

    float countdownToEat = 180f;
    float eatTime = 10f;
    public Text eatTimeText;
    public Text CountdownToEatText;

    public GameObject goldWorker;
    public GameObject woodWorker;
    public GameObject stoneWorker;

    public int workers = 3;

    float delayAmount = 1f;
    public float Timer;

    int delayPayment = 0;
    float paymentTimer = 60;
    public Text paymentTimeText;

    void Update()
    {
        Timer += Time.deltaTime;
        paymentTimer -= Time.deltaTime;
        countdownToEat -= Time.deltaTime;

        if(Timer >= delayAmount)
        {
            Timer = 0f;
            gold += goldPerSecond;
            wood += woodPerSecond;
            stone += stonePerSecond;
            meat += meatPerSecond;
            
        }
        goldText.text = gold + " [ " + goldPerSecond + " / Sec" + " ] ";
        woodText.text = wood + " [ " + woodPerSecond + " / Sec" + " ] ";
        stoneText.text = stone + " [ " + stonePerSecond + " / Sec" + " ] ";
        levelText.text = "Level: " + level;
        upgradesText.text = "Upgrades: " + upgrades;
        paymentTimeText.text = "Workers will be paid in: " + (int)paymentTimer + " Seconds";
        meatText.text = meat + " [ " + meatPerSecond + " / Sec" + " ] ";
        cookedMeatText.text = "Cooked meat: " + cookedMeat;
    
        neededGoldText.text = "Gold needed for upgrade: " + neededGold;
        neededWoodText.text = "Wood needed for upgrade: " + neededWood;
        neededStoneText.text = "Gold needed for upgrade: " + neededStone;
        neededUpgradesText.text = "Upgrades needed for level up: " + neededUpgrades;
        upgradeOvenText.text = "Stone and wood needed for upgrade: Stone: " + upgradeOvenStone + " | Wood: " + upgradeOvenWood;

        CountdownToEatText.text = "Workers will eat in: " + (int)countdownToEat + "seconds";
        woodNeededForFoodtext.text = "Wood needed to cook meat: " + woodNeededForFood;
        Payment();
        Eat();
        woodNeededForFood = meat * 2;
    }

    public void Eat()
    {
        if(countdownToEat <= 0)
        {
            cookedMeat -= workers * 2;
            //eatTime -= Time.deltaTime;
            countdownToEat = 180f;
            //eatTimeText.text = "Workers will be done eating in: " + (int)eatTime + "seconds";
        }   
    }

    public void MeltMeat()
    {
        if(wood <= woodNeededForFood)
        {
            Debug.Log("Can't cook the food");
        }
        else
        {            
            wood -= woodNeededForFood;
            cookedMeat += meat;
            meat -= meat;
        }
    }

    public void UpgradeOven()
    {
        if(wood >= upgradeOvenWood && stone >= upgradeOvenStone)
        {
            stone -= upgradeOvenStone;
            wood -= upgradeOvenWood;
            upgradeOvenWood += 50;
            upgradeOvenStone += 150;
            meatPerSecond += 1;
        }   
    }

    public void Payment()
    {
        if(paymentTimer <= delayPayment)
        {
            gold -= 5 * workers;
            paymentTimer = 60;
        }
    }

    public void UpgradeGold()
    {
        if (gold >= neededGold)
        {
            goldPerSecond += 3;
            gold -= neededGold;
            neededGold += 75;
            upgrades += 1;
            Instantiate(goldWorker, new Vector3(0, 0, 0), Quaternion.identity);
            workers += 1;
        }
    }
    public void UpgradeWood()
    {
        if (wood >= neededWood)
        {
            woodPerSecond += 3;
            wood -= neededWood;
            neededWood += 75;
            upgrades += 1;
            Instantiate(woodWorker, new Vector3(0, 0, 0), Quaternion.identity);
            workers += 1;
        }
    }
    public void UpgradeStone()
    {
        if (stone >= neededStone)
        {
            stonePerSecond += 3;
            stone -= neededStone;
            neededStone += 75;
            upgrades += 1;
            Instantiate(stoneWorker, new Vector3(0, 0, 0), Quaternion.identity);
            workers += 1;
        }
    }

    public void LevelUp()
    {
        if(upgrades >= neededUpgrades)
        {
            upgrades -= neededUpgrades;
            neededUpgrades += 25;
            level += 1;
            goldPerSecond += 10;
            woodPerSecond += 10;
            stonePerSecond += 10;
        }
    }
}
