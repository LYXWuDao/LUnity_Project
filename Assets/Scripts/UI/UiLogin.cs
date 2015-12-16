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

public sealed class UiLogin : LAUIBehaviour
{

    public override void Awake()
    {

    }

    public override void Start()
    {
        GameObject enter = LCSCompHelper.FindGameObject(gameObject, "content/enter_btn");

        CLTweenEvent.BeginScale(enter, 10, Vector3.zero, Vector3.one);
        CLTweenEvent.BeginScale(enter, 10, Vector3.zero, Vector3.one);
    }

    public override void OnUpdate(float deltaTime)
    {

    }

}

