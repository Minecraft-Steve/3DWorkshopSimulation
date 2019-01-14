using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// T68控制类
/// </summary>
public class T68Command : MonoBehaviour
{
    #region 公有Button

    /// <summary>
    /// 钻头伸出按钮
    /// </summary>
    public Button reachOutBtn;
    /// <summary>
    /// 钻头缩入按钮
    /// </summary>
    public Button retractionBtn;
    /// <summary>
    /// 钻头停止按钮
    /// </summary>
    public Button stopZhuanTouBtn;

    /// <summary>
    /// 上升按钮
    /// </summary>
    public Button moveToUpBtn;
    /// <summary>
    /// 下降按钮
    /// </summary>
    public Button moveToDownBtn;

    /// <summary>
    /// 高速正转按钮
    /// </summary>
    public Button gaoSuZhengRotateBtn;
    /// <summary>
    /// 高速反转按钮
    /// </summary>
    public Button gaoSuFanRotateBtn;
    /// <summary>
    /// 低速正转按钮
    /// </summary>
    public Button diSuZhengRotateBtn;
    /// <summary>
    /// 低速反转按钮
    /// </summary>
    public Button diSuFanRotateBtn;
    /// <summary>
    /// 停止旋转按钮
    /// </summary>
    public Button stopRotateBtn;

    /// <summary>
    /// 向前按钮
    /// </summary>
    public Button forWardBtn;
    /// <summary>
    /// 向后按钮
    /// </summary>
    public Button backBtn;
    /// <summary>
    /// 向左按钮
    /// </summary>
    public Button leftBtn;
    /// <summary>
    /// 向右按钮
    /// </summary>
    public Button rightBtn;
    /// <summary>
    /// 停止按钮
    /// </summary>
    public Button stopMoveToBtn;

    #endregion

    public static T68Command _instance;

    #region One

    /// <summary>
    /// 钻头
    /// </summary>
    public GameObject zhuanTou;
    /// <summary>
    /// 伸出的位置
    /// </summary>
    public Transform reachOutTrans;
    /// <summary>
    /// 缩入的原始位置
    /// </summary>
    public Transform retractionTrans;

    #endregion

    #region Two

    /// <summary>
    /// 需要移动的物体数组
    /// </summary>
    public List<GameObject> moveTo = new List<GameObject>();
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

    #endregion

    #region Three

    /// <summary>
    /// 是否旋转
    /// </summary>
    bool isRotate = false;
    /// <summary>
    /// 是否高速旋转
    /// </summary>
    bool isGaoSuRotate;
    /// <summary>
    /// 是否高速正反
    /// </summary>
    bool isGaoSuZhengFan;
    /// <summary>
    /// 是否低速旋转
    /// </summary>
    bool isDiSuRotate;
    /// <summary>
    /// 是否低速正反
    /// </summary>
    bool isDiSuZhengFan;
    /// <summary>
    /// 旋转速度数值
    /// </summary>
    float rotateValue;

    #endregion

    #region Four

    /// <summary>
    /// 工作台相关总父对象
    /// </summary>
    public GameObject tableAboutZongParent;
    public GameObject tableAbout;
    /// <summary>
    /// 工作台
    /// </summary>
    public GameObject table;
    public List<GameObject> upDown = new List<GameObject>();

    /// <summary>
    /// 第一个位置
    /// </summary>
    public Transform table_1Trans;
    /// <summary>
    /// 第一个位置的原位置
    /// </summary>
    public Transform table_1TransYuan;
    /// <summary>
    /// 第二个位置
    /// </summary>
    public Transform table_2Trans;
    /// <summary>
    /// 第三个位置
    /// </summary>
    public Transform table_3Trans;
    /// <summary>
    /// 第二个后方物体
    /// 移动到的最终位置
    /// </summary>
    public Transform oneBack_2Trans;
    /// <summary>
    /// 第二个后方物体
    /// 的原位置
    /// </summary>
    public Transform oneBack_2TransYuan;
    /// <summary>
    /// 第四个位置
    /// </summary>
    public Transform table_4Trans;

    /// <summary>
    /// 后方第一个位置
    /// </summary>
    public Transform back_Table_1Trans;
    /// <summary>
    /// 后方第二个位置
    /// </summary>
    public Transform back_Table_2Trans;
    /// <summary>
    /// 后方第三个位置
    /// </summary>
    public Transform back_Table_3Trans;
    /// <summary>
    /// 第二个前方物体
    /// 移动到的最终位置
    /// </summary>
    public Transform oneForWard_2Trans;
    /// <summary>
    /// 第二个前方物体
    /// 的原位置
    /// </summary>
    public Transform oneForWard_2TransYuan;
    /// <summary>
    /// 后方第四个位置
    /// </summary>
    public Transform back_Table_4Trans;

    /// <summary>
    /// 是否点击前进
    /// </summary>
    bool isForWard;
    /// <summary>
    /// 是否点击后退
    /// </summary>
    bool isDown;

    public List<GameObject> leftRight = new List<GameObject>();
    /// <summary>
    /// 第一个位置的原位置
    /// </summary>
    public Transform leftRightTransYuan;
    /// <summary>
    /// 左侧第一个位置
    /// </summary>
    public Transform left_1Trans;
    /// <summary>
    /// 右侧第一个位置
    /// </summary>
    public Transform oneRight_1Trans;
    /// <summary>
    /// 右侧第一个位置
    /// 原位置
    /// </summary>
    public Transform oneRight_1TransYuan;
    /// <summary>
    /// 左侧第二个位置
    /// </summary>
    public Transform left_2Trans;
    /// <summary>
    /// 左侧第三个位置
    /// </summary>
    public Transform left_3Trans;
    /// <summary>
    /// 左侧第四个位置
    /// </summary>
    public Transform left_4Trans;
    /// <summary>
    /// 左侧第五个位置
    /// </summary>
    public Transform left_5Trans;
    /// <summary>
    /// 左侧第六个位置
    /// </summary>
    public Transform left_6Trans;
    /// <summary>
    /// 左侧第七个位置
    /// </summary>
    public Transform left_7Trans;

    /// <summary>
    /// 右侧第一个位置
    /// </summary>
    public Transform right_1Trans;
    /// <summary>
    /// 左侧第一个位置
    /// </summary>
    public Transform twoLeft_1Trans;
    /// <summary>
    /// 左侧第一个位置
    /// 原位置
    /// </summary>
    public Transform twoLeft_1TransYuan;
    /// <summary>
    /// 右侧第二个位置
    /// </summary>
    public Transform right_2Trans;
    /// <summary>
    /// 右侧第三个位置
    /// </summary>
    public Transform right_3Trans;
    /// <summary>
    /// 右侧第四个位置
    /// </summary>
    public Transform right_4Trans;
    /// <summary>
    /// 右侧第五个位置
    /// </summary>
    public Transform right_5Trans;
    /// <summary>
    /// 右侧第六个位置
    /// </summary>
    public Transform right_6Trans;
    /// <summary>
    /// 右侧第七个位置
    /// </summary>
    public Transform right_7Trans;

    /// <summary>
    /// 是否点击左移
    /// </summary>
    bool isLeft;
    /// <summary>
    /// 是否点击右移
    /// </summary>
    bool isRight;
    /// <summary>
    /// 是否可以点击
    /// </summary>
    bool isClick = true;

    #endregion


    private void Start()
    {
        _instance = this;
        reachOutBtn.onClick.AddListener(ReachOuting);
        retractionBtn.onClick.AddListener(Retractioning);
        stopZhuanTouBtn.onClick.AddListener(StopZhuanTouing);
        gaoSuZhengRotateBtn.onClick.AddListener(GaoSuZhengRotateing);
        gaoSuFanRotateBtn.onClick.AddListener(GaoSuFanRotateing);
        diSuZhengRotateBtn.onClick.AddListener(DiSuZhengRotateing);
        diSuFanRotateBtn.onClick.AddListener(DiSuFanRotateing);
        stopRotateBtn.onClick.AddListener(StopRotateing);
        forWardBtn.onClick.AddListener(TableMoveToForWarding);
        backBtn.onClick.AddListener(TableMoveToBacking);
        //stopMoveToBtn.onClick.AddListener(StopMoveToing);
        leftBtn.onClick.AddListener(LeftMoveToing);
        rightBtn.onClick.AddListener(RightMoveToing);
    }

    private void Update()
    {
        if (isRotate)
        {
            if (isGaoSuRotate)
            {
                if (isGaoSuZhengFan)
                {
                    rotateValue = 400f;
                    Rotateing(rotateValue);
                }
                else
                {
                    rotateValue = -400f;
                    Rotateing(rotateValue);
                }
            }
            else if (isDiSuRotate)
            {
                if (isDiSuZhengFan)
                {
                    rotateValue = 150f;
                    Rotateing(rotateValue);
                }
                else
                {
                    rotateValue = -150f;
                    Rotateing(rotateValue);
                }
            }
        }
        else
        {
            rotateValue = 0f;
        }

    }

    /// <summary>
    /// 钻头伸出的方法
    /// </summary>
    void ReachOuting()
    {
        zhuanTou.transform.DOMove(reachOutTrans.position, 2f);
    }

    /// <summary>
    /// 钻头缩入的方法
    /// </summary>
    void Retractioning()
    {
        zhuanTou.transform.DOMove(retractionTrans.position, 2f);
    }

    /// <summary>
    /// 停止钻头伸缩的方法
    /// </summary>
    void StopZhuanTouing()
    {
        zhuanTou.transform.DOKill();
    }

    /// <summary>
    /// 物体上下移动的方法
    /// </summary>
    /// <param name="sx">移动的方向值</param>
    public void MoveToing(float sx)
    {
        foreach (var i in moveTo)
        {
            i.transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * sx);
        }
    }

    /// <summary>
    /// 高速正转的方法
    /// </summary>
    void GaoSuZhengRotateing()
    {
        isRotate = true;
        isDiSuRotate = false;
        isGaoSuRotate = true;
        isGaoSuZhengFan = true;
    }

    /// <summary>
    /// 高速反转的方法
    /// </summary>
    void GaoSuFanRotateing()
    {
        isRotate = true;
        isDiSuRotate = false;
        isGaoSuRotate = true;
        isGaoSuZhengFan = false;
    }

    /// <summary>
    /// 低速正转的方法
    /// </summary>
    void DiSuZhengRotateing()
    {
        isRotate = true;
        isGaoSuRotate = false;
        isDiSuRotate = true;
        isDiSuZhengFan = true;
    }

    /// <summary>
    /// 低速反转的方法
    /// </summary>
    void DiSuFanRotateing()
    {
        isRotate = true;
        isGaoSuRotate = false;
        isDiSuRotate = true;
        isDiSuZhengFan = false;
    }

    /// <summary>
    /// 旋转的方法
    /// </summary>
    /// <param name="value">旋转的速度值</param>
    void Rotateing(float value)
    {
        zhuanTou.transform.Rotate(transform.forward, value * Time.deltaTime);
    }

    /// <summary>
    /// 停止旋转的方法
    /// </summary>
    void StopRotateing()
    {
        isRotate = false;
    }

    #region One

    ///// <summary>
    ///// 工作台向前移动的方法
    ///// </summary>
    //void TableMoveToForWarding()
    //{
    //    table.transform.DOMove(table_1Trans.position, 1f).OnComplete(() => TableMoveToForWarding_Two());

    //}

    //void TableMoveToForWarding_Two()
    //{
    //    forWard_1.transform.parent = table.transform;
    //    table.transform.DOMove(table_2Trans.position, 1f).OnComplete(() => TableMoveToForWarding_Three());
    //}

    //void TableMoveToForWarding_Three()
    //{
    //    forWard_2.transform.parent = table.transform;
    //    back_1.transform.parent = table.transform;
    //    table.transform.DOMove(table_3Trans.position, 1f);
    //    back_2.transform.DOMove(back_2Trans.position, 1.3f).OnComplete(() => TableMoveToForWarding_Four());
    //}

    //void TableMoveToForWarding_Four()
    //{
    //    back_2.transform.parent = table.transform;
    //    back_3.transform.parent = table.transform;
    //    forWard_3.transform.parent = table.transform;
    //    table.transform.DOMove(table_4Trans.position, 1f);
    //}

    #endregion
    //or

    /// <summary>
    /// 工作台向前移动的方法
    /// </summary>
    void TableMoveToForWarding()
    {
        //table.transform.DOMove(table_1Trans.position, 1f).OnComplete(() => TableMoveToForWarding_Two());
        if (isClick)
        {
            isClick = false;
            if (isDown)
            {
                StartCoroutine(TableMoveTo_ForWard_Back_Backing());
            }
            StartCoroutine(TableMoveToForWarding_Two());
            isForWard = true;
            isDown = false;
        }
        
    }

    IEnumerator TableMoveToForWarding_Two()
    {
        if (isDown)
        {
            yield return new WaitForSeconds(3f);
        }
        upDown[0].transform.DOMove(table_1Trans.position, 1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        upDown[1].transform.parent = upDown[0].transform;
        upDown[0].transform.DOMove(table_2Trans.position, 1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        upDown[2].transform.parent = upDown[0].transform;
        upDown[4].transform.parent = upDown[0].transform;
        upDown[0].transform.DOMove(table_3Trans.position, 1f).SetEase(Ease.Linear);
        upDown[5].transform.DOMove(oneBack_2Trans.position, 1.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.3f);
        upDown[3].transform.parent = upDown[0].transform;
        upDown[5].transform.parent = upDown[0].transform;
        upDown[6].transform.parent = upDown[0].transform;
        upDown[0].transform.DOMove(table_4Trans.position, 1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        isClick = true;
    }

    /// <summary>
    /// 工作台向后移动的方法
    /// </summary>
    void TableMoveToBacking()
    {
        if (isClick)
        {
            isClick = false;
            if (isForWard)
            {
                StartCoroutine(TableMoveTo_ForWard_Back_ForWarding());
            }
            StartCoroutine(TableMoveToBacking_Two());
            isDown = true;
            isForWard = false;
        }
        
    }

    IEnumerator TableMoveToBacking_Two()
    {
        if (isForWard)
        {
            yield return new WaitForSeconds(4f);
        }
        upDown[0].transform.DOMove(back_Table_1Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        upDown[4].transform.parent = upDown[0].transform;
        upDown[0].transform.DOMove(back_Table_2Trans.position, 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        upDown[5].transform.parent = upDown[0].transform;
        upDown[1].transform.parent = upDown[0].transform;
        upDown[0].transform.DOMove(back_Table_3Trans.position, 1f).SetEase(Ease.Linear);
        upDown[2].transform.DOMove(oneForWard_2Trans.position, 1.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.3f);
        upDown[2].transform.parent = upDown[0].transform;
        upDown[3].transform.parent = upDown[0].transform;
        upDown[0].transform.DOMove(back_Table_4Trans.position, 1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        isClick = true;
    }

    /// <summary>
    /// 前进方向收回
    /// 的协程
    /// </summary>
    /// <returns></returns>
    IEnumerator TableMoveTo_ForWard_Back_ForWarding()
    {
        upDown[0].transform.DOMove(table_3Trans.position, 1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        upDown[3].transform.parent = tableAbout.transform;
        upDown[5].transform.parent = tableAbout.transform;
        upDown[6].transform.parent = tableAbout.transform;
        upDown[5].transform.DOMove(oneBack_2TransYuan.position, 0.5f).SetEase(Ease.Linear);
        upDown[0].transform.DOMove(table_2Trans.position, 1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        upDown[2].transform.parent = tableAbout.transform;
        upDown[4].transform.parent = tableAbout.transform;
        upDown[0].transform.DOMove(table_1Trans.position, 1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        upDown[1].transform.parent = tableAbout.transform;
        upDown[0].transform.DOMove(table_1TransYuan.position, 1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
    }

    /// <summary>
    /// 后退方向收回
    /// 的协程
    /// </summary>
    /// <returns></returns>
    IEnumerator TableMoveTo_ForWard_Back_Backing()
    {
        upDown[0].transform.DOMove(back_Table_3Trans.position, 1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        upDown[2].transform.parent = tableAbout.transform;
        upDown[3].transform.parent = tableAbout.transform;
        upDown[2].transform.DOMove(oneForWard_2TransYuan.position, 1.3f).SetEase(Ease.Linear);
        upDown[0].transform.DOMove(back_Table_2Trans.position, 1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        upDown[5].transform.parent = tableAbout.transform;
        upDown[1].transform.parent = tableAbout.transform;
        upDown[0].transform.DOMove(back_Table_1Trans.position, 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        upDown[4].transform.parent = tableAbout.transform;
        upDown[0].transform.DOMove(table_1TransYuan.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
    }

    /// <summary>
    /// 停止工作台移动的方法
    /// </summary>
    void StopMoveToing()
    {
        //upDown[0].transform.DOKill();
        
    }

    /// <summary>
    /// 向左移动的方法
    /// </summary>
    void LeftMoveToing()
    {
        if (isClick)
        {
            isClick = false;
            if (isRight)
            {
                StartCoroutine(RightMoveToing_Righting());
            }
            StartCoroutine(LeftMoveToing_Two());
            isLeft = true;
            isRight = false;
        }
        
    }

    IEnumerator LeftMoveToing_Two()
    {
        if (isRight)
        {
            yield return new WaitForSeconds(2f);
        }
        leftRight[0].transform.DOMove(left_1Trans.position, 0.3f).SetEase(Ease.Linear);
        leftRight[7].transform.DOMove(oneRight_1Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        leftRight[7].transform.parent = leftRight[0].transform;
        leftRight[1].transform.parent = leftRight[0].transform;
        leftRight[0].transform.DOMove(left_2Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        leftRight[2].transform.parent = leftRight[0].transform;
        leftRight[8].transform.parent = leftRight[0].transform;
        leftRight[0].transform.DOMove(left_3Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        leftRight[3].transform.parent = leftRight[0].transform;
        leftRight[0].transform.DOMove(left_4Trans.position, 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        leftRight[4].transform.parent = leftRight[0].transform;
        leftRight[9].transform.parent = leftRight[0].transform;
        leftRight[0].transform.DOMove(left_5Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        leftRight[5].transform.parent = leftRight[0].transform;
        leftRight[0].transform.DOMove(left_6Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        leftRight[6].transform.parent = leftRight[0].transform;
        leftRight[10].transform.parent = leftRight[0].transform;
        leftRight[0].transform.DOMove(left_7Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        isClick = true;
    }

    /// <summary>
    /// 向右移动的方法
    /// </summary>
    void RightMoveToing()
    {
        if (isClick)
        {
            isClick = false;
            if (isLeft)
            {
                StartCoroutine(LeftMoveTo_Lefting());
            }
            StartCoroutine(RightMoveToing_Two());
            isLeft = false;
            isRight = true;
        }
        
    }

    IEnumerator RightMoveToing_Two()
    {
        if (isLeft)
        {
            yield return new WaitForSeconds(2f);
        }
        leftRight[0].transform.DOMove(right_1Trans.position, 0.3f).SetEase(Ease.Linear);
        leftRight[1].transform.DOMove(twoLeft_1Trans.position, 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        leftRight[7].transform.parent = leftRight[0].transform;
        leftRight[1].transform.parent = leftRight[0].transform;
        leftRight[0].transform.DOMove(right_2Trans.position, 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        leftRight[2].transform.parent = leftRight[0].transform;
        leftRight[8].transform.parent = leftRight[0].transform;
        leftRight[0].transform.DOMove(right_3Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        leftRight[3].transform.parent = leftRight[0].transform;
        leftRight[9].transform.parent = leftRight[0].transform;
        leftRight[0].transform.DOMove(right_4Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);     
        leftRight[10].transform.parent = leftRight[0].transform;
        leftRight[0].transform.DOMove(right_5Trans.position, 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        leftRight[4].transform.parent = leftRight[0].transform;
        leftRight[11].transform.parent = leftRight[0].transform;
        leftRight[0].transform.DOMove(right_6Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        //leftRight[12].transform.parent = leftRight[0].transform;
        //leftRight[5].transform.parent = leftRight[0].transform;
        //leftRight[0].transform.DOMove(right_7Trans.position, 0.3f);
        //yield return new WaitForSeconds(0.3f);
        isClick = true;
    }

    /// <summary>
    /// 左移动收回
    /// 的协程
    /// </summary>
    /// <returns></returns>
    IEnumerator LeftMoveTo_Lefting()
    {
        leftRight[0].transform.DOMove(left_6Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        leftRight[6].transform.parent = tableAboutZongParent.transform;
        leftRight[10].transform.parent = tableAboutZongParent.transform;
        leftRight[0].transform.DOMove(left_5Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        leftRight[5].transform.parent = tableAboutZongParent.transform;
        leftRight[0].transform.DOMove(left_4Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        leftRight[4].transform.parent = tableAboutZongParent.transform;
        leftRight[9].transform.parent = tableAboutZongParent.transform;
        leftRight[0].transform.DOMove(left_3Trans.position, 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        leftRight[3].transform.parent = tableAboutZongParent.transform;
        leftRight[0].transform.DOMove(left_2Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        leftRight[2].transform.parent = tableAboutZongParent.transform;
        leftRight[8].transform.parent = tableAboutZongParent.transform;
        leftRight[0].transform.DOMove(left_1Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        leftRight[7].transform.parent = tableAboutZongParent.transform;
        leftRight[1].transform.parent = tableAboutZongParent.transform;
        leftRight[7].transform.DOMove(oneRight_1TransYuan.position, 0.3f).SetEase(Ease.Linear);
        leftRight[0].transform.DOMove(leftRightTransYuan.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
    }

    /// <summary>
    /// 右移动收回
    /// 的协程
    /// </summary>
    /// <returns></returns>
    IEnumerator RightMoveToing_Righting()
    {
        //leftRight[0].transform.DOMove(right_6Trans.position, 0.3f);
        //yield return new WaitForSeconds(0.3f);
        //leftRight[12].transform.parent = tableAboutZongParent.transform;
        //leftRight[5].transform.parent = tableAboutZongParent.transform;
        leftRight[0].transform.DOMove(right_5Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        leftRight[4].transform.parent = tableAboutZongParent.transform;
        leftRight[11].transform.parent = tableAboutZongParent.transform;
        leftRight[0].transform.DOMove(right_4Trans.position, 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        leftRight[10].transform.parent = tableAboutZongParent.transform;
        leftRight[0].transform.DOMove(right_3Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        leftRight[3].transform.parent = tableAboutZongParent.transform;
        leftRight[9].transform.parent = tableAboutZongParent.transform;
        leftRight[0].transform.DOMove(right_2Trans.position, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        leftRight[2].transform.parent = tableAboutZongParent.transform;
        leftRight[8].transform.parent = tableAboutZongParent.transform;
        leftRight[0].transform.DOMove(right_1Trans.position, 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        leftRight[7].transform.parent = tableAboutZongParent.transform;
        leftRight[1].transform.parent = tableAboutZongParent.transform;
        leftRight[0].transform.DOMove(leftRightTransYuan.position, 0.3f).SetEase(Ease.Linear);
        leftRight[1].transform.DOMove(twoLeft_1TransYuan.position, 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
    }
}
