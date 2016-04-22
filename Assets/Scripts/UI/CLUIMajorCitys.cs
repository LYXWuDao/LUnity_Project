﻿using LGame.LUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 主界面
/// </summary>
public class CLUIMajorCitys : CLUIBehaviour
{

    protected override void OnAwake()
    {

    }

    protected override void OnClear()
    {

    }

    protected override void OnCollider(GameObject btn)
    {
        if (btn == null) return;
        string btnName = btn.name;

        switch (btnName)
        {
            case "junying":
                SLGameTools.OpenUI(ELUI.HeroPanel);
                break;
            case "buzhen":
                break;
            case "fuben":
                break;
        }
    }

}

