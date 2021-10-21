using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public int page = 1;
    public int LastPage;

    public void OnClickExit()
    {
        if(UIManager.instance.animalInfo.activeSelf)
            UIManager.instance.animalInfo.SetActive(false);
        if (UIManager.instance.ShopPanel.activeSelf == true)
            UIManager.instance.ShopPanel.SetActive(false);
        if (UIManager.instance.fieldPanel.activeSelf)
            UIManager.instance.fieldPanel.SetActive(false);
        if (UIManager.instance.warningPanel.activeSelf)
        {
            UIManager.instance.warningPanel.SetActive(false);
            GameManager.instance.isWarning = false;
            GameManager.instance.player.isLvUp = false;
            UIManager.instance.isClickBreedButton = false;
        }
        if (UIManager.instance.sellAnimalPanel.activeSelf)
            UIManager.instance.sellAnimalPanel.SetActive(false);
        if (UIManager.instance.MovePanel.activeSelf)
            UIManager.instance.MovePanel.SetActive(false);

        //if (animalInfo.activeSelf == true)
        //    animalInfo.SetActive(false);
        //if (ShopPanel.activeSelf == true)
        //    ShopPanel.SetActive(false);
    }

    public void OnClickLove()
    {  
        Animal aniaml = GameManager.instance.player.clickanimal.GetComponent<Animal>();
        if (GameManager.instance.player.currentPlayerHeartPoint > 0 && aniaml.currenLv < 3)
        {
            UIManager.instance.popUpText.HeartCreate();
            aniaml.currentLovePoint++;
            GameManager.instance.player.HeartPointCalculrator(-1);
        }
        if(GameManager.instance.player.currentPlayerHeartPoint <= 0 || aniaml.currenLv == 3)
        {
            GameManager.instance.isWarning = true;
        }
    }
    public void OnClickBreeding()
    {
        // TODO : 교배조건 걸어주기
        if (GameManager.instance.animal.currenLv == 3 /* 다른 종류의 레벨도 3일때*/)
        {
            if (GameManager.instance.player.animalCapacity > GameManager.instance.player.currentAnimalNum + 1)
            {
                GameManager.instance.isBreeding = true;
                UIManager.instance.ShopPanel.SetActive(false);
                GameManager.instance.player.AnimalCountCalculrator(1);
            }
            else
                GameManager.instance.isWarning = true;
        }
        else if (GameManager.instance.animal.currenLv < 3)
        {
            GameManager.instance.isWarning = true;
            UIManager.instance.isClickBreedButton = true;
        }
        


        //ShopPanel.SetActive(false
        //
    }

    public void OnClickBuyingDove()
    {
        if (GameManager.instance.player.gold - 100 >= 0 && GameManager.instance.player.currentAnimalNum < GameManager.instance.player.animalCapacity)    // 동물 자격증이 있다면
        {
            GameManager.instance.isDoveBuy = true;
            UIManager.instance.ShopPanel.SetActive(false);
            GameManager.instance.player.AnimalCountCalculrator(1);
            //ShopPanel.SetActive(false);
        }
        if(GameManager.instance.player.animalCapacity < GameManager.instance.player.currentAnimalNum + 1)
            GameManager.instance.isWarning = true;
    }
    public void OnClickBuyingMice()
    {
        if (GameManager.instance.player.gold - 50 >= 0 && GameManager.instance.player.currentAnimalNum < GameManager.instance.player.animalCapacity)    // 동물 자격증이 있다면
        {
            GameManager.instance.isMiceBuy = true;
            GameManager.instance.player.AnimalCountCalculrator(1);
            UIManager.instance.ShopPanel.SetActive(false);
            //ShopPanel.SetActive(false);
        }
        if (GameManager.instance.player.animalCapacity < GameManager.instance.player.currentAnimalNum + 1)
            GameManager.instance.isWarning = true;
    }
    public void OnClickBuyingTortoise()
    {
        if (GameManager.instance.player.gold - 200 >= 0 && GameManager.instance.player.currentAnimalNum < GameManager.instance.player.animalCapacity)    // 동물 자격증이 있다면
        {
            GameManager.instance.isTortoiseBuy = true;
            UIManager.instance.ShopPanel.SetActive(false);
            GameManager.instance.player.AnimalCountCalculrator(1);
            //ShopPanel.SetActive(false);
        }
        if (GameManager.instance.player.animalCapacity < GameManager.instance.player.currentAnimalNum + 1)
            GameManager.instance.isWarning = true;
    }
    public void OnClickBuyingRabbit()
    {
        if (GameManager.instance.player.gold - 300 >= 0 && GameManager.instance.player.currentAnimalNum < GameManager.instance.player.animalCapacity)    // 동물 자격증이 있다면
        {
            GameManager.instance.isRabbitBuy = true;
            UIManager.instance.ShopPanel.SetActive(false);
            GameManager.instance.player.AnimalCountCalculrator(1);
            //ShopPanel.SetActive(false);
        }
        if (GameManager.instance.player.animalCapacity < GameManager.instance.player.currentAnimalNum + 1)
            GameManager.instance.isWarning = true;
    }
    public void OnClickBuyingDog()
    {
        if (GameManager.instance.player.gold - 400 >= 0 && GameManager.instance.player.currentAnimalNum < GameManager.instance.player.animalCapacity)    // 동물 자격증이 있다면
        {
            GameManager.instance.isDogBuy = true;
            UIManager.instance.ShopPanel.SetActive(false);
            GameManager.instance.player.AnimalCountCalculrator(1);
            //ShopPanel.SetActive(false);
        }
        if (GameManager.instance.player.animalCapacity < GameManager.instance.player.currentAnimalNum + 1)
            GameManager.instance.isWarning = true;
    }
    public void OnClickBuyingCat()
    {
        if (GameManager.instance.player.gold - 500 >= 0 && GameManager.instance.player.currentAnimalNum < GameManager.instance.player.animalCapacity)    // 동물 자격증이 있다면
        {
            GameManager.instance.isCatBuy = true;
            UIManager.instance.ShopPanel.SetActive(false);
            GameManager.instance.player.AnimalCountCalculrator(1);
            //ShopPanel.SetActive(false);
        }
        if (GameManager.instance.player.animalCapacity < GameManager.instance.player.currentAnimalNum + 1)
            GameManager.instance.isWarning = true;
    }

    public void OnClickNextButton()
    {
        if (page == LastPage)
            page = LastPage;
        else
            page++;
    }
    public void OnClickPreviousButton()
    {
        if (page == 1)
            page = 1;
        else 
            page--;

    }
    public void OnClickFieldButton()
    {
        if (GameManager.instance.fieldNum < 4)
        {
            GameManager.instance.isFieldBuy = true;
        }
        else
        {
            GameManager.instance.isMax = true;
            GameManager.instance.isWarning = true;
            UIManager.instance.warningText.text = "밭을 최대로 구매하셨습니다!! \n 더 이상 밭을 구매할 수 없습니다!!(＃°Д°)";
        }
        UIManager.instance.ShopPanel.SetActive(false);
    }

    public void OnClickGreenPlantsButton()
    {
        GameManager.instance.player.GoldCalculrator(-30);

        for (int i = 0; i < UIManager.instance.fieldinfo.Length; i++) 
        {
            if (UIManager.instance.fieldinfo[i] == null) continue;
            if (UIManager.instance.fieldinfo[i] && GameManager.instance.player.fieldPos == UIManager.instance.fieldinfo[i].transform.position) 
            {
                UIManager.instance.fieldinfo[i].isGreenPlantsBuy = true;
            }
        }
        UIManager.instance.fieldPanel.SetActive(false);
    }
    public void OnClickBeetsButton()
    {
        GameManager.instance.player.GoldCalculrator(-70);
        for (int i = 0; i < UIManager.instance.fieldinfo.Length; i++)
        {
            if (UIManager.instance.fieldinfo[i] == null) continue;
            if (UIManager.instance.fieldinfo[i] && GameManager.instance.player.fieldPos == UIManager.instance.fieldinfo[i].transform.position)
            {
                UIManager.instance.fieldinfo[i].isBeetsBuy = true;
            }
        }
        //UIManager.instance.fieldPanel.SetActive(false);
        //GameManager.instance.isBeetsBuy = true;
        UIManager.instance.fieldPanel.SetActive(false);
    }
    public void OnClickWheatButton()
    {
        GameManager.instance.player.GoldCalculrator(-100);
        for (int i = 0; i < UIManager.instance.fieldinfo.Length; i++)
        {
            if (UIManager.instance.fieldinfo[i] == null) continue;
            if (UIManager.instance.fieldinfo[i] && GameManager.instance.player.fieldPos == UIManager.instance.fieldinfo[i].transform.position)
            {
                UIManager.instance.fieldinfo[i].isWheatBuy = true;
            }
        }
        //UIManager.instance.fieldPanel.SetActive(false);
        //GameManager.instance.isWheatBuy = true;
        UIManager.instance.fieldPanel.SetActive(false);
    }
    public void OnClickCornButton()
    {
        GameManager.instance.player.GoldCalculrator(-50);
        for (int i = 0; i < UIManager.instance.fieldinfo.Length; i++)
        {
            if (UIManager.instance.fieldinfo[i] == null) continue;
            if (UIManager.instance.fieldinfo[i] && GameManager.instance.player.fieldPos == UIManager.instance.fieldinfo[i].transform.position)
            {
                UIManager.instance.fieldinfo[i].isCornBuy = true;
            }
        }
       //UIManager.instance.fieldPanel.SetActive(false);
       //GameManager.instance.isCornBuy = true;
        UIManager.instance.fieldPanel.SetActive(false);
    }
    public void OnClickSellAnimal()
    {
        UIManager.instance.sellAnimalPanel.SetActive(true);
    }
    public void OnClickSellAnimalCfm()
    {
        string name = GameManager.instance.player.clickanimal.name;
        int stringCount = GameManager.instance.player.clickanimal.name.Length;
        GameManager.instance.objPool.ReturnToPool(name.Substring(0,stringCount - 7), GameManager.instance.player.clickanimal);
        GameManager.instance.player.GoldCalculrator(GameManager.instance.animal.sellingPrice);
        GameManager.instance.player.AnimalCountCalculrator(-1);
        UIManager.instance.sellAnimalPanel.SetActive(false);
        UIManager.instance.animalInfo.SetActive(false);
    }
    public void OnClicMoveToHome()
    {
        Vector3 targetPos = new Vector3(-0, -5, -10);
        GameManager.instance.player.transform.position = targetPos;
        UIManager.instance.MovePanel.SetActive(false);
    }

    public void OnClicMoveToBeach()
    {
        //GameManager.instance.player.isPlayerMove = true;
        //if(GameManager.instance.player.isPlayerMove)
        //{
        //    Vector3 targetPos = new Vector3(-50, -5, -10);
        //    GameManager.instance.player.transform.position = Vector3.MoveTowards(GameManager.instance.player.transform.position, targetPos, 0.1f);
        //    if(GameManager.instance.player.transform.position == targetPos)
        //        GameManager.instance.player.isPlayerMove = false;
        //}
        if(GameManager.instance.player.playerLv >= 2)
        {
            Vector3 targetPos = new Vector3(-90, -5, -10);
            GameManager.instance.player.transform.position = targetPos;
        }
        UIManager.instance.MovePanel.SetActive(false);
    }
    public void OnClicMoevToTown()
    {
        if (GameManager.instance.player.playerLv >= 3)
        {
            Vector3 targetPos = new Vector3(-55, -5, -50);
            GameManager.instance.player.transform.position = targetPos;
        }
        UIManager.instance.MovePanel.SetActive(false);
    }
    public void OnClicMove()
    {
        UIManager.instance.MovePanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Page();
    }
    public void Page()
    {
        if (page == 1)
        {
            UIManager.instance.firstPage.SetActive(true);
            UIManager.instance.secondPage.SetActive(false);
            UIManager.instance.thirdPage.SetActive(false);
        }
        else if (page == 2)
        {
            UIManager.instance.firstPage.SetActive(false);
            UIManager.instance.secondPage.SetActive(true);
            UIManager.instance.thirdPage.SetActive(false);
        }
        else if (page == 3)
        {
            UIManager.instance.firstPage.SetActive(false);
            UIManager.instance.secondPage.SetActive(false);
            UIManager.instance.thirdPage.SetActive(true);
        }

    }
}
