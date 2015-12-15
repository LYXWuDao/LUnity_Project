using System;
using System.Collections.Generic;
using LGame.LJson;
using LGame.LUI;


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
        LCSUIManage.OpenWindow(entity.WinName, entity.WinPath, entity.WinScript);
    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    public static void CloseUI(ELUI ui)
    {
        CLUIEntity entity = SLGameData.GetUiData((int)ui);
        if (entity == null) return;
        LCSUIManage.CloseWindow(entity.WinName);
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
            LCSUIManage.RefreshWindow(string.Empty);
            return;
        }
        // 刷新某个界面
        CLUIEntity entity = SLGameData.GetUiData(uId);
        if (entity == null) return;
        LCSUIManage.RefreshWindow(entity.WinName);
    }

}

