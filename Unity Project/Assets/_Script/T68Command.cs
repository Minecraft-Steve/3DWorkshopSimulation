using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// T68控制类
/// </summary>
public class T68Command : MonoBehaviour
{
    /// <summary>
    /// 轴正转按钮
    /// </summary>
    public Button axleCorotationBtn;


    private void Start()
    {
        axleCorotationBtn.onClick.AddListener(axleCorotationing);
    }

    void axleCorotationing()
    {

    }
}
