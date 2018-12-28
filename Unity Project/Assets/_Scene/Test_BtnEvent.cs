using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 测试场景
/// 获取鼠标点击的按钮文字
/// </summary>
public class Test_BtnEvent : MonoBehaviour
{
    /// <summary>
    /// 显示的文本
    /// </summary>
    public Text DisplayBtnText;
    public Text BtnText
    {
        get;set;
    }

	// Use this for initialization
	void Start ()
    {
        this.gameObject.GetComponent<Button>()
            .onClick
            .AddListener
            (
                delegate ()
                {
                    Text text = this.gameObject.GetComponentInChildren<Text>();
                    BtnText = text;
                    DisplayBtnText.text = BtnText.text;
                }
            );
		
	}
}
