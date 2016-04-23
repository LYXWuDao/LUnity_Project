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

    /// <summary>
    /// 导入侠客的数据
    /// </summary>
    /// <returns></returns>
    public static CLBaseDicData<int, CLHeroEntity> LoadHeroData()
    {
        string tableKey = "data_hero";
        object entitys = null;
        CLBaseDicData<int, CLHeroEntity> heroEntity = null;

        if (!_dataManage.TryFind(tableKey, out entitys))
        {
            CLJson uiData = FindGameData(tableKey);
            if (uiData == null) return null;

            heroEntity = new CLBaseDicData<int, CLHeroEntity>();
            for (int i = 0, len = uiData.Length; i < len; i++)
            {
                CLHeroEntity entity = uiData.GetValue<CLHeroEntity>(i);
                heroEntity.Add(entity.HeroId, entity);
            }
            _dataManage.Add(tableKey, heroEntity);
        }
        else
            heroEntity = (CLBaseDicData<int, CLHeroEntity>)entitys;
        return heroEntity;
    }


    /// <summary>
    /// 获得侠客数据
    /// </summary>
    /// <param name="id">侠客id</param>
    /// <returns></returns>
    public static CLHeroEntity GetHeroData(int heroId)
    {
        CLBaseDicData<int, CLHeroEntity> heroEntity = LoadHeroData();
        if (heroEntity == null) return null;
        return heroEntity.Contains(heroId) ? heroEntity.Find(heroId) : null;
    }

    /// <summary>
    /// 得到所有的侠客
    /// </summary>
    /// <returns></returns>
    public static List<CLHeroEntity> GetHeroAllList()
    {
        CLBaseDicData<int, CLHeroEntity> heroEntity = LoadHeroData();
        if (heroEntity == null) return new List<CLHeroEntity>();
        return heroEntity.FindAllValues();
    }
}

