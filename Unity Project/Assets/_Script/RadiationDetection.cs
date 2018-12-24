using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 射线检测类
/// </summary>
public class RadiationDetection : MonoBehaviour
{
    //物体位置（用来标记坐标）
    public Transform cube;
    //射线对象是：结构体类型（存储了相关信息）
    RaycastHit hit;
    //设置射线在plane上的目标点target
    private Vector3 target;

    /// <summary>
    /// 主摄像机
    /// </summary>
    public Transform camera;
    /// <summary>
    /// 物体与摄像机之间的偏移量
    /// </summary>
    private Vector3 offset;
    /// <summary>
    /// 角色的Animator组件
    /// </summary>
    public Animator playerAnimator;
    float turnAmount;

    private void Start()
    {
        offset = camera.position - cube.position;
    }

    private void Update()
    {
        //点击鼠标右键
        if (Input.GetMouseButton(1))
        {
            //开启运动动画
            playerAnimator.SetBool("IsRun", true);
            //屏幕坐标转射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //发出射线检测到了碰撞
            bool isHit = Physics.Raycast((Ray)ray, out hit);
            if (isHit)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    ////向量位置=碰撞点位置-人物位置
                    //target = hit.point - cube.position;
                    Debug.Log("坐标为：" + hit.point);
                    //检测到碰撞，将检测到的点记录下来
                    target = hit.point;
                }
                //else
                //{
                //    target = Vector3.zero;
                //}

            }
            cube.transform.LookAt(target);
            //camera.rotation.y = cube.rotation.y;
            Move(target);
            #region 向量旋转阶段
            ////Distance(Vector3 a, Vector3 b)返回a和b之间的距离。
            ////如果碰撞点和人物坐标的距离大于0.5 并且向量位置不为0
            //if (Vector3.Distance(hit.point, cube.position) > 0.5f && target != Vector3.zero)
            //{
            //    Move(target);
            //}
            //else
            //{
            //    //关闭运动动画
            //    playerAnimator.SetBool("IsRun", false);
            //}
            #endregion


        }

        camera.position = cube.position + offset;
        #region LookAt阶段
        //判断人物和点击坐标的绝对值是否小于0.3
        if (Math.Abs((cube.position.x) - (target.x)) < 0.3 && Math.Abs((cube.position.z) - (target.z)) < 0.3)
        {
            Debug.Log(target);
            //关闭运动动画
            playerAnimator.SetBool("IsRun", false);
        }
        else
        {
            //开启运动动画
            playerAnimator.SetBool("IsRun", true);
        }
        #endregion

    }

    /// <summary>
    /// 移动方法
    /// </summary>
    /// <param name="target"></param>
    void Move(Vector3 target)
    {
        #region 向量旋转阶段
        ////target.magnitude返回这个向量的长度(只读)。
        //if (target.magnitude > 1f)
        //{
        //    //使向量的长度为1
        //    target.Normalize();
        //}
        ////transform.InverseTransformDirection将一个方向（向量）从世界空间转换为局部空间。
        //target = transform.InverseTransformDirection(target);
        ////将一个向量投影到由正交于该平面的法向量定义的平面上。 
        ////参数:向量,射线击中表面的法线
        //target = Vector3.ProjectOnPlane(target, hit.normal);
        //turnAmount = Mathf.Atan2(target.x, target.z);
        //cube.transform.Rotate(0f, turnAmount * 240f * Time.deltaTime, 0f);
        ////cube.transform.Translate(target * 10f * Time.deltaTime);
        #endregion

        cube.position = Vector3.Lerp(cube.position, new Vector3(target.x, cube.position.y, target.z), Time.deltaTime);

    }

}
