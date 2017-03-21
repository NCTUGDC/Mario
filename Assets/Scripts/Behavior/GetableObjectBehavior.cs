using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetableObjectBehavior : MonoBehaviour
{
    public int itemID;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ItemSprites/" + itemID);
        gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        gameObject.AddComponent<BoxCollider2D>();
    }

    private void OnMouseDown()
    {
        InventoryManager.Instance.GetItem(itemID);

        Destroy(gameObject);
    }

}