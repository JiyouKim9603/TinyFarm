using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Image image;
    public bool isChagneScene;
    float fadeCount = 1;
    bool _test = false;
    public Text introText;
    [TextArea]
    public string stroy = "What the Animal \n㇏(•̀ᵥᵥ•́)ノ";

    // Start is called before the first frame update
    void Start()
    {
        isChagneScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChagneScene)
        {
            fadeCount += 0.01f;
            if (fadeCount >= 1)
                fadeCount = 1;
        }
        else
        {
            fadeCount -= 0.01f;
            if (fadeCount <= 0)
                fadeCount = 0;
        }

        Color color = image.color;
        color.a = fadeCount;
        image.color = color;

        //if (image.color.a >= 1 && !_test)
        //{
        //    _test = true;
        //    StartCoroutine("PlayIntroText");
        //}
    }
   //IEnumerator PlayIntroText()
   //{
   //    introText.gameObject.SetActive(true);
   //    foreach (char c in stroy)
   //    {
   //        introText.text += c;
   //        yield return new WaitForSeconds(0.125f);
   //    }
   //    yield return new WaitForSeconds(1f);
   //    GameManager.instance.ChangeScene();
   //}
}
