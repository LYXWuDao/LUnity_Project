using LGame.LCommon;
using LGame.LUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CLUIHeroPanel : CLUIBehaviour
{
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

    private GameObject mRootNode = null;

    private List<CLHeroNodeEntity> mNodes = null;

    protected override void OnAwake()
    {

        mRootNode = SLToolsHelper.FindGameObject(gameObject, "content/grid");
        Transform transNode = mRootNode.transform;
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
    }

    protected override void OnCollider(GameObject btn)
    {
        if (btn == null) return;
        string btnName = btn.name;

        if (btnName == "close")
        {
            SLGameTools.CloseUI(ELUI.HeroPanel);
        }
    }

    protected override void OnClear()
    {
        mRootNode = null;
        if (mNodes != null) mNodes.Clear();
        mNodes = null;
    }

}

