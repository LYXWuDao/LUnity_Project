using System;
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

    public override void OnAwake()
    {
        mEnterBtn = SLCompHelper.FindGameObject(gameObject, "content/enter_btn");
        mTitle = SLCompHelper.FindGameObject(gameObject, "bg/title");
        mArean = SLCompHelper.FindGameObject(gameObject, "content/arean");

        mEnterBtn.SetActive(false);
        mTitle.SetActive(false);
        mArean.SetActive(false);
    }

    public override void OnStart()
    {
        CLDelayAction.BeginAction(1f, delegate()
        {
            CLTweenEvent.BeginScale(mTitle, 0.7f, new Vector3(0.5f, 0.5f, 0.5f), Vector3.one * 1.1f);
            CLTweenEvent.BeginScaleImmediate(mTitle, 0.3f, Vector3.one * 1.1f, Vector3.one);

            CLTweenEvent.BeginScaleImmediate(mArean, 0.35f, Vector3.one * 0.5f, Vector3.one);
            CLTweenEvent.BeginScale(mEnterBtn, 0.5f, Vector3.one * 0.5f, Vector3.one);

            CLDelayAction.BeginAction(1.3f, delegate()
            {
                SLCompHelper.FindComponet<UIButtonScale>(mArean);
                SLCompHelper.FindComponet<UIButtonScale>(mEnterBtn);
            });
        });
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
    /// <param name="btn">点击的按钮</param>
    public override void OnCollider(GameObject btn)
    {
        if (btn == null) return;
        string btnName = btn.name;
        if (btnName == "enter_btn")
        {
            SLGameTools.OpenToWorld(ELWorld.CreatePlayer);
        }
    }

}

