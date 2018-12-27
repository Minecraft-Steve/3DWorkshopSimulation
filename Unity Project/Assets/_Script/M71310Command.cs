using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

/// <summary>
/// M7130控制类
/// </summary>
public class M71310Command : MonoBehaviour
{
    public static M71310Command _instance;
    /// <summary>
    /// 齿轮旋转按钮
    /// </summary>
    public Button gearRotatingBtn;
    /// <summary>
    /// 齿轮部件
    /// </summary>
    public GameObject gear;
    /// <summary>
    /// 是否旋转
    /// </summary>
    bool isRotate = false;

    /// <summary>
    /// 停止旋转按钮
    /// </summary>
    public Button stopRotateBtn;

    /// <summary>
    /// 上移按钮
    /// </summary>
    public Button moveUpBtn;
    /// <summary>
    /// 下移按钮
    /// </summary>
    public Button moveDownBtn;
    /// <summary>
    /// 要移动的物体数组
    /// </summary>
    public List<GameObject> moveUp = new List<GameObject>();
    public List<GameObject> moveZ = new List<GameObject>();
    public List<GameObject> moveHeHe = new List<GameObject>();
    /// <summary>
    /// 移动速度
    /// </summary>
    public float moveSpeed = 0.5f;

    /// <summary>
    /// 是否停止向上移动
    /// </summary>
    [HideInInspector]
    public bool isUpStop = false;
    /// <summary>
    /// 是否停止向下移动
    /// </summary>
    [HideInInspector]
    public bool isDownStop = false;

    /// <summary>
    /// 工作台移动到左侧按钮
    /// </summary>
    public Button workbenchLeftBtn;
    /// <summary>
    /// 工作台往复运动按钮
    /// </summary>
    public Button workbenchGoGoGoBtn;
    /// <summary>
    /// 工作台
    /// </summary>
    public GameObject workbench;
    /// <summary>
    /// 初始工作台位置
    /// </summary>
    public Transform initialPosition;
    /// <summary>
    /// 工作台移动到左侧的位置
    /// </summary>
    public Transform workbenchLeftPosition;
    /// <summary>
    /// 工作台移动到右侧的位置
    /// </summary>
    public Transform workbenchRightPosition;

    /// <summary>
    /// 工作台停止运动
    /// </summary>
    public Button workbenchStopBtn;
    /// <summary>
    /// 是否准备
    /// </summary>
    [HideInInspector]
    bool isPreparatoryWork = false;

    private void Start()
    {
        _instance = this;
        gearRotatingBtn.onClick.AddListener(gearRotating);
        stopRotateBtn.onClick.AddListener(stopRotateing);
        moveUpBtn.onClick.AddListener(moveUping);
        moveDownBtn.onClick.AddListener(moveDowning);
        workbenchLeftBtn.onClick.AddListener(moveToWorkbenchLefting);
        workbenchGoGoGoBtn.onClick.AddListener(moveToWorkbenchGoGoGoing_One);
        workbenchStopBtn.onClick.AddListener(moveToStoping);
    }

    private void Update()
    {
        if (isRotate)
        {
            //绕自身Z轴旋转
            gear.transform.Rotate(transform.forward, 100f * Time.deltaTime);
            Debug.Log("旋转");
        }

    }

    /// <summary>
    /// 齿轮旋转方法
    /// </summary>
    void gearRotating()
    {
        isRotate = true;
    }

    void stopRotateing()
    {
        isRotate = false;
    }

    /// <summary>
    /// 物体向上移动的方法
    /// </summary>
    void moveUping()
    {
        if (!isUpStop)
        {
            moveSpeed = Mathf.Abs(moveSpeed);
            moveTo_Toing();
        } 
    }

    /// <summary>
    /// 物体向下移动的方法
    /// </summary>
    void moveDowning()
    {
        if (!isDownStop)
        {
            moveSpeed = Mathf.Abs(moveSpeed) * -1;
            moveTo_Toing();
        }
    }

    /// <summary>
    /// 物体上下移动的方法
    /// </summary>
    void moveTo_Toing()
    {
        foreach (var i in moveUp)
        {
            i.transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        }
        foreach (var j in moveZ)
        {
            j.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        for (int k = 0; k < moveHeHe.Count; k++)
        {
            if (k == 0)
            {
                moveHeHe[k].transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            }
            else if (k == 1)
            {
                moveHeHe[k].transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            }
            else if (k == 2)
            {
                moveHeHe[k].transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
            }

        }
    }

    /// <summary>
    /// 工作台移动到左侧的方法
    /// </summary>
    void moveToWorkbenchLefting()
    {
        workbench.transform.DOMove(workbenchLeftPosition.position, 2f);
        isPreparatoryWork = true;
    }

    /// <summary>
    /// 工作台往复移动的方法
    /// </summary>
    void moveToWorkbenchGoGoGoing_One()
    {
        if (isPreparatoryWork)
        {
            workbench.transform.DOMove(workbenchRightPosition.position, 2f).OnComplete(() => moveToWorkbenchGoGoGoing_Two());
        }
    }

    /// <summary>
    /// 工作台往复移动的方法
    /// </summary>
    void moveToWorkbenchGoGoGoing_Two()
    {
        workbench.transform.DOMove(workbenchLeftPosition.position, 2f).OnComplete(() => moveToWorkbenchGoGoGoing_One());
    }

    /// <summary>
    /// 停止运动的方法
    /// </summary>
    void moveToStoping()
    {
        workbench.transform.DOKill();
        workbench.transform.DOMove(initialPosition.position, 2f);
        isPreparatoryWork = false;
    }
}
