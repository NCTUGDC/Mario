using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [SerializeField]
    private GameObject inventoryItemContent;
    [SerializeField]
    private GameObject inventoryItem;

    public List<ClassBase.InventoryItem> inventory = new List<ClassBase.InventoryItem>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        gameObject.SetActive(false);
    }

    void SaveInventoryStatus()
    {
//        print("write file");
//        string fileName;
//#if UNITY_ANDROID
//        fileName = Application.persistentDataPath + "/tmp.txt";
//#else
//        fileName = Application.dataPath + "/tmp.txt";
//#endif
//        File.WriteAllText(fileName, "");
    }

    private void OnEnable()
    {
        RenderInventory();
    }

    public void RenderInventory()
    {
        foreach(Transform item in inventoryItemContent.transform)
        {
            Destroy(item.gameObject);
        }

        foreach(ClassBase.InventoryItem item in inventory)
        {
            GameObject newItem = Instantiate(inventoryItem);
            newItem.transform.SetParent(inventoryItemContent.transform);
            newItem.transform.localScale = new Vector3(1, 1, 1);
            newItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemSprites/" + item.itemID);
        }
    }

    public void GetItem(int itemID)
    {
        inventory.Add(new ClassBase.InventoryItem(itemID));

        RenderInventory();
    }

    // For testing
    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.G))
    //    {
    //        print("get key");
    //        GetItem(1);
    //    }
    //}

}