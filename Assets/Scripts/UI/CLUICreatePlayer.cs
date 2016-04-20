using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LGame.LUI;
using UnityEngine;
using LGame.LCommon;
using LGame.LDebug;
using LGame.LUtils;

/// <summary>
/// 创建角色
/// 
/// 类型: 魏蜀吴群 =>  1, 2, 3, 4
/// 
/// </summary>
public class CLUICreatePlayer : CLUIBehaviour
{

    private class PersonTemplate
    {
        public GameObject obj;
        public Transform trans;
        public UISprite title;
        public UISprite icon;
    }

    private List<PersonTemplate> mPtemps = new List<PersonTemplate>();

    /// <summary>
    /// 当前选择的国家类型
    /// </summary>
    private int mSelectCountryType = 0;

    private UIInput mPlayerName = null;

    /// <summary>
    /// 灰色的颜色值
    /// </summary>
    private Color mGrayColor = new Color(115f / 255f, 115f / 255f, 115f / 255f);

    /// <summary>
    /// 亮色的颜色值
    /// </summary>
    private Color mBrightColor = new Color(255f / 255f, 255f / 255f, 255f / 255f);

    protected override void OnAwake()
    {
        Transform ptrans = SLToolsHelper.FindTransform(gameObject, "person");
        if (ptrans != null)
        {
            for (int i = 0, len = ptrans.childCount; i < len; i++)
            {
                PersonTemplate temp = new PersonTemplate();
                temp.trans = ptrans.GetChild(i);
                temp.obj = temp.trans.gameObject;
                temp.title = SLToolsHelper.GetComponent<UISprite>(temp.obj, "title");
                temp.icon = SLToolsHelper.GetComponent<UISprite>(temp.obj, "icon");
                mPtemps.Add(temp);
            }
        }

        mPlayerName = SLToolsHelper.GetComponent<UIInput>(gameObject, "content/nameinput/InputField");

        /// 默认选择魏国
        OnSelectCountry(1);
    }

    protected override void OnCollider(GameObject btn)
    {
        if (btn == null) return;
        switch (btn.name)
        {
            case "person_wei":
                OnSelectCountry(1);
                break;
            case "person_shu":
                OnSelectCountry(2);
                break;
            case "person_wu":
                OnSelectCountry(3);
                break;
            case "person_qun":
                OnSelectCountry(4);
                break;
            case "create_btn":
                // 创建游戏名字
                OnCreatePlayer();
                break;
            case "dice":
                // todo: 随机名字
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 选择国家
    /// 
    /// 魏蜀吴群 =>  1, 2, 3, 4
    /// </summary>
    /// <param name="index">选择国家的类型</param>
    public void OnSelectCountry(int index)
    {
        if (mPtemps == null || mPtemps.Count <= 0) return;
        if (index <= 0 || index > 4)
        {
            SLConsole.WriteError("创建的国家不合法!!!");
            return;
        }
        mSelectCountryType = index;
        for (int i = 0, len = mPtemps.Count; i < len; i++)
        {
            PersonTemplate temp = mPtemps[i];
            if (i + 1 == index)
            {
                //CLTweenEvent.BeginColorImmediate(temp.title.gameObject, 0.3f, temp.title.color, mBrightColor);
                //CLTweenEvent.BeginColorImmediate(temp.icon.gameObject, 0.3f, temp.icon.color, mBrightColor);
                //CLTweenEvent.BeginScale(temp.obj, 0.2f, temp.trans.localScale, Vector3.one * 1.4f);
                //CLTweenEvent.BeginScaleImmediate(temp.obj, 0.2f, Vector3.one * 1.4f, Vector3.one * 1.2f);
            }
            else
            {
                //CLTweenEvent.BeginTweener();
                //CLTweenEvent.BeginScaleImmediate(temp.obj, 0.2f, temp.trans.localScale, Vector3.one);
                //CLTweenEvent.BeginColorImmediate(temp.title.gameObject, 0.2f, temp.title.color, mGrayColor);
                //CLTweenEvent.BeginColorImmediate(temp.icon.gameObject, 0.2f, temp.icon.color, mGrayColor);
            }
        }
    }

    /// <summary>
    /// 确定创建角色
    /// </summary>
    public void OnCreatePlayer()
    {
        if (mPlayerName == null) return;
        if (mSelectCountryType <= 0 || mSelectCountryType > 4)
        {
            SLConsole.WriteError("创建的国家不合法!!!");
            return;
        }

        if (string.IsNullOrEmpty(mPlayerName.value))
        {
            SLConsole.WriteError("游戏名字不能为空!!!");
            return;
        }


    }

}