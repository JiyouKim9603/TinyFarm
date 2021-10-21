using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Animal_State
{
    Idle, Peck, Walk
}
public class Animal : MonoBehaviour
{
    [SerializeField]
    Animal_State state;
    Vector3 targetPos;
    private Animator[] animator;
    LODGroup lODGroup;
    private float timer;

    public int currentLovePoint;
    public int maxLovePoint { get; private set; }
    public int currenLv { get; private set; }
    public int sellingPrice { get; private set; }
    int MaxLv;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        animator = GetComponentsInChildren<Animator>();
        lODGroup = GetComponent<LODGroup>();
        state = Animal_State.Idle;
        ChangeState(state);
        currentLovePoint = 0;
        maxLovePoint = 3;
        currenLv = 1;
        MaxLv = 3;
    }
    // Update is called once per frame
    void Update()
    {
        SellingAnimal();
        AnimalLevel();
        //animator.avatar = 

        //Debug.Log(state);
        switch(state)
        {
            case Animal_State.Idle: UpdateIdle(); break;
            case Animal_State.Walk: UpdateWalk(); break;
            case Animal_State.Peck: UpdatePeck(); break;
        }

        AnimalBreeding();

        //if(Mice, Dove, Tortoise의 currentLv == 1 일때는 maxLovePoint 3, currentLv == 2일때는 maxLovePoint 5)
        //(Rabbit, Dog, cat의 currnetLv == 1일때는 maxLovePoint = 5, currentLv == 2 일때는 maxLovePoint 8)
        if (currenLv == 1)
            maxLovePoint = 3;
        if (currenLv == 2)
            maxLovePoint = 5;
    }

    void UpdateIdle()
    {
    }

    void UpdateWalk()
    {

        float randomRotation = 0;
        randomRotation = Random.Range(-90.0f, 90.0f);
        Quaternion targetRotation = Quaternion.Euler(0, randomRotation, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        transform.position += transform.forward * Time.deltaTime;
    }
    void UpdatePeck()
    {
    }
    void SellingAnimal()
    {
        if(GameManager.instance.player.clickanimal.name == "Mice(Clone)")
        {
            switch(currenLv)
            {
                case 1:
                    sellingPrice = 50;
                    break;
                case 2:
                    sellingPrice = 70;
                    break;
                case 3:
                    sellingPrice = 90;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Mice1(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 90;
                    break;
                case 2:
                    sellingPrice = 110;
                    break;
                case 3:
                    sellingPrice = 130;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Mice2(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 130;
                    break;
                case 2:
                    sellingPrice = 150;
                    break;
                case 3:
                    sellingPrice = 170;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Dove(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 100;
                    break;
                case 2:
                    sellingPrice = 130;
                    break;
                case 3:
                    sellingPrice = 160;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Dove1(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 160;
                    break;
                case 2:
                    sellingPrice = 190;
                    break;
                case 3:
                    sellingPrice = 210;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Dove2(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 210;
                    break;
                case 2:
                    sellingPrice = 230;
                    break;
                case 3:
                    sellingPrice = 250;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Tortoise(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 200;
                    break;
                case 2:
                    sellingPrice = 230;
                    break;
                case 3:
                    sellingPrice = 260;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Tortoise1(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 260;
                    break;
                case 2:
                    sellingPrice = 290;
                    break;
                case 3:
                    sellingPrice = 320;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Tortoise2(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 320;
                    break;
                case 2:
                    sellingPrice = 350;
                    break;
                case 3:
                    sellingPrice = 380;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Rabbit(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 300;
                    break;
                case 2:
                    sellingPrice = 330;
                    break;
                case 3:
                    sellingPrice = 360;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Rabbit1(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 360;
                    break;
                case 2:
                    sellingPrice = 390;
                    break;
                case 3:
                    sellingPrice = 420;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Rabbit2(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 420;
                    break;
                case 2:
                    sellingPrice = 450;
                    break;
                case 3:
                    sellingPrice = 480;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Dog(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 400;
                    break;
                case 2:
                    sellingPrice = 450;
                    break;
                case 3:
                    sellingPrice = 500;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Dog1(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 500;
                    break;
                case 2:
                    sellingPrice = 550;
                    break;
                case 3:
                    sellingPrice = 600;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Dog2(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 600;
                    break;
                case 2:
                    sellingPrice = 650;
                    break;
                case 3:
                    sellingPrice = 700;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Cat(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 500;
                    break;
                case 2:
                    sellingPrice = 550;
                    break;
                case 3:
                    sellingPrice = 600;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Cat1(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 600;
                    break;
                case 2:
                    sellingPrice = 650;
                    break;
                case 3:
                    sellingPrice = 700;
                    break;
            }
        }
        if (GameManager.instance.player.clickanimal.name == "Cat2(Clone)")
        {
            switch (currenLv)
            {
                case 1:
                    sellingPrice = 750;
                    break;
                case 2:
                    sellingPrice = 800;
                    break;
                case 3:
                    sellingPrice = 850;
                    break;
            }
        }
    }


    void ChangeState(Animal_State nextState)
    {
        state = nextState;
        foreach (Animator anim in animator)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalk", false);
            anim.SetBool("isPeck", false);
        }
        StopAllCoroutines();
        switch (state)
        {
            case Animal_State.Idle: StartCoroutine(CoroutineIdle()); break;
            case Animal_State.Walk: StartCoroutine(CoroutineWalk()); break;
            case Animal_State.Peck: StartCoroutine(CoroutinePeck()); break;
        }

    }
    IEnumerator CoroutineIdle()
    {
        // 최초에 한번 실행되는 코드
        foreach (Animator anim in animator)
        {
            anim.SetBool("isIdle", true);
        }


        yield return new WaitForSeconds(3f);
        ChangeState(Animal_State.Walk);

        //while (true)
        //{
        //    ChangeState(Animal_State.Walk);
        //    yield break;
        //}
    }
    IEnumerator CoroutineWalk()
    {
        // 최초에 한번 실행되는 코드
        foreach (Animator anim in animator)
        {
            anim.SetBool("isWalk", true);
        }
        targetPos = transform.position + new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));

        yield return new WaitForSeconds(2f);
        ChangeState(Animal_State.Peck);
    }

    IEnumerator CoroutinePeck()
    {
        // 최초에 한번 실행되는 코드
        foreach (Animator anim in animator)
        {
            anim.SetBool("isPeck", true);
        }
        yield return new WaitForSeconds(2f);
        ChangeState(Animal_State.Idle);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime);

            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private Vector3 m_Offset;
    private float m_ZCoord;

    void OnMouseDown()
    {
        m_ZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        m_Offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + m_Offset;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = m_ZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void AnimalLevel()
    {
        switch(currenLv)
        {
            case 1:
                if (currentLovePoint >= maxLovePoint)
                {
                    currenLv++;
                    UIManager.instance.popUpText.PopUpLvText();
                    transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    currentLovePoint = 0;
                    //maxLovePoint = 5;
                }
                break;
            case 2:
                if (currentLovePoint >= maxLovePoint)
                {
                    currenLv = 3;
                    UIManager.instance.popUpText.PopUpLvText();
                    transform.localScale = new Vector3(1, 1, 1);
                    currentLovePoint = 0;
                }
                break;
        }
    }
    
    void AnimalBreeding()
    {
       if(GameManager.instance.isBreeding)
       {

            if (GameManager.instance.player.clickanimal.name == "Dove(Clone)")
            {
                GameManager.instance.objPool.SpawnFromPool("DoveLv1", GameManager.instance.player.clickanimal.transform.position, Quaternion.identity);
                GameManager.instance.player.ExCalculrator(20);
            }
            else if (GameManager.instance.player.clickanimal.name == "Dove1(Clone)")
            {
                GameManager.instance.objPool.SpawnFromPool("DoveLv2", GameManager.instance.player.clickanimal.transform.position, Quaternion.identity);
                GameManager.instance.player.ExCalculrator(25);
            }
            else if (GameManager.instance.player.clickanimal.name == "Mice(Clone)")
            {
                GameManager.instance.objPool.SpawnFromPool("Mice1", GameManager.instance.player.clickanimal.transform.position, Quaternion.identity);
                GameManager.instance.player.ExCalculrator(10);
            }
            else if (GameManager.instance.player.clickanimal.name == "Mice1(Clone)")
            {
                GameManager.instance.objPool.SpawnFromPool("Mice2", GameManager.instance.player.clickanimal.transform.position, Quaternion.identity);
                GameManager.instance.player.ExCalculrator(15);
            }
            else if (GameManager.instance.player.clickanimal.name == "Tortoise(Clone)")
            {
                GameManager.instance.objPool.SpawnFromPool("Tortoise1", GameManager.instance.player.clickanimal.transform.position, Quaternion.identity);
                GameManager.instance.player.ExCalculrator(30);
            }
            else if (GameManager.instance.player.clickanimal.name == "Tortoise1(Clone)")
            {
                GameManager.instance.objPool.SpawnFromPool("Tortoise2", GameManager.instance.player.clickanimal.transform.position, Quaternion.identity);
                GameManager.instance.player.ExCalculrator(35);
            }
            else if (GameManager.instance.player.clickanimal.name == "Rabbit(Clone)")
            {
                GameManager.instance.objPool.SpawnFromPool("Rabbit1", GameManager.instance.player.clickanimal.transform.position, Quaternion.identity);
                GameManager.instance.player.ExCalculrator(40);
            }
            else if (GameManager.instance.player.clickanimal.name == "Rabbit1(Clone)")
            {
                GameManager.instance.objPool.SpawnFromPool("Rabbit2", GameManager.instance.player.clickanimal.transform.position, Quaternion.identity);
                GameManager.instance.player.ExCalculrator(45);
            }
            else if (GameManager.instance.player.clickanimal.name == "Dog(Clone)")
            {
                GameManager.instance.objPool.SpawnFromPool("Dog1", GameManager.instance.player.clickanimal.transform.position, Quaternion.identity);
                GameManager.instance.player.ExCalculrator(50);
            }
            else if (GameManager.instance.player.clickanimal.name == "Dog1(Clone)")
            {
                GameManager.instance.objPool.SpawnFromPool("Dog2", GameManager.instance.player.clickanimal.transform.position, Quaternion.identity);
                GameManager.instance.player.ExCalculrator(55);
            }
            else if (GameManager.instance.player.clickanimal.name == "Cat(Clone)")
            {
                GameManager.instance.objPool.SpawnFromPool("Cat1", GameManager.instance.player.clickanimal.transform.position, Quaternion.identity);
                GameManager.instance.player.ExCalculrator(200);
            }
            else if (GameManager.instance.player.clickanimal.name == "Cat1(Clone)")
            {
                GameManager.instance.objPool.SpawnFromPool("Cat2", GameManager.instance.player.clickanimal.transform.position, Quaternion.identity);
                GameManager.instance.player.ExCalculrator(65);
            }

            GameManager.instance.isBreeding = false;
       }
    }
}
