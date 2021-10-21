using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public FadeController fadeController;
    public static GameManager instance;
    public ObjectPool objPool;
    public Player player;
    public Animal animal;
    public SpawnPos spawnPos;
    public GameObject spawnObject { get; private set; }
    public bool isMax;
    public bool isDoveBuy;
    public bool isMiceBuy;
    public bool isTortoiseBuy;
    public bool isRabbitBuy;
    public bool isDogBuy;
    public bool isCatBuy;
    public bool isBreeding;
    public bool isFieldBuy;
    public bool isWarning;
    public bool isSellAnimal;
    public bool isRechargable;
    public int count = 1;
    public bool isGreenPlantsBuy;
    public bool isCornBuy;
    public bool isWheatBuy;
    public bool isBeetsBuy;
    public bool isField1Using;
    public bool isField2Using;
    public bool isField3Using;
    public bool isField4Using;
    public Vector3[] fieldPos = new Vector3[4];
    //public Vector3 field2Pos;
    //public Vector3 field3Pos;
    //public Vector3 field4Pos;
    public int fieldNum;
    public float greenplantTime;
    public float cornTime;
    public float beetsTime;
    public float wheatTime;
    public int currentScene;
    public float heartTimer;
    public GameObject Lv2Map;
    public GameObject Lv3Map;
    private void Awake()
    {
        if (!instance)
            Destroy(instance);

        instance = this;


        objPool = GetComponent<ObjectPool>();
    }
    void Start()
    {
        greenplantTime = 5.0f;
        cornTime =  300.0f;/*300.0f;*/
        beetsTime = 420.0f;/* 420.0f;*/
        wheatTime = 600.0f;/* 600.0f;*/
        isDoveBuy = false;
        isRechargable = false;
        isBreeding = false;
        isMax = false;
        fieldPos[0] = new Vector3((float)3.7, 2, 7);
        fieldPos[1] = new Vector3((float)0, 2, 7);
        fieldPos[2] = new Vector3((float)3.7, 2, 3);
        fieldPos[3] = new Vector3((float)0, 2, 3);
        heartTimer = 5.0f;

}

    void Update()
    {
        if(SceneManager.sceneCount == 1)
        {
            Recharge();
            ShopSpawn();
        }


    }

    public void Recharge()
    {
        if(SceneManager.sceneCount == 1)
        {
            if (player.currentPlayerHeartPoint < player.maxPlayerHeartPoint)
            {
                isRechargable = true;
                heartTimer -= Time.deltaTime;
                if (heartTimer <= 0)
                {
                    GameManager.instance.player.currentPlayerHeartPoint++;
                    heartTimer = 5.0f;
                }
            }
            else
                isRechargable = false;
        }
       
    }

    public void ShopSpawn()
    {
        if (isMiceBuy)
        {
            Vector3 hitPos = new Vector3(-10, 3, -15);
            spawnObject = GameManager.instance.objPool.SpawnFromPool("Mice", hitPos, Quaternion.identity);
            player.GoldCalculrator(-50);
            player.ExCalculrator(5);
            isMiceBuy = false;
        }
        if(isDoveBuy)
        {
            Vector3 hitPos = new Vector3(-10, 3, -15);
            spawnObject = GameManager.instance.objPool.SpawnFromPool("Dove", hitPos, Quaternion.identity);
            player.GoldCalculrator(-100);
            player.ExCalculrator(7);
            isDoveBuy = false;
        }
        if (isTortoiseBuy)
        {
            Vector3 hitPos = new Vector3(-10, 3, -15);
            spawnObject = GameManager.instance.objPool.SpawnFromPool("Tortoise", hitPos, Quaternion.identity);
            player.GoldCalculrator(-200);
            player.ExCalculrator(10);
            isTortoiseBuy = false;
        }
        if (isRabbitBuy)
        {
            Vector3 hitPos = new Vector3(-10, 3, -15);
            spawnObject = GameManager.instance.objPool.SpawnFromPool("Rabbit", hitPos, Quaternion.identity);
            player.GoldCalculrator(-300);
            player.ExCalculrator(12);
            isRabbitBuy = false;
        }
        if (isDogBuy)
        {
            Vector3 hitPos = new Vector3(-10, 3, -15);
            spawnObject = GameManager.instance.objPool.SpawnFromPool("Dog", hitPos, Quaternion.identity);
            player.GoldCalculrator(-400);
            player.ExCalculrator(15);
            isDogBuy = false;
        }
        if (isCatBuy)
        {
            Vector3 hitPos = new Vector3(-10, 3, -15);
            spawnObject = GameManager.instance.objPool.SpawnFromPool("Cat", hitPos, Quaternion.identity);
            player.GoldCalculrator(-500);
            player.ExCalculrator(20);
            isCatBuy = false;
        }

        #region Plant //½Ä¹°

        //if (isGreenPlantsBuy)
        //{
        //    ////greenplantTime -= Time.deltaTime;
        //    //if (greenplantTime <= 0)
        //    //{
        //    //    GameManager.instance.objPool.SpawnFromPool("GreenPlants", player.fieldPos, Quaternion.identity);
        //    //    greenplantTime = 3;
        //    //    GameManager.instance.player.isHarvestable = true;
        //    //    isGreenPlantsBuy = false;
        //    //}
        //    //StartCoroutine(GreenPlant());
        //}
        //if (isCornBuy)
        //{
        //    cornTime -= Time.deltaTime;
        //    if (cornTime <= 0)
        //    {
        //        GameManager.instance.objPool.SpawnFromPool("Corn", player.fieldPos, Quaternion.identity);
        //        cornTime = 3;
        //        GameManager.instance.player.isHarvestable = true;
        //        isCornBuy = false;
        //    }
        //}
        //if (isBeetsBuy)
        //{
        //    beetsTime -= Time.deltaTime;
        //    if (beetsTime <= 0)
        //    {
        //        GameManager.instance.objPool.SpawnFromPool("Beets", player.fieldPos, Quaternion.identity);
        //        beetsTime = 3;
        //        GameManager.instance.player.isHarvestable = true;
        //        isBeetsBuy = false;
        //    }
        //}
        //if (isWheatBuy)
        //{
        //    wheatTime -= Time.deltaTime;
        //    if (wheatTime <= 0)
        //    {
        //        GameManager.instance.objPool.SpawnFromPool("Wheat", player.fieldPos, Quaternion.identity);
        //        wheatTime = 3;
        //        GameManager.instance.player.isHarvestable = true;
        //        isWheatBuy = false;
        //    }
        //}
        #endregion


        if (isFieldBuy)
        {
            if (count == 1)
            {
                UIManager.instance.fieldinfo[0]= 
                    objPool.SpawnFromPool("Field", fieldPos[0], Quaternion.identity).GetComponent<FieldInfo>();
                fieldNum = 1;
                count = 2;
            }
            else if (count == 2)
            {
                UIManager.instance.fieldinfo[1] = 
                    objPool.SpawnFromPool("Field", fieldPos[1], Quaternion.identity).GetComponent<FieldInfo>();
                fieldNum = 2;
                count = 3;
            }
            else if (count == 3)
            {
                UIManager.instance.fieldinfo[2] =
                    objPool.SpawnFromPool("Field", fieldPos[2], Quaternion.identity).GetComponent<FieldInfo>();
                fieldNum = 3;
                count = 4;
            }
            else if (count == 4)
            {
                UIManager.instance.fieldinfo[3] =
                    objPool.SpawnFromPool("Field", fieldPos[3], Quaternion.identity).GetComponent<FieldInfo>();
                fieldNum = 4;
            }
            player.GoldCalculrator(-50);
            isFieldBuy = false;
        }
    }

    IEnumerator GreenPlant()
    {
        Debug.Log(greenplantTime);
        if(greenplantTime <= 0.0f)
        {
            GameManager.instance.objPool.SpawnFromPool("GreenPlants", player.fieldPos, Quaternion.identity);
            greenplantTime = 3;
            GameManager.instance.player.isHarvestable = true;
            isGreenPlantsBuy = false;
            yield break;
        }

        greenplantTime -= 1.0f;
        yield return new WaitForSeconds(1.0f);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
