using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 测试场景
/// 鼠标按下一直调用模板
/// </summary>
public class Scroll : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IPointerClickHandler
{
    /// <summary>
    /// 定义枚举
    /// </summary>
    public enum DirectionType
    {
        None = 0,
        ToUp,
        ToDown
    }
    public DirectionType Direction;

    private int dir
    {
        get
        {
            switch (Direction)
            {
                case DirectionType.None:
                    return 0;

                case DirectionType.ToUp:
                    return 1;

                case DirectionType.ToDown:
                    return -1;
                default:
                    Debug.LogError("方向类型为none!");
                    return 0;
            }
        }
    }
            /// <summary>
            /// 需移动的物体
            /// </summary>
            public Scrollbar TargetScrollBar;

    //点击类型-长
    //Click type - Long
    /// <summary>
    /// 速度
    /// </summary>
    [Range(0f, 1f)] public float Speed;
    /// <summary>
    /// 前进
    /// </summary>
    private float progress = 0f;

    //Click type - Once
    public float ScrollViewHeight;
    public float ContentHeight;
    /// <summary>
    /// 前进的长度（）
    /// </summary>
    private float progressLength { get { return ContentHeight - ScrollViewHeight; } }

    /// <summary>
    /// 点击类型枚举
    /// </summary>
    enum ClickType
    {
        Once,
        Long
    }

    /// <summary>
    /// 改变栏的值
    /// 的方法
    /// </summary>
    /// <param name="clickType">点击类型</param>
    void ChangeBarValueByBtn(ClickType clickType)
    {
        progress = TargetScrollBar.value;

        if (clickType == ClickType.Long)
            progress += Speed * dir * Time.deltaTime;
        else if (clickType == ClickType.Once)
            progress += ScrollViewHeight / progressLength * dir;

        progress = Mathf.Clamp01(progress);
        TargetScrollBar.value = progress;
    }

    /// <summary>
    /// 是否按下鼠标
    /// </summary>
    private bool isDown = false;

    /// <summary>
    /// 事件触发命名空间（EventSystems）
    /// 里面的OnPointerDown（EventSystems.PointerEventData eventData）
    ///     在指针按下时（参数：当前事件数据）
    /// </summary>
    /// <param name="eventData">当前事件数据</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
    }

    /// <summary>
    /// 持续按下按钮时间
    /// </summary>
    private float lastUpBtnTime = 0f;
    /// <summary>
    /// 延迟时间
    /// </summary>
    [Range(0f, 1f)] public float DelayTime;

    /// <summary>
    /// 事件触发命名空间
    ///     在指针点击时
    /// </summary>
    /// <param name="eventData">当前事件数据</param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.time - lastUpBtnTime <= DelayTime)
        {
            ChangeBarValueByBtn(ClickType.Once);
        }
    }

    void Update()
    {
        if (isDown)
        {
            if (Time.time - lastUpBtnTime > DelayTime)
            {
                ChangeBarValueByBtn(ClickType.Long);
            }
        }
        else
        {
            lastUpBtnTime = Time.time;
        }
    }

}
