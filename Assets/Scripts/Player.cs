using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Image image;
    float fadeCount = 1;
    public int playerLv { get; private set; }
    public int playerEx { get; private set; }
    public int gold { get; private set; }
    public int currentPlayerHeartPoint;
    public int maxPlayerHeartPoint;
    private GameObject UIobj;
    public string name;
    public GameObject clickanimal;
    public int animalCapacity;
    public int currentAnimalNum;
    public bool isLvUp;
    public bool isHarvestable;
    public bool isPlayerMove;
    public Vector3 fieldPos;

    // Start is called before the first frame update
    void Start()
    {
        currentAnimalNum = 0;
        playerLv = 1;
        playerEx = 0;
        currentPlayerHeartPoint = 10;
        gold = 10000000;
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerLv)
        {
            case 1:
                animalCapacity = 5;
                maxPlayerHeartPoint = 10;
                if (playerEx >= 150)
                {
                    playerLv = 2;
                    GameManager.instance.Lv2Map.SetActive(true);
                    isLvUp = true;
                }
                break;
            case 2:
                animalCapacity = 15;
                maxPlayerHeartPoint = 15;
                if (playerEx >= 400)
                {
                    playerLv = 3;
                    GameManager.instance.Lv3Map.SetActive(true);
                    isLvUp = true;
                }

                break;
            case 3:
                maxPlayerHeartPoint = 20;
                animalCapacity = 20;
                break;
        }
        
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("Name : " + MouseClick().gameObject.name);
            if(MouseClick().gameObject.tag == "Animal")
            {
                UIManager.instance.animalInfo.SetActive(true);
                clickanimal = MouseClick().gameObject;
                GameManager.instance.animal = clickanimal.GetComponent<Animal>();
                if (UIobj != null) 
                {
                    GameManager.instance.objPool.ReturnToPool(name, UIobj);
                    UIobj = null;
                }

                if(UIobj == null) 
                {
                    if (MouseClick().gameObject.name == "Dove(Clone)") 
                        name = "UIDove";
                    if (MouseClick().gameObject.name == "Dove1(Clone)")
                        name = "UIDove1";
                    if (MouseClick().gameObject.name == "Dove2(Clone)")
                        name = "UIDove2";
                    if (MouseClick().gameObject.name == "Mice(Clone)")
                        name = "UIMice";
                    if (MouseClick().gameObject.name == "Mice1(Clone)")
                        name = "UIMice1";
                    if (MouseClick().gameObject.name == "Mice2(Clone)")
                        name = "UIMice2";
                    if (MouseClick().gameObject.name == "Tortoise(Clone)")
                        name = "UITortoise";
                    if (MouseClick().gameObject.name == "Tortoise1(Clone)")
                        name = "UITortoise1";
                    if (MouseClick().gameObject.name == "Tortoise2(Clone)")
                        name = "UITortoise2";
                    if (MouseClick().gameObject.name == "Rabbit(Clone)")
                        name = "UIRabbit";
                    if (MouseClick().gameObject.name == "Rabbit1(Clone)")
                        name = "UIRabbit1";
                    if (MouseClick().gameObject.name == "Rabbit2(Clone)")
                        name = "UIRabbit2";
                    if (MouseClick().gameObject.name == "Dog(Clone)")
                        name = "UIDog";
                    if (MouseClick().gameObject.name == "Dog1(Clone)")
                        name = "UIDog1";
                    if (MouseClick().gameObject.name == "Dog2(Clone)")
                        name = "UIDog2";
                    if (MouseClick().gameObject.name == "Cat(Clone)")
                        name = "UICat";
                    if (MouseClick().gameObject.name == "Cat1(Clone)")
                        name = "UICat1";
                    if (MouseClick().gameObject.name == "Cat2(Clone)")
                        name = "UICat2";
                    UIobj = GameManager.instance.objPool.SpawnFromPool(name, Vector3.zero, Quaternion.identity);
                }
                Debug.Log("name : " + MouseClick().gameObject.name);
            }
            if (MouseClick().gameObject.tag == "Field") 
            {
                if(!GameManager.instance.isGreenPlantsBuy || !GameManager.instance.isBeetsBuy
                    || !GameManager.instance.isCornBuy || !GameManager.instance.isWheatBuy)
                {
                    UIManager.instance.fieldPanel.SetActive(true);
                    Debug.Log("POS :" + MouseClick().gameObject.transform.position);
                    fieldPos = MouseClick().gameObject.transform.position;
                }
                

            }
            if (MouseClick().gameObject.tag == "Shop")
            {
                UIManager.instance.ShopPanel.SetActive(true);
            }
            //if(isHarvestable)
            {
                if(MouseClick().gameObject.name == "GreenPlants(Clone)")
                {
                    for(int i = 0; i < UIManager.instance.fieldinfo.Length; i++)
                    {
                        if(UIManager.instance.completeText[i].gameObject.activeSelf)
                            UIManager.instance.PanelPlant[i].gameObject.SetActive(false);
                    }
                    GameManager.instance.objPool.ReturnToPool("GreenPlants", MouseClick().gameObject);
                    GameManager.instance.isGreenPlantsBuy = false;
                    GoldCalculrator(50);
                    
                }
                if (MouseClick().gameObject.name == "Corn(Clone)")
                {
                    for (int i = 0; i < UIManager.instance.fieldinfo.Length; i++)
                    {
                        if (UIManager.instance.completeText[i].gameObject.activeSelf)
                            UIManager.instance.PanelPlant[i].gameObject.SetActive(false);
                    }
                    GameManager.instance.objPool.ReturnToPool("Corn", MouseClick().gameObject);
                    GameManager.instance.isCornBuy = false;
                    GoldCalculrator(100);

                }
                if (MouseClick().gameObject.name == "Beets(Clone)")
                {
                    for (int i = 0; i < UIManager.instance.fieldinfo.Length; i++)
                    {
                        if (UIManager.instance.completeText[i].gameObject.activeSelf)
                            UIManager.instance.PanelPlant[i].gameObject.SetActive(false);
                    }
                    GameManager.instance.objPool.ReturnToPool("Beets", MouseClick().gameObject);
                    GameManager.instance.isBeetsBuy = false;
                    GoldCalculrator(170);

                }
                if (MouseClick().gameObject.name == "Wheat(Clone)")
                {
                    for (int i = 0; i < UIManager.instance.fieldinfo.Length; i++)
                    {
                        if (UIManager.instance.completeText[i].gameObject.activeSelf)
                            UIManager.instance.PanelPlant[i].gameObject.SetActive(false);
                    }
                    GameManager.instance.objPool.ReturnToPool("Wheat", MouseClick().gameObject);
                    GameManager.instance.isWheatBuy = false;
                    GoldCalculrator(300);

                }
                isHarvestable = false;
            }


        }
        if (Input.GetKeyDown(KeyCode.Escape))
            UIManager.instance.animalInfo.SetActive(false);
        Color color = image.color;
        fadeCount -= 0.1f;
        if (fadeCount <= 0)
            fadeCount = 0;
        image.color = color;

        float translation = Input.GetAxis("Vertical") * 10;
        float rotation = Input.GetAxis("Horizontal") * 100;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, -translation);

        transform.Rotate(0, rotation, 0);

    }
    public GameObject MouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject obj = hit.transform.gameObject;
            return obj;
        }
        return null;
    }
    public void GoldCalculrator(int price)
    {
        gold += price;
    }
    public void ExCalculrator(int exprience)
    {
        playerEx += exprience;
    }
    public void HeartPointCalculrator(int heartPoint)
    {
        currentPlayerHeartPoint += heartPoint;
    }
    public void AnimalCountCalculrator(int animalCount)
    {
        currentAnimalNum += animalCount;
    }
}
