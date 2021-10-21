using UnityEngine;
using UnityEngine.UI;

public class CreateGridItem : MonoBehaviour
{
    public Sprite[] sprites;
    public Vector2 cellSize;
    public int constraintCount;
    public Vector2 spacing;

    private GridLayoutGroup gridLayoutGroup;

    private void Start()
    {
        Create();
    }


    [Header("BackButton------------")]
    public bool isBgIcon = false;
    public Sprite spriteBG;
    public float centerValueY = 6.3f;

    public void Create()
    {
        GameObject ob = new GameObject();
        ob.transform.SetParent(transform);
        gridLayoutGroup = ob.AddComponent<GridLayoutGroup>();

        gridLayoutGroup.cellSize = new Vector2(cellSize.x, cellSize.y);
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = constraintCount;
        gridLayoutGroup.spacing = spacing;
        gridLayoutGroup.childAlignment = TextAnchor.MiddleCenter;
        ob.transform.localPosition = new Vector3(0f, -60f, 0f);
        ob.transform.localScale = Vector3.one;
        ob.name = "Group";

        if (isBgIcon)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                GameObject spriteOb = new GameObject();
                spriteOb.transform.SetParent(ob.transform);
                spriteOb.transform.localScale = Vector3.one;
                Image image = spriteOb.AddComponent<Image>();
                image.sprite = spriteBG;
                CreateIcon(spriteOb, i);
            }
        }
        else
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                GameObject spriteOb = new GameObject();
                spriteOb.transform.SetParent(ob.transform);
                spriteOb.transform.localScale = Vector3.one;
                Image image = spriteOb.AddComponent<Image>();

                image.sprite = sprites[i];
                image.SetNativeSize();
                image.name = image.sprite.name;
            }
        }

    }

    public void CreateIcon(GameObject ob, int i)
    {
        GameObject spriteOb = new GameObject();
        spriteOb.transform.SetParent(ob.transform);
        spriteOb.transform.localScale = Vector3.one;
        spriteOb.transform.localPosition = new Vector3(0f, centerValueY, 0f);
        Image image = spriteOb.AddComponent<Image>();

        image.sprite = sprites[i];
        image.SetNativeSize();
        image.name = image.sprite.name;
    }
}
