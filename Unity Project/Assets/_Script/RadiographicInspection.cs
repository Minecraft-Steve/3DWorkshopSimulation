using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 射线检测
/// </summary>
public class RadiographicInspection : MonoBehaviour
{
    /// <summary>
    /// 射线的地面的的碰撞点
    /// </summary>
    Vector3 targetPos;

    /// <summary>
    /// 动画组件
    /// </summary>
    public Animator animator;

    private void Update()
    {
        //判断鼠标检测的是否是右键
        if (Input.GetMouseButtonDown(1))
        {
            //从鼠标当前发射一条射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //保存射线检测的结果
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.gameObject.tag != "Player")
                    return;
                //获得射线和地面的碰撞点
                targetPos = new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z);
               //Vector3 pos = targetPos - transform.position;
               // pos = transform.InverseTransformDirection(pos);
               // float a = Mathf.Atan2(pos.x, pos.z);
               // transform.Rotate(0f, a * 240f * Time.deltaTime, 0f);            
                
                //使人物朝向鼠标点击的位置
                transform.LookAt(targetPos);
                //播放动画
                Switchover();
                //移动
                transform.position = Vector3.MoveTowards(transform.position, targetPos, 2f * Time.deltaTime);
            }
        }

        //float dis = (transform.position - targetPos).sqrMagnitude;
        //Debug.Log(dis);
        //判断人物到目标点的距离
        if ((int)((transform.position - targetPos).sqrMagnitude)<=1)
        {
            Debug.Log("停止");
            //停止动画播放
            Stop();
        }
    }

    /// <summary>
    /// 开始播放动画
    /// </summary>
    public void Switchover()
    {
        Debug.Log("动画播放");
        animator.SetBool("QieHuan", true);
    }

    /// <summary>
    /// 停止动画
    /// </summary>
    public void Stop()
    {
        Debug.Log("动画停止");
        animator.SetBool("QieHuan", false);
    }
}