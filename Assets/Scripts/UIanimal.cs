using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIanimal : MonoBehaviour
{
    Transform Parentstransform;
    // Start is called before the first frame update
    void Start()
    {
        Parentstransform = GameObject.Find("backgroundHalfCustom").GetComponent<Transform>();
        transform.SetParent(Parentstransform);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf) 
        {
            transform.localPosition = new Vector3(-200, -50, -30);
            transform.localScale = new Vector3(150, 150, 150);
            transform.localRotation = Quaternion.Euler(0, 140, 0);
        }
        
    }
}
