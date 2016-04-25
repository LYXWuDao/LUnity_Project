using LGame.LCommon;
using LGame.LUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CLUIHeroPanel : CLUIBehaviour
{
    /// <summary>
    /// 英雄的实体
    /// </summary>
    private class CLHeroNodeEntity
    {
        public Transform mTrans = null;
        public GameObject mObj = null;
        public UILabel mHeroName = null;
        public UILabel mHeroLevel = null;
        public UISprite mHeroIcon = null;
        public UISprite mHeroQuality = null;
        public UISlider mHeroSlider = null;
        public GameObject mStarObj = null;
        public List<GameObject> mHeroStar = new List<GameObject>();
    }

    /// <summary>
    /// 半身像的实体
    /// </summary>
    private class CLHeroBustEntity
    {
        public GameObject mObj = null;
        public Transform mTrans = null;
        public UILabel mHeroName = null;
        public UISprite mHeroBust = null;
        public GameObject mStarObj = null;
        public UIGrid mStarGrid = null;
        public List<GameObject> mHeroStar = new List<GameObject>();
    }

    /// <summary>
    /// 所有英雄的节点
    /// </summary>
    private GameObject mGridNode = null;

    private List<CLHeroNodeEntity> mNodes = null;

    private CLHeroBustEntity mBustNodes = null;

    protected override void OnAwake()
    {

        mGridNode = SLToolsHelper.FindGameObject(gameObject, "content/right/heroList/grid");
        Transform transNode = mGridNode.transform;
        mNodes = new List<CLHeroNodeEntity>();

        for (int i = 0, len = transNode.childCount; i < len; i++)
        {
            CLHeroNodeEntity entity = new CLHeroNodeEntity();
            entity.mTrans = transNode.GetChild(i);
            entity.mObj = entity.mTrans.gameObject;
            entity.mHeroName = SLToolsHelper.FindComponet<UILabel>(entity.mObj, "heroName");
            entity.mHeroLevel = SLToolsHelper.FindComponet<UILabel>(entity.mObj, "lvbg/lv");
            entity.mHeroIcon = SLToolsHelper.FindComponet<UISprite>(entity.mObj, "icon");
            entity.mHeroQuality = SLToolsHelper.FindComponet<UISprite>(entity.mObj, "quality");
            entity.mStarObj = SLToolsHelper.FindGameObject(entity.mObj, "star");

            for (int j = 0, jLen = entity.mStarObj.transform.childCount; j < jLen; j++)
            {
                GameObject starSpr = entity.mStarObj.transform.GetChild(j).gameObject;
                entity.mHeroStar.Add(starSpr);
            }

            mNodes.Add(entity);
        }

        mBustNodes = new CLHeroBustEntity();
        mBustNodes.mObj = SLToolsHelper.FindGameObject(gameObject, "content/left");
        mBustNodes.mTrans = mBustNodes.mObj.transform;
        mBustNodes.mHeroName = SLToolsHelper.FindComponet<UILabel>(mBustNodes.mObj, "heroName"); ;
        mBustNodes.mHeroBust = SLToolsHelper.FindComponet<UISprite>(mBustNodes.mObj, "bust"); ;
        mBustNodes.mStarObj = SLToolsHelper.FindGameObject(mBustNodes.mObj, "bustStar");
        mBustNodes.mStarGrid = mBustNodes.mStarObj.GetComponent<UIGrid>();

        for (int j = 0, jLen = mBustNodes.mStarObj.transform.childCount; j < jLen; j++)
        {
            GameObject starSpr = mBustNodes.mStarObj.transform.GetChild(j).gameObject;
            mBustNodes.mHeroStar.Add(starSpr);
        }

        OnRefresh();
    }

    protected override void OnStart()
    {

    }

    public override void OnRefresh()
    {
        if (mNodes == null) return;

        List<CLHeroEntity> mHeroList = SLGameData.GetHeroAllList();
        int mHeroLen = mHeroList.Count;

        for (int i = 0, len = mNodes.Count; i < len; i++)
        {
            CLHeroNodeEntity tempNode = mNodes[i];

            if (i >= mHeroLen)
            {

            }
            else
            {
                CLHeroEntity tempData = mHeroList[i];
                tempNode.mObj.name = tempData.HeroId.ToString();
                tempNode.mHeroIcon.spriteName = tempData.HeroHead;
                tempNode.mHeroName.text = string.Format("{0}{1}", SLGameTools.ToQualityColor(tempData.HeroQuality), tempData.HeroName);
                tempNode.mHeroQuality.spriteName = SLGameTools.ToQualitySprite(tempData.HeroQuality);
                tempNode.mHeroLevel.text = string.Format("{0}{1}级", SLGameTools.ToQualityColor(tempData.HeroQuality), tempData.HeroLevel);
                int star = tempData.HeroStar;

                for (int j = 0, jLen = tempNode.mHeroStar.Count; j < jLen; j++)
                {
                    tempNode.mHeroStar[j].SetActive(j < star);
                }
            }
        }

        OnShowHeroBustInfo(mHeroList[0]);
    }

    /// <summary>
    /// 显示当前选中的英雄半身像
    /// </summary>
    /// <param name="entity"></param>
    public void OnShowHeroBustInfo(CLHeroEntity entity)
    {
        if (entity == null || mBustNodes == null) return;

        mBustNodes.mHeroName.text = string.Format("{0}{1}", SLGameTools.ToQualityColor(entity.HeroQuality), entity.HeroName);
        mBustNodes.mHeroBust.spriteName = entity.HeroBust;
        int star = entity.HeroStar;
        for (int j = 0, jLen = mBustNodes.mHeroStar.Count; j < jLen; j++)
        {
            mBustNodes.mHeroStar[j].SetActive(j < star);
        }
        mBustNodes.mStarGrid.enabled = true;
    }

    protected override void OnCollider(GameObject btn)
    {
        if (btn == null) return;
        string btnName = btn.name;

        switch (btnName)
        {
            case "close":
                SLGameTools.CloseUI(ELUI.HeroPanel);
                break;
            case "bg":
                int heroId = Convert.ToInt32(btn.transform.parent.name);
                CLHeroEntity entity = SLGameData.GetHeroData(heroId);
                OnShowHeroBustInfo(entity);
                break;
        }
    }

    protected override void OnClear()
    {
        mGridNode = null;
        if (mNodes != null) mNodes.Clear();
        mNodes = null;
        mBustNodes = null;
    }

}

