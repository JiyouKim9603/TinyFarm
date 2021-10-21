using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public Text pressText;
    public bool isStart { get; private set; }
    float time;
    void Start()
    {
        time = Time.time;
        isStart = false;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            isStart = true;
            //GameManager.instance.fadeController.isChagneScene = true;
            GameManager.instance.ChangeScene();
        }

        if (!isStart && Time.time - time >= .5f)
        {
            time = Time.time;
            pressText.gameObject.SetActive(!pressText.gameObject.activeSelf);
        }

        if (isStart && Time.time - time >= .1f)
        {
            time = Time.time;
            pressText.gameObject.SetActive(!pressText.gameObject.activeSelf);
        }
    }
}
