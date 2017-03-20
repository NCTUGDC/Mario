using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
//        print("write file");

//        string fileName;
//#if UNITY_ANDROID
//        fileName = Application.persistentDataPath + "/tmp.txt";
//#else
//        fileName = Application.dataPath + "/tmp.txt";
//#endif
//        File.WriteAllText(fileName, "lalala aaaaaaaaaaaaa" );
    }

}