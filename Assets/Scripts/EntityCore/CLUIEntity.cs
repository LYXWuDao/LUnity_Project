using System;
using System.Collections.Generic;


/****
 * 
 * ui  实体类
 * 
 */

public class CLUIEntity
{

    /// <summary>
    /// 界面id 
    /// </summary>
    public int Id = 0;

    /// <summary>
    /// 界面名字
    /// 
    /// 例如： uiLogin
    /// 
    /// </summary>
    public string WinName = string.Empty;

    /// <summary>
    /// 界面路径
    /// 
    /// 例如： UI/uiLogin.data
    /// 
    /// </summary>
    public string WinPath = string.Empty;

    /// <summary>
    /// 脚本名字
    /// 
    /// 例如：UiLogin
    /// 
    /// </summary>
    public string WinScript = string.Empty;

}

