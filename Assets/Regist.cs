﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Regist : MonoBehaviour
{
    public Button button;

    void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        Application.OpenURL("http://vk.com/zhenyaxxo");
    }
}