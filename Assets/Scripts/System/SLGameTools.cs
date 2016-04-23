using System;
using System.Collections.Generic;
using LGame.LDebug;
using LGame.LJson;
using LGame.LScenes;
using LGame.LUI;
using LGame.LCommon;


/*****
 * 
 * 游戏使用工具类
 * 
 */

public sealed class SLGameTools
{

    /// <summary>
    /// 打开界面
    /// </summary>
    public static void OpenUI(ELUI ui)
    {
        CLUIEntity entity = SLGameData.GetUiData((int)ui);
        if (entity == null) return;
        SLUIManage.OpenWindow(entity.WinName, entity.WinPath, entity.WinScript);
    }

    /// <summary>
    /// 发现界面
    /// </summary>
    /// <param name="ui"></param>
    public static CLUIBehaviour FindUI(ELUI ui)
    {
        CLUIEntity entity = SLGameData.GetUiData((int)ui);
        if (entity == null) return null;
        return SLUIManage.FindWindow(entity.WinName);
    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    public static void CloseUI(ELUI ui)
    {
        CLUIEntity entity = SLGameData.GetUiData((int)ui);
        if (entity == null) return;
        SLUIManage.CloseWindow(entity.WinName);
    }

    /// <summary>
    /// 刷新ui 界面
    /// </summary>
    /// <param name="ui"></param>
    public static void RefreshUI(ELUI ui)
    {
        int uId = (int)ui;
        if (uId <= 0)
        {
            // 刷新当前打开的所有界面
            SLUIManage.RefreshWindow(string.Empty);
            return;
        }
        // 刷新某个界面
        CLUIEntity entity = SLGameData.GetUiData(uId);
        if (entity == null) return;
        SLUIManage.RefreshWindow(entity.WinName);
    }

    /// <summary>
    /// 跳转场景
    /// </summary>
    public static void OpenToWorld(ELWorld world)
    {
        CLWorldEntity entity = SLGameData.GetWorldData((int)world);
        if (entity == null)
        {
            SLConsole.WriteError("场景数据不存在， id = " + world);
            return;
        }

        if (SLScenesManage.VerifyOpenScene(entity.SceneName))
        {
            SLConsole.WriteError("你在试图打开同一个场景!! SceneName = " + entity.SceneName);
            return;
        }

        SLUIManage.CloseAllWindow();

        // 开始跳转场景
        LoadSourceEntity loadEntity = SLScenesManage.AsyncOpenToScenes(entity.SceneName, entity.ScenePath, entity.SceneScript);

        // 打开跳转界面
        OpenUI(ELUI.Loading);
        CLUILoading loading = FindUI(ELUI.Loading) as CLUILoading;
        if (loading != null) loading.InitLoading(loadEntity, delegate ()
        {
            CloseUI(ELUI.Loading);
            // 场景打开后，加载的界面
            OpenUI((ELUI)entity.SceneUiId);
        });
    }

    /// <summary>
    /// 得到品质框名字
    /// </summary>
    /// <param name="qual"></param>
    public static string ToQualitySprite(int qual)
    {
        string result = "物品框白色";
        switch (qual)
        {
            case 2:
                result = "物品框紫色";
                break;
            case 3:
                result = "物品框橙色";
                break;
        }
        return result;
    }

    /// <summary>
    /// 得到品质的颜色
    /// </summary>
    /// <param name="qual"></param>
    /// <returns></returns>
    public static string ToQualityColor(int qual)
    {
        string result = "[ffffff]";
        switch (qual)
        {
            case 2:
                result = "[ff00ff]";
                break;
            case 3:
                result = "[ffa400]";
                break;
        }
        return result;
    }

}

