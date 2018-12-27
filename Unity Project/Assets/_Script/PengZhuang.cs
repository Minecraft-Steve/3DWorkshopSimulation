using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 碰撞类
/// </summary>
public class PengZhuang : MonoBehaviour
{

    /// <summary>
    /// 当开始进入碰撞器
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="XiaXianWei")
        {
            M71310Command._instance.isDownStop = true;
        }
        if (other.tag == "ShangXianWei")
        {
            M71310Command._instance.isUpStop = true;
        }
    }

    /// <summary>
    /// 停止接触碰撞器
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "XiaXianWei")
        {
            M71310Command._instance.isDownStop = false;
        }
        if (other.tag == "ShangXianWei")
        {
            M71310Command._instance.isUpStop = false;
        }
    }
}
