using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Start()
    {
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }
    public virtual void Click()
    {
        //Debug.Log(this.gameObject.name + " 클릭함");
        //Debug.Log("이 메세지는 상위클래스 ClickObject에서 출력");
    }
}
