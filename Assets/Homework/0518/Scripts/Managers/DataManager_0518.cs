using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager_0518 : MonoBehaviour
{
    [SerializeField] private int shootCount;

    public UnityEvent<int> OnShootCountChanged;
    public void AddShootCount(int count)
    {
        shootCount += count;
        OnShootCountChanged?.Invoke(shootCount);
    }

}
