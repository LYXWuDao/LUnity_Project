﻿using System;
using LGame.LCommon;
using LGame.LEvent;
using LGame.LUI;
using LGame.LUtils;
using UnityEngine;


/***
 * 
 * 登陆界面
 * 
 */

public sealed class CLUILogin : CLUIBehaviour
{
    /// <summary>
    /// 进入按钮
    /// </summary>
    [NonSerialized]
    public GameObject mEnterBtn = null;

    /// <summary>
    /// 游戏标题
    /// </summary>
    [NonSerialized]
    public GameObject mTitle = null;

    /// <summary>
    /// 服务器区
    /// </summary>
    [NonSerialized]
    public GameObject mArean = null;

    protected override void OnAwake()
    {
        mEnterBtn = SLToolsHelper.FindGameObject(gameObject, "content/enter_btn");
        mTitle = SLToolsHelper.FindGameObject(gameObject, "bg/title");
        mArean = SLToolsHelper.FindGameObject(gameObject, "content/arean");

        mEnterBtn.SetActive(false);
        mTitle.SetActive(false);
        mArean.SetActive(false);
    }

    protected override void OnStart()
    {
        CLDelayAction.BeginAction(1.2f, delegate ()
        {
            CLSerialTween.BeginScale(mTitle, 0.7f, Vector3.one * 0.5f, Vector3.one * 1.2f);
            CLSerialTween.BeginScale(mTitle, 0.15f, Vector3.one * 1.2f, Vector3.one);

            CLParallelTween.BeginScale(mArean, 0.6f, Vector3.one * 0.5f, Vector3.one);
            CLParallelTween.BeginScale(mEnterBtn, 0.8f, Vector3.one * 0.5f, Vector3.one);

            CLDelayAction.BeginAction(1.3f, delegate ()
            {
                // 增加按钮缩放效果
                SLToolsHelper.FindComponet<UIButtonScale>(mArean);
                SLToolsHelper.FindComponet<UIButtonScale>(mEnterBtn);
            });
        });
    }

    /// <summary>
    /// 清理数据
    /// </summary>
    protected override void OnClear()
    {
        mEnterBtn = null;
    }

    /// <summary>
    /// 鼠标单击
    /// </summary>
    /// <param name="btn">点击的按钮</param>
    protected override void OnCollider(GameObject btn)
    {
        if (btn == null) return;
        string btnName = btn.name;
        if (btnName == "enter_btn")
        {
            SLGameTools.OpenToWorld(ELWorld.MajorCity);
        }
    }

}

