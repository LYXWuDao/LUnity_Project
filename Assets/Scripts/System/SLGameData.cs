using System;
using System.Collections.Generic;
/*****
 * 
 *  数据处理 
 * 
 */
using LGame.LJson;

public sealed class SLGameData
{

    /// <summary>
    /// 得到ui界面数据
    /// </summary>
    /// <param name="id">ui 界面id</param>
    /// <returns></returns>
    public static CLUIEntity GetUiData(int id)
    {
        LCJson uiData = SLGameDataManage.FindGameData("data_ui");
        if (uiData == null) return null;
        for (int i = 0, len = uiData.Length; i < len; i++)
        {
            CLUIEntity entity = uiData.GetValue<CLUIEntity>(i);
            if (entity.Id == id) return entity;
        }
        return null;
    }

}

