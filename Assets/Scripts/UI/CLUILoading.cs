using LGame.LUI;
using LGame.LCommon;
using LGame.LDebug;
using System;
using LGame.LUtils;

/// <summary>
/// 过场景的界面
/// </summary>
public sealed class CLUILoading : CLUIBehaviour
{
    /// <summary>
    /// 保留当前资源加载的实体用于显示进度
    /// </summary>
    private LoadSourceEntity mEntity;

    /// <summary>
    /// 进度显示完成后回调
    /// </summary>
    private Action mFinish = null;

    /// <summary>
    /// 开始进度
    /// </summary>
    private bool mIsStart = false;

    /// <summary>
    /// 进度
    /// </summary>
    private UISlider mSlider = null;

    public override void OnAwake()
    {
        mSlider = SLCompHelper.FindComponet<UISlider>(gameObject, "content/progress");
        mSlider.value = 0;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="entity">资源加载实体类</param>
    /// <param name="finish">完成的回调</param>
    public void InitLoading(LoadSourceEntity entity, Action finish = null)
    {
        mFinish = finish;
        mEntity = entity;
        mIsStart = entity != null;
    }

    /// <summary>
    /// 更新进度条
    /// </summary>
    /// <param name="deltaTime"></param>
    public override void OnUpdate(float deltaTime)
    {
        if (!mIsStart || mSlider == null) return;
        // 加载完成
        if (mSlider.value >= 1)
        {
            mIsStart = false;

            CLDelayAction.BeginAction(0.3f, delegate ()
            {
                if (mFinish != null) mFinish();
                mFinish = null;
            });
        }

        mSlider.value = mEntity.Progress;
    }
}