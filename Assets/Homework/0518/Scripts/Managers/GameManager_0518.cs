using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_0518 : MonoBehaviour
{
    private static GameManager_0518 instance;
    private static DataManager_0518 dataManager;
    public static GameManager_0518 Instance { get { return instance; } }
    public static DataManager_0518 Data { get { return dataManager; } }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
        InitManagers();
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    private void InitManagers()
    {
        // DataManager Init
        GameObject dataObj = new GameObject() { name = "DataManager_0518" };
        dataObj.transform.SetParent(transform);
        dataManager = dataObj.AddComponent<DataManager_0518>();
    }
}

