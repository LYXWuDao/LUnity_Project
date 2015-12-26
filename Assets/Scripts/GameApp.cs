﻿using LGame.LBehaviour;
using LGame.LCommon;
using LGame.LUI;
using UnityEngine;
using System.Collections;

/***
 * 
 * 游戏入口
 * 
 */

public class GameApp : ALBehaviour
{

    /// <summary>
    /// 初始化游戏
    /// </summary>
    public override void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // 创建2d ui 相机
        UIPanel panel = NGUITools.CreateUI(false);
        UIRoot uiRoot = panel.GetComponent<UIRoot>();
        uiRoot.scalingStyle = UIRoot.Scaling.Constrained;
        // 找到创建的 ui 相机
        UICamera uiCamera = uiRoot.GetComponentInChildren<UICamera>();
        if (uiCamera == null) return;
        SLUIManage.UIMainCamera = uiCamera;
        // 创建所有界面的根节点
        GameObject root = SLCompHelper.Create("_ui root", uiCamera.transform);
        if (root == null) return;
        SLUIManage.UIRoot = root.transform;
        // 加载各种资源



        // 资源加载完毕打开登陆界面
        SLGameTools.OpenUI(ELUI.Login);
    }

    // Use this for initialization
    public override void Start()
    {

    }

    // Update is called once per frame
    public override void OnUpdate(float deltaTime)
    {

    }

}
