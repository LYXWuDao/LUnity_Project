using LGame.LBehaviour;
using LGame.LCommon;
using LGame.LUI;
using UnityEngine;
using System.Collections;

/***
 * 
 * 游戏入口
 * 
 */

public class GameApp : LABehaviour
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
        // 创建所有界面的根节点
        GameObject root = LCSCompHelper.Create("_ui root", uiCamera.transform);

        // 加载各种资源
        LCSUIManage.OpenWindow("uiLogin", "UI/uiLogin.data");

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
