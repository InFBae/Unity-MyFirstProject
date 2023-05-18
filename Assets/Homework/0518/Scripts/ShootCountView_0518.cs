using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ShootCountView_0518 : MonoBehaviour
{
    TMP_Text textView;

    private void Awake()
    {
        textView = GetComponent<TMP_Text>();
    }

    public void ChangeText(int count)
    {
        textView.text = count.ToString();
    }

    private void OnEnable()
    {
        GameManager_0518.Data.OnShootCountChanged.AddListener(ChangeText);
    }
    private void OnDisable()
    {
        GameManager_0518.Data.OnShootCountChanged.RemoveListener(ChangeText);
    }
}
