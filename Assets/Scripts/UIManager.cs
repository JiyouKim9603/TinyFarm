using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
// 포인터는 복사같은거고(메모리 사용) 레퍼런스는 메모리를 사용하지 않음 미리 할당된 메모리를 가져오는것
// 포인터는 null ptr을 사용할 수 있고, 레퍼런스는 null을 사용하지 못함 
// 사용할 수 있다면 레퍼런스를 쓰고 어쩔 수 없으면 포인터를 써라
//public class UIpanelList 
//{
//   public GameObject panel;
//   public string name;
//}
public class UIManager : MonoBehaviour
{
    //싱글턴 전용 프로퍼티
    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }

            return m_instance;
        }
    }
   //[Header("UI Panel")]
   //public UIpanelList[] uiList;
    //싱글턴이 할당될 변수
    private static UIManager m_instance;
    public PopUpText popUpText;
    public GameObject animalInfo;
    public GameObject ShopPanel;
    public GameObject previousButton;
    public GameObject nextButton;
    public GameObject firstPage;
    public GameObject secondPage;
    public GameObject thirdPage;
    public GameObject fieldPanel;
    public GameObject warningPanel;
    public GameObject sellAnimalPanel;
    public GameObject MovePanel;
    public GameObject[] PanelPlant = new GameObject[4];
   //public GameObject PanelPlant2;
   //public GameObject PanelPlant3;
   //public GameObject PanelPlant4;

    public Text goldText;
    public Text levelText;
    public Text animalCapacityText;
    public Text maxnAimalCapacityText;
    public Text giveLoveText;
    public Text animalNameText;
    public Text heartPointText;
    public Text warningText;
    public Text heartTimerText;
    public Text sellText;
    public Text[] fieldText = new Text[4];
    //public Text field2Text;
    //public Text field3Text;
    //public Text field4Text;
    public int lovePointUI;
    public GameObject heartImg_prefab;
    public Text field1TimeText;
    public Text[] completeText = new Text[4];
    //public Text completeText2;
    //public Text completeText3;
    //public Text completeText4;
    //public float[] timerMinutes = new float[4];
    //public float[] timerSeconds = new float[4];
    public int heartTimerMinutes;
    public int heartTimerSeconds;
    public Image[] plantImg = new Image[4];

    private int[] count = new int [4];
    private int prevIndex;
    private int curIndex;
    public bool isClickBreedButton;

    public FieldInfo[] fieldinfo = new FieldInfo[4];
   // public Image plantImg2;
   // public Image plantImg3;
   // public Image plantImg4;

    // Start is called before the first frame update
    void Start()
    {
        isClickBreedButton = false;
        heartTimerMinutes = 0;
        heartTimerSeconds = 0;
        //for (int i = 0; i < fieldinfo.Length; i++)
        //{
        //    fieldinfo[i].timerMinutes = 0;
        //    fieldinfo[i].timerSeconds = 0;
        //}
        switch (GameManager.instance.player.playerLv)
        {
            case 1:
                lovePointUI = 10;
                break;
            case 2:
                lovePointUI = 20;
                break;
            case 3:
                lovePointUI = 40;
                break;
        }
    }
    public void Field1Text()
    {
        for (int i = 0; i < fieldinfo.Length; i++) 
        {
            if (fieldinfo[i] == null) continue;//1 3
            if (fieldinfo[i]) 
            {
                fieldText[i].text = string.Format("{0:D2}:{1:D2}", (int)(fieldinfo[i].timerMinutes / 60), (int)(fieldinfo[i].timerSeconds % 60));
                if (fieldinfo[i].isGreenPlantsBuy == true)
                {
                    if (fieldinfo[i].count == 0) 
                    {
                        plantImg[i].gameObject.GetComponent<Image>().sprite = Resources.Load("greenplant", typeof(Sprite)) as Sprite;
                        fieldinfo[i].timerMinutes = GameManager.instance.greenplantTime;
                        fieldinfo[i].timerSeconds = GameManager.instance.greenplantTime;
                        fieldinfo[i].count = 1;
                    }
                }
                else if(fieldinfo[i].isCornBuy == true)
                {
                    if (fieldinfo[i].count == 0)
                    {
                        plantImg[i].gameObject.GetComponent<Image>().sprite = Resources.Load("Corn", typeof(Sprite)) as Sprite;
                        fieldinfo[i].timerMinutes = GameManager.instance.cornTime;
                        fieldinfo[i].timerSeconds = GameManager.instance.cornTime;
                        fieldinfo[i].count = 1;
                    }
                }
                else if (fieldinfo[i].isBeetsBuy == true)
                {
                    if (fieldinfo[i].count == 0)
                    {
                        plantImg[i].gameObject.GetComponent<Image>().sprite = Resources.Load("Beets", typeof(Sprite)) as Sprite;
                        fieldinfo[i].timerMinutes = GameManager.instance.beetsTime;
                        fieldinfo[i].timerSeconds = GameManager.instance.beetsTime;
                        fieldinfo[i].count = 1;
                    }
                }
                else if (fieldinfo[i].isWheatBuy == true)
                {
                    if (fieldinfo[i].count == 0)
                    {
                        plantImg[i].gameObject.GetComponent<Image>().sprite = Resources.Load("Wheat", typeof(Sprite)) as Sprite;
                        fieldinfo[i].timerMinutes = GameManager.instance.wheatTime;
                        fieldinfo[i].timerSeconds = GameManager.instance.wheatTime;
                        fieldinfo[i].count = 1;
                    }
                }

                if (fieldinfo[i].isGreenPlantsBuy || fieldinfo[i].isBeetsBuy || fieldinfo[i].isCornBuy || fieldinfo[i].isWheatBuy) 
                {
                    if (fieldinfo[i].count == 1)
                    {
                        PanelPlant[i].gameObject.SetActive(true);
                        completeText[i].gameObject.SetActive(false);
                        fieldText[i].gameObject.SetActive(true);
                        fieldinfo[i].count = 2;
                    }

                    fieldinfo[i].timerSeconds -= Time.deltaTime;
                    fieldinfo[i].timerMinutes -= Time.deltaTime;

                    if (fieldinfo[i].timerSeconds <= 0)
                    {
                        fieldinfo[i].timerSeconds = 0;
                        fieldinfo[i].timerMinutes = 0;
                        fieldinfo[i].count = 0;
                        completeText[i].gameObject.SetActive(true);
                        fieldText[i].gameObject.SetActive(false);
                        if (fieldinfo[i].isGreenPlantsBuy) 
                        {
                            GameManager.instance.objPool.SpawnFromPool("GreenPlants", fieldinfo[i].transform.position, Quaternion.identity);
                            GameManager.instance.player.isHarvestable = true;
                            fieldinfo[i].isGreenPlantsBuy = false;
                        }
                        else if (fieldinfo[i].isBeetsBuy)
                        {
                            GameManager.instance.objPool.SpawnFromPool("Beets", fieldinfo[i].transform.position, Quaternion.identity);
                            GameManager.instance.player.isHarvestable = true;
                            fieldinfo[i].isBeetsBuy = false;
                        }
                        else if (fieldinfo[i].isCornBuy)
                        {
                            GameManager.instance.objPool.SpawnFromPool("Corn", fieldinfo[i].transform.position, Quaternion.identity);
                            GameManager.instance.player.isHarvestable = true;
                            fieldinfo[i].isCornBuy = false;
                        }
                        else if (fieldinfo[i].isWheatBuy)
                        {
                            GameManager.instance.objPool.SpawnFromPool("Wheat", fieldinfo[i].transform.position, Quaternion.identity);
                            GameManager.instance.player.isHarvestable = true;
                            fieldinfo[i].isWheatBuy = false;
                        }
                    }
                }
            }
        }


        //if (GameManager.instance.isCornBuy)
        //{
        //    for(int i = 0; i < GameManager.instance.fieldPos.Length; i++)
        //    {
        //        timerMinutes[i] = (int)GameManager.instance.cornTime / 60;
        //        timerSeconds[i] = (int)GameManager.instance.cornTime % 60;
        //        if (GameManager.instance.player.fieldPos == GameManager.instance.fieldPos[i])
        //            plantImg[i].gameObject.GetComponent<Image>().sprite = Resources.Load("Corn", typeof(Sprite)) as Sprite;
        //    }
        //    //timerMinutes = (int)GameManager.instance.cornTime / 60;
        //    //timerSeconds = (int)GameManager.instance.cornTime % 60;
        //    //if (GameManager.instance.player.fieldPos == GameManager.instance.field1Pos)
        //    //    plantImg.gameObject.GetComponent<Image>().sprite = Resources.Load("Corn", typeof(Sprite)) as Sprite;
        //    //if (GameManager.instance.player.fieldPos == GameManager.instance.field2Pos)
        //    //    plantImg2.gameObject.GetComponent<Image>().sprite = Resources.Load("Corn", typeof(Sprite)) as Sprite;
        //    //if (GameManager.instance.player.fieldPos == GameManager.instance.field3Pos)
        //    //    plantImg3.gameObject.GetComponent<Image>().sprite = Resources.Load("Corn", typeof(Sprite)) as Sprite;
        //    //if (GameManager.instance.player.fieldPos == GameManager.instance.field4Pos)
        //    //    plantImg4.gameObject.GetComponent<Image>().sprite = Resources.Load("Corn", typeof(Sprite)) as Sprite;
        //}
        //if (GameManager.instance.isBeetsBuy)
        //{
        //    for (int i = 0; i < GameManager.instance.fieldPos.Length; i++)
        //    {
        //        timerMinutes[i] = (int)GameManager.instance.beetsTime / 60;
        //        timerSeconds[i] = (int)GameManager.instance.beetsTime % 60;
        //        if (GameManager.instance.player.fieldPos == GameManager.instance.fieldPos[i])
        //            plantImg[i].gameObject.GetComponent<Image>().sprite = Resources.Load("Beets", typeof(Sprite)) as Sprite;
        //    }
        //    //timerMinutes = (int)GameManager.instance.beetsTime / 60;
        //    //timerSeconds = (int)GameManager.instance.beetsTime % 60;
        //    //if (GameManager.instance.player.fieldPos == GameManager.instance.field1Pos)
        //    //    plantImg.gameObject.GetComponent<Image>().sprite = Resources.Load("Beets", typeof(Sprite)) as Sprite;
        //    //if (GameManager.instance.player.fieldPos == GameManager.instance.field2Pos)
        //    //    plantImg2.gameObject.GetComponent<Image>().sprite = Resources.Load("Beets", typeof(Sprite)) as Sprite;
        //    //if (GameManager.instance.player.fieldPos == GameManager.instance.field3Pos)
        //    //    plantImg3.gameObject.GetComponent<Image>().sprite = Resources.Load("Beets", typeof(Sprite)) as Sprite;
        //    //if (GameManager.instance.player.fieldPos == GameManager.instance.field4Pos)
        //    //    plantImg4.gameObject.GetComponent<Image>().sprite = Resources.Load("Beets", typeof(Sprite)) as Sprite;
        //}
        //if (GameManager.instance.isWheatBuy)
        //{
        //    for (int i = 0; i < GameManager.instance.fieldPos.Length; i++)
        //    {
        //        timerMinutes[i] = (int)GameManager.instance.wheatTime / 60;
        //        timerSeconds[i] = (int)GameManager.instance.wheatTime % 60;
        //        if (GameManager.instance.player.fieldPos == GameManager.instance.fieldPos[i])
        //            plantImg[i].gameObject.GetComponent<Image>().sprite = Resources.Load("Wheat", typeof(Sprite)) as Sprite;
        //    }
        //    //timerMinutes = (int)GameManager.instance.wheatTime / 60;
        //    //timerSeconds = (int)GameManager.instance.wheatTime % 60;
        //    //if (GameManager.instance.player.fieldPos == GameManager.instance.field1Pos)
        //    //    plantImg.gameObject.GetComponent<Image>().sprite = Resources.Load("Wheat", typeof(Sprite)) as Sprite;
        //    //if (GameManager.instance.player.fieldPos == GameManager.instance.field2Pos)
        //    //    plantImg2.gameObject.GetComponent<Image>().sprite = Resources.Load("Wheat", typeof(Sprite)) as Sprite;
        //    //if (GameManager.instance.player.fieldPos == GameManager.instance.field3Pos)
        //    //    plantImg3.gameObject.GetComponent<Image>().sprite = Resources.Load("Wheat", typeof(Sprite)) as Sprite;
        //    //if (GameManager.instance.player.fieldPos == GameManager.instance.field4Pos)
        //    //    plantImg4.gameObject.GetComponent<Image>().sprite = Resources.Load("Wheat", typeof(Sprite)) as Sprite;
        //}
        //
        //for(int i = 0; i < fieldText.Length; i++)
        //{
        //    
        //}
        //ield1Text.text = string.Format("{0:D2}:{1:D2}", timerMinutes, timerSeconds);
        //ield2Text.text = string.Format("{0:D2}:{1:D2}", timerMinutes, timerSeconds);
        //ield3Text.text = string.Format("{0:D2}:{1:D2}", timerMinutes, timerSeconds);
        //ield4Text.text = string.Format("{0:D2}:{1:D2}", timerMinutes, timerSeconds);
        //if (GameManager.instance.isGreenPlantsBuy || GameManager.instance.isWheatBuy
        //    || GameManager.instance.isCornBuy || GameManager.instance.isBeetsBuy)
        //{
        //    for (int i = 0; i < GameManager.instance.fieldPos.Length; i++)
        //    {
        //        if (GameManager.instance.player.fieldPos == GameManager.instance.fieldPos[i])
        //            PanelPlant[i].gameObject.SetActive(true);
        //    }
        //        //if (GameManager.instance.player.fieldPos == GameManager.instance.field1Pos)
        //        //    PanelPlant1.gameObject.SetActive(true);
        //        //if (GameManager.instance.player.fieldPos == GameManager.instance.field2Pos)
        //        //    PanelPlant2.gameObject.SetActive(true);
        //        //if (GameManager.instance.player.fieldPos == GameManager.instance.field3Pos)
        //        //    PanelPlant3.gameObject.SetActive(true);
        //        //if (GameManager.instance.player.fieldPos == GameManager.instance.field4Pos)
        //        //    PanelPlant4.gameObject.SetActive(true);
        //}
        //else if (!GameManager.instance.player.isHarvestable)
        //{
        //    if (!GameManager.instance.isGreenPlantsBuy || !GameManager.instance.isWheatBuy
        //        || !GameManager.instance.isCornBuy ||!GameManager.instance.isBeetsBuy)
        //    {
        //        for (int i = 0; i < GameManager.instance.fieldPos.Length; i++)
        //        {
        //            if(GameManager.instance.player.fieldPos == GameManager.instance.fieldPos[i])
        //                PanelPlant[i].gameObject.SetActive(false);
        //        }
        //        //if (GameManager.instance.player.fieldPos == GameManager.instance.field1Pos)
        //        //    PanelPlant1.gameObject.SetActive(false);
        //        //if (GameManager.instance.player.fieldPos == GameManager.instance.field2Pos)
        //        //    PanelPlant2.gameObject.SetActive(false);
        //        //if (GameManager.instance.player.fieldPos == GameManager.instance.field3Pos)
        //        //    PanelPlant3.gameObject.SetActive(false);
        //        //if (GameManager.instance.player.fieldPos == GameManager.instance.field4Pos)
        //        //    PanelPlant4.gameObject.SetActive(false);
        //
        //    }
        //
        //}
        if (!GameManager.instance.player.isHarvestable)
        {
            //for(int i =0; i < PanelPlant.Length; i++)
            //{
            //    if(PanelPlant[i].activeSelf)
            //        fieldText[i].gameObject.SetActive(true);
            //}
            //if (PanelPlant1.activeSelf)
            //{
            //    field1Text.gameObject.SetActive(true);
            //    completeText.gameObject.SetActive(false);
            //}
            //if (PanelPlant2.activeSelf)
            //{
            //    field2Text.gameObject.SetActive(true);
            //    completeText2.gameObject.SetActive(false);
            //}
            //if (PanelPlant3.activeSelf)
            //{
            //    field3Text.gameObject.SetActive(true);
            //    completeText3.gameObject.SetActive(false);
            //}
            //if (PanelPlant4.activeSelf)
            //{
            //    field4Text.gameObject.SetActive(true);
            //    completeText4.gameObject.SetActive(false);
            //}

        }
        else if (GameManager.instance.player.isHarvestable)
        {
            //for(int i = 0; i < PanelPlant.Length; i++)
            //{
            //    if(PanelPlant[i].activeSelf)
            //    {
            //        fieldText[i].gameObject.SetActive(false);
            //        completeText[i].gameObject.SetActive(true);
            //    }    
            //}
            //if (PanelPlant1.activeSelf)
            //{
            //    field1Text.gameObject.SetActive(false);
            //    completeText.gameObject.SetActive(true);
            //}
            //if (PanelPlant2.activeSelf)
            //{
            //    field2Text.gameObject.SetActive(false);
            //    completeText2.gameObject.SetActive(true);
            //}
            //if (PanelPlant3.activeSelf)
            //{
            //    field3Text.gameObject.SetActive(false);
            //    completeText3.gameObject.SetActive(true);
            //}
            //if (PanelPlant4.activeSelf)
            //{
            //    field4Text.gameObject.SetActive(false);
            //    completeText4.gameObject.SetActive(true);
            //}
        }
    }
    public void GoldText()
    {
        goldText.text = "" + GameManager.instance.player.gold;
    }
    public void LevelText()
    {
        levelText.text = "Lv. " + GameManager.instance.player.playerLv;
    }
    public void HeartPointText()
    {
        heartPointText.text = "" +GameManager.instance.player.currentPlayerHeartPoint;
    }
    public void AmimalCapacityText()
    {
        animalCapacityText.text = "" + GameManager.instance.player.currentAnimalNum;
    }
    public void MaxAmimalCapacityText()
    {
        maxnAimalCapacityText.text = "" + GameManager.instance.player.animalCapacity;
    }

    public void AnimalNameText()
    {
        string name = GameManager.instance.player.clickanimal.name;
        int stringCount = GameManager.instance.player.clickanimal.name.Length;
        animalNameText.text = "" + name.Substring(0, stringCount - 7);
    }
    public void GiveLoveText()
    {
        if(animalInfo.activeSelf)
        {
            Animal aniaml = GameManager.instance.player.clickanimal.GetComponent<Animal>();
            giveLoveText.text = aniaml.currentLovePoint + "/" + aniaml.maxLovePoint;
        }
    }
    public void HeartTimerText()
    {
        if (GameManager.instance.isRechargable)
        {
            heartTimerText.gameObject.SetActive(true);
            
            heartTimerMinutes = (int)GameManager.instance.heartTimer / 60;
            heartTimerSeconds = (int)GameManager.instance.heartTimer % 60;
            heartTimerText.text = string.Format("{0:D2}:{1:D2}", heartTimerMinutes, heartTimerSeconds);
            
            //timerMinutes = (int)GameManager.instance.heartTimer / 60;
            //timerSeconds = (int)GameManager.instance.heartTimer % 60;
            //heartTimerText.text = string.Format("{0:D2}:{1:D2}", timerMinutes, timerSeconds);
        }
        else
            heartTimerText.gameObject.SetActive(false);
    }
    void Update()
    {
        for(int i = 0; i < PanelPlant.Length; i++)
        {
            if(PanelPlant[i].activeSelf)
                FieldText(PanelPlant[i],i);
        }
        //if (!PanelPlant1.activeSelf)
        //    FieldText(PanelPlant1);
        //if (!PanelPlant2.activeSelf)
        //    FieldText(PanelPlant2);
        //if (!PanelPlant3.activeSelf)
        //    FieldText(PanelPlant3);
        //if (!PanelPlant4.activeSelf)
        //    FieldText(PanelPlant4);

        Field1Text();
        HeartTimerText();
        GiveLoveText();
        HeartPointText();
        LevelText();
        GoldText();
        AmimalCapacityText();
        MaxAmimalCapacityText();

        if (animalInfo.activeSelf)
        {
            AnimalNameText();
            //GiveLoveText();
        }
        if(GameManager.instance.isWarning)
        {


            Animal aniaml = GameManager.instance.player.clickanimal.GetComponent<Animal>();
            warningPanel.SetActive(true);
            if (GameManager.instance.player.currentAnimalNum + 1 > GameManager.instance.player.animalCapacity)
            {
                warningText.text = "동물 자격증이 더 필요합니다!! \n 더 이상 동물을 생성 할 수 없습니다!!(＃°Д°)";
            }
            if (aniaml.currenLv < 3 && isClickBreedButton)
                warningText.text = "해당동물의 현재 레벨은 " + aniaml.currenLv +"입니다!! \n 동물의 레벨이 3일시 교배가 가능합니다(ﾉ*･ω･)ﾉ";
            if (GameManager.instance.player.currentPlayerHeartPoint <= 0)
                warningText.text = "애정포인트가 부족합니다!! \n 조금만 기다려주세요!!(＃°Д°)";
            //if(aniaml.currenLv == 3)
            //    warningText.text = "해당동물은 최대로 성장했습니다!! \n 더 이상 성장할 수 없습니다(ﾉ*･ω･)ﾉ";
            //if(GameManager.instance.isMax)
            //    warningText.text = "밭을 최대로 구매하셨습니다!! \n 더 이상 밭을 구매할 수 없습니다!!(＃°Д°)";

        }
        //FieldText(10);

        if (GameManager.instance.player.isLvUp)
        {
            warningPanel.SetActive(true);
            warningText.text = "Level " + GameManager.instance.player.playerLv + "로 \n 상승되었습니다(☆-ｖ -) \n 애정포인트 " 
                + (GameManager.instance.player.maxPlayerHeartPoint - 5 ) + " -> " + GameManager.instance.player.maxPlayerHeartPoint
                + "\n 동물자격증 " + (GameManager.instance.player.animalCapacity - 5) + " -> " + GameManager.instance.player.animalCapacity;
        }
        if (sellAnimalPanel.activeSelf)
        {
            sellText.text = "정말 선택한 동물을 팔겠습니까?" + "\n" + GameManager.instance.animal.sellingPrice + "골드를 얻을 수 있어요٩(｡•ω•｡)";
        }

    }
    public void FieldText(GameObject obj,int index)
    {
        var pos = Vector2.zero;
        var uiCamera = popUpText.uiCamera;
        var worldCamera = Camera.main;
        var canvasRect = popUpText.parentCanvas.GetComponent<RectTransform>();

        var screenPos = RectTransformUtility.WorldToScreenPoint(worldCamera, new Vector3((float)(fieldinfo[index].transform.position.x + 0.5), fieldinfo[index].transform.position.y + 2, fieldinfo[index].transform.position.z));
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, uiCamera, out pos);
        RectTransform rf = obj.GetComponent<RectTransform>();
        rf.localPosition = pos;
        obj.transform.localScale = new Vector3(1, 1, 1);
    }
}
