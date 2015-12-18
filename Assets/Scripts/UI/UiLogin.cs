﻿using System;
using System.Collections.Generic;
using LGame.LBehaviour;
using LGame.LCommon;
using LGame.LDebug;
using LGame.LEvent;
using LGame.LUI;
using LGame.LUtils;
using UnityEngine;


/***
 * 
 * 登陆界面
 * 
 */

public sealed class UiLogin : LAUIBehaviour
{
    /// <summary>
    /// 进入按钮
    /// </summary>
    [NonSerialized]
    public GameObject mEnterBtn = null;

    public override void OnAwake()
    {
        mEnterBtn = LCSCompHelper.FindGameObject(gameObject, "content/enter_btn");
    }

    public override void OnStart()
    {
        CLTweenEvent.BeginScale(mEnterBtn, 0.5f, new Vector3(0.5f, 0.5f, 0.5f), Vector3.one);
    }

    /// <summary>
    /// 清理数据
    /// </summary>
    public override void OnClear()
    {
        mEnterBtn = null;
    }

    /// <summary>
    /// 鼠标单击
    /// </summary>
    /// <param name="btn"></param>
    public override void OnCollider(GameObject btn)
    {
        if (btn == null) return;
        SLDebugHelper.WriteError(btn.name);
    }

}

