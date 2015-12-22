using System;
using System.Collections.Generic;
using LGame.LBase;
using LGame.LCommon;
using LGame.LJson;
using LGame.LSource;

/***
 * 
 * 
 * 数据管理
 * 
 * 管理游戏所有的数据表
 * 
 */

public sealed class SLGameDataManage : ATLManager<CLJson>
{

    /// <summary>
    /// 查找保存的数据
    /// 
    /// 直接加载表，没有打包
    /// 
    /// </summary>
    /// <param name="tableName">数据表的名字</param>
    public static CLJson FindGameData(string tableName)
    {
        CLJson data = Find<SLGameDataManage>(tableName);
        if (data != null) return data;
        LoadSourceEntity entity = SLManageSource.LoadTextSource(tableName, "Data/" + tableName + ".txt");
        if (entity == null) return null;
        string json = entity.TextContent;
        if (string.IsNullOrEmpty(json)) return null;
        data = new CLJson(json);
        Add<SLGameDataManage>(tableName, data);
        return data;
    }

}
