using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 鼠标按下持续类
/// </summary>
public class MouseDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IPointerClickHandler
{
    public DirectionType direction;
    public ApparatusType apparatus;

    private int Number
    {
        get
        {
            switch (direction)
            {
                case DirectionType.none:
                    return 0;
                case DirectionType.ToUp:
                    return 1;
                case DirectionType.ToDown:
                    return -1;
                default:
                    Debug.Log("方向类型为none!");
                    return 0;
            }
        }
    }
    int number;

    #region MyRegion
    ////点击类型-长
    ////Click type - Long
    ///// <summary>
    ///// 速度
    ///// </summary>
    //public float speed;

    ///// <summary>
    ///// 百分比数值
    ///// </summary>
    //[Range(0f, 1f)] public float progressValue;

    ////Click type - Once
    ///// <summary>
    ///// 物体长度
    ///// </summary>
    //public float TheLengthOfTheObject;
    ///// <summary>
    ///// 运动总长度
    ///// </summary>
    //public float TotalLengthOfMotion;

    ///// <summary>
    ///// 前进的长度
    ///// </summary>
    //private float ProgressLength
    //{
    //    get { return TotalLengthOfMotion - TheLengthOfTheObject; }
    //}

    ///// <summary>
    ///// 点击类型枚举
    ///// </summary>
    //enum ClickType
    //{
    //    Once,
    //    Long
    //}

    //void ChangeBarValueByBtn(ClickType clickType)
    //{
    //    if (clickType == ClickType.Long)
    //    {

    //    }
    //}
    #endregion
    
    

    /// <summary>
    /// 点击类型枚举
    /// </summary>
    enum ClickType
    {
        Once,
        Long
    }

    void OnClick(ApparatusType apparatusType,ClickType clickType)
    {
        if (apparatusType == ApparatusType.M7130)
        {
            if (clickType == ClickType.Long)
            {
                M71310Command._instance.MoveTo_Toing(number);
            }
            else if (clickType == ClickType.Once)
            {
                M71310Command._instance.MoveTo_Toing(number);
            }
        }
        else if (apparatusType == ApparatusType.T68)
        {
            //if (clickType == ClickType.Long)
            //{
            //    M71310Command._instance.MoveTo_Toing(number);
            //}
            //else if (clickType == ClickType.Once)
            //{
            //    M71310Command._instance.MoveTo_Toing(number);
            //}
        }
        
    }

    /// <summary>
    /// 是否按下鼠标
    /// </summary>
    bool isDown = false;

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
            OnClick(apparatus, ClickType.Once);
        }
    }



    void Update()
    {
        if (M71310Command._instance.isDownStop)
        {
            number = Mathf.Abs(Number);
        }
        else if (M71310Command._instance.isUpStop)
        {
            number = (Mathf.Abs(Number)) * -1;
        }
        else
        {
            number = Number;
        }
        if (isDown)
        {
            if (Time.time - lastUpBtnTime > DelayTime)
            {
                OnClick(apparatus, ClickType.Long);
            }
        }
        else
        {
            lastUpBtnTime = Time.time;
        }
    }

    /// <summary>
    /// 枚举
    /// 方向类型
    /// </summary>
    public enum DirectionType
    {
        /// <summary>
        /// 无
        /// </summary>
        none=0,
        /// <summary>
        /// 向上
        /// </summary>
        ToUp,
        /// <summary>
        /// 向下
        /// </summary>
        ToDown
    }

    /// <summary>
    /// 枚举
    /// 机器类型
    /// </summary>
    public enum ApparatusType
    {
        none=0,
        M7130,
        T68
    }
}
