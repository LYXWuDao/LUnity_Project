using System;
using System.Collections.Generic;

/**
 * 
 * 
 * 场景实体信息类
 * 
 * 
 */

public class CLWorldEntity
{

    /// <summary>
    /// id 
    /// </summary>
    public int Id = 0;

    /// <summary>
    /// 场景名字
    /// 
    /// 例如： wCreatePlayer （不需要后缀）
    /// 
    /// </summary>
    public string SceneName = string.Empty;

    /// <summary>
    /// 场景加载路径
    /// 
    /// 例如： Scenes/wCreatePlayer.data
    ///
    /// </summary>
    public string ScenePath = string.Empty;

    /// <summary>
    /// 场景加载脚本
    /// </summary>
    public string SceneScript = string.Empty;

    /// <summary>
    /// 场景加载完成后打开的界面id
    /// 
    /// 与ui 管理表对应
    /// 
    /// </summary>
    public int SceneUiId = 0;

}

