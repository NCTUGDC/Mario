using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public enum UIPageType
    {
        Inventory = 0
    }

    [SerializeField]
    private GameObject[] UIPageList;

    private IEnumerator ableToOpenUIPage;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        ableToOpenUIPage = ShowPageInput();
    }
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        ChangeAbleToOpenUIPage(true);
    //    }
    //}
    private void Start()
    {
        StartCoroutine(ableToOpenUIPage);
    }

    public void ChangeAbleToOpenUIPage(bool isAble)
    {
        StopCoroutine(ableToOpenUIPage);

        if (isAble)
            StartCoroutine(ableToOpenUIPage);
    }

    IEnumerator ShowPageInput()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                UIPageList[(int)UIPageType.Inventory].SetActive(!UIPageList[(int)UIPageType.Inventory].activeInHierarchy);
            }

            yield return null;
        }
    }

}
