﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 射线检测类
/// </summary>
public class RadiationDetection : MonoBehaviour
{
    //物体位置（用来标记坐标）
    public Transform cube;
    //设置射线在plane上的目标点target
    private Vector3 target;

    /// <summary>
    /// 主摄像机
    /// </summary>
    public GameObject camera;
    /// <summary>
    /// 物体与摄像机之间的偏移量
    /// </summary>
    private Vector3 offset;
    /// <summary>
    /// 角色的Animator组件
    /// </summary>
    public Animator playerAnimator;

    private void Start()
    {
        offset = camera.gameObject.transform.position - cube.position;
    }

    private void Update()
    {
        //点击鼠标右键
        if (Input.GetMouseButton(1))
        {
            //屏幕坐标转射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //射线对象是：结构体类型（存储了相关信息）
            RaycastHit hit;
            //发出射线检测到了碰撞
            bool isHit = Physics.Raycast((Ray)ray, out hit);
            if (isHit)
            {
                //Debug.Log("坐标为：" + hit.point);
                //检测到碰撞，将检测到的点记录下来
                target = hit.point;
                
            }
            cube.transform.LookAt(target);
            Move(target);    
        }
        camera.gameObject.transform.position = cube.position + offset;
        
    }

    /// <summary>
    /// 移动方法
    /// </summary>
    /// <param name="target"></param>
    void Move(Vector3 target)
    {
        //开启运动动画
        playerAnimator.SetBool("IsRun", true);
        //cube.position = Vector3.Lerp(cube.position, new Vector3(target.x, cube.position.y, target.z), Time.deltaTime);
        cube.DOMove(target, 1f).OnComplete(Stop);
    }

    void Stop()
    {
        //关闭运动动画
        playerAnimator.SetBool("IsRun", false);
           
    }
}
