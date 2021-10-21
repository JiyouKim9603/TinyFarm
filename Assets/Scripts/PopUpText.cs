using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour
{
    public Camera uiCamera;
    public GameObject parentCanvas;
    public GameObject fieldText;
    private Vector3 startPos;

    public void HeartCreate() //이게 하트 생성하는 코드
    {
        var pos = Vector2.zero;
        var uiCamera = this.uiCamera;
        var worldCamera = Camera.main;
        var canvasRect = parentCanvas.GetComponent<RectTransform>();

        var screenPos = RectTransformUtility.WorldToScreenPoint(worldCamera, GameManager.instance.player.clickanimal.transform.position);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, uiCamera, out pos);
        GameObject image = GameManager.instance.objPool.SpawnFromPool("HeartImg", GameManager.instance.player.clickanimal.transform.position, Quaternion.identity);
        image.transform.SetParent(parentCanvas.transform);
        RectTransform rf = image.GetComponent<RectTransform>();
        rf.localPosition = pos;
        image.transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.5);
        startPos.y = rf.anchoredPosition.y;
        StartCoroutine(FadeOut(image, 30,"HeartImg"));//이런식? 올 ㅋ
    }

    public IEnumerator FadeOut(GameObject heartImg, float speed , string names) // 얘도 옮길까 얘도 사실 누구나 쓸수 있는거로 바꾸면 좋지
    {
        while (heartImg.GetComponent<RectTransform>().anchoredPosition.y <= startPos.y + 30)
        {
            heartImg.GetComponent<RectTransform>().anchoredPosition
                = new Vector3(heartImg.GetComponent<RectTransform>().anchoredPosition.x, heartImg.GetComponent<RectTransform>().anchoredPosition.y + (Time.deltaTime * speed));
            yield return null;

        }
        GameManager.instance.objPool.ReturnToPool(names, heartImg);
    }

    public void PopUpLvText()
    {
        var pos = Vector2.zero;
        var uiCamera = this.uiCamera;
        var worldCamera = Camera.main;
        var canvasRect = parentCanvas.GetComponent<RectTransform>();

        var screenPos = RectTransformUtility.WorldToScreenPoint(worldCamera, GameManager.instance.player.clickanimal.transform.position);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, uiCamera, out pos);
        GameObject image = GameManager.instance.objPool.SpawnFromPool("LvUpText", GameManager.instance.player.clickanimal.transform.position, Quaternion.identity);
        image.transform.SetParent(parentCanvas.transform);
        RectTransform rf = image.GetComponent<RectTransform>();
        rf.localPosition = pos;
        image.transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.5);
        startPos.y = rf.anchoredPosition.y;
        StartCoroutine(PopUpLvTextOut(image, 30));

        //levelUpText.transform.position = GameManager.instance.player.animalPos;
        //levelUpText.gameObject.SetActive(true);
        //startPos = GameManager.instance.player.animalPos;
        //StartCoroutine(PopUpLvTextOut(levelUpText, 30));
    }

    public IEnumerator PopUpLvTextOut(GameObject LvUpText, float speed)
    {
        while (LvUpText.GetComponent<RectTransform>().anchoredPosition.y <= startPos.y + 30)
        {
            LvUpText.GetComponent<RectTransform>().anchoredPosition
                = new Vector3(LvUpText.GetComponent<RectTransform>().anchoredPosition.x, LvUpText.GetComponent<RectTransform>().anchoredPosition.y + (Time.deltaTime * speed));
            yield return null;

        }
        GameManager.instance.objPool.ReturnToPool("LvUpText", LvUpText);
        //while (levelUpText.transform.position.y <= startPos.y + 1000)
        //{
        //    levelUpText.transform.position = new Vector3(levelUpText.transform.position.x, levelUpText.transform.position.y + (Time.deltaTime * speed));
        //    yield return null;
        //}
        //levelUpText.gameObject.SetActive(false);
    }

    
}
