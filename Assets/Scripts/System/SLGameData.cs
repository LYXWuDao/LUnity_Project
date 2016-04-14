using System;
using System.Collections.Generic;
using LGame.LCommon;
using LGame.LJson;
using LGame.LSource;

/*****
 * 
 *  数据处理 
 * 
 */

public sealed class SLGameData
{

    private static CLBaseDicData<string, object> _dataManage = new CLBaseDicData<string, object>();

    /// <summary>
    /// 查找保存的数据
    /// 
    /// 直接加载表，没有打包
    /// 
    /// </summary>
    /// <param name="tableName">数据表的名字</param>
    public static CLJson FindGameData(string tableName)
    {
        LoadSourceEntity entity = SLManageSource.LoadTextSource(tableName, "Data/" + tableName + ".txt");
        if (entity == null) return null;
        string json = entity.TextContent;
        if (string.IsNullOrEmpty(json)) return null;
        return new CLJson(json);
    }

    /// <summary>
    /// 得到ui界面数据
    /// </summary>
    /// <param name="id">ui 界面id</param>
    /// <returns></returns>
    public static CLUIEntity GetUiData(int id)
    {
        string tableKey = "data_ui";
        object entitys;
        Dictionary<int, CLUIEntity> uiEntity = null;

        if (!_dataManage.TryFind(tableKey, out entitys))
        {
            CLJson uiData = FindGameData(tableKey);
            if (uiData == null) return null;

            uiEntity = new Dictionary<int, CLUIEntity>();
            for (int i = 0, len = uiData.Length; i < len; i++)
            {
                CLUIEntity entity = uiData.GetValue<CLUIEntity>(i);
                uiEntity.Add(entity.Id, entity);
            }
            _dataManage.Add(tableKey, uiEntity);
        }
        else
            uiEntity = (Dictionary<int, CLUIEntity>)entitys;
        return uiEntity.ContainsKey(id) ? uiEntity[id] : null;
    }

    /// <summary>
    /// 得到场景的数据
    /// </summary>
    /// <param name="id">场景id</param>
    /// <returns></returns>
    public static CLWorldEntity GetWorldData(int id)
    {
        string tableKey = "data_world";
        object entitys = null;
        Dictionary<int, CLWorldEntity> worldEntity = null;

        if (!_dataManage.TryFind(tableKey, out entitys))
        {
            CLJson uiData = FindGameData(tableKey);
            if (uiData == null) return null;

            worldEntity = new Dictionary<int, CLWorldEntity>();
            for (int i = 0, len = uiData.Length; i < len; i++)
            {
                CLWorldEntity entity = uiData.GetValue<CLWorldEntity>(i);
                worldEntity.Add(entity.Id, entity);
            }
            _dataManage.Add(tableKey, worldEntity);
        }
        else
            worldEntity = (Dictionary<int, CLWorldEntity>)entitys;

        return worldEntity.ContainsKey(id) ? worldEntity[id] : null;
    }

}

