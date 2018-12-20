using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    /// <summary>
    /// 摄像机移动速率
    /// </summary>
    public float speed;

    /// <summary>
    /// 摄像机和人物之间的距离
    /// </summary>
    Vector3 distance;

    /// <summary>
    /// 记录摄像机和人物之间的距离
    /// </summary>
    float offset;

    /// <summary>
    /// 目标人物
    /// </summary>
    public Transform figure;

    /// <summary>
    /// 最大缩放值
    /// </summary>
    public float maxScroll;

    /// <summary>
    /// 最小缩放值
    /// </summary>
    public float minScroll;

    /// <summary>
    ///  Y轴最大旋转角度
    /// </summary>
    public float maxRotationAngleY;

    /// <summary>
    /// Y轴最小旋转角度
    /// </summary>
    public float minRotationAngleY;

    private void Start()
    {
        //计算摄像机和人物之间的距离
        distance = transform.position - figure.position;
    }

    void Update()
    {
        CameraFollow();
        ScrollView();
        Rotate();
    }

    /// <summary>
    /// 摄像机跟随
    /// </summary>
    void CameraFollow()
    {
        transform.position = figure.transform.position + distance;
    }

    /// <summary>
    /// 缩放方法
    /// </summary>
    void ScrollView()
    {
        //判断滚轮的滑动和缩放的大小
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && distance.magnitude < maxScroll)
        {
            Debug.Log("拉远");
            //将三维坐标转化为具体数
            offset = distance.magnitude;
            //计算经过滚轮滑动后的距离
            offset += System.Math.Abs(Input.GetAxis("Mouse ScrollWheel")) * speed;
            //判断所在距离是否超过限定的距离，然后更改
            offset = (offset >= maxScroll) ? maxScroll - 1 : offset;
            //将距离变成三维坐标
            distance = distance.normalized * offset;
        }
        //判断滚轮的滑动和缩放的大小
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && distance.magnitude > minScroll)
        {
            Debug.Log("拉近");
            //将三维坐标转化为具体数
            offset = distance.magnitude;
            //计算经过滚轮滑动后的距离
            offset += -System.Math.Abs(Input.GetAxis("Mouse ScrollWheel")) * speed;
            //判断所在距离是否超过限定的距离，然后更改
            offset = (offset <= minScroll) ? offset + 1 : offset;
            //将距离变成三维坐标
            distance = distance.normalized * offset;
        }
    }

    /// <summary>
    /// 旋转方法
    /// </summary>
    void Rotate()
    {
        //判断鼠标点击是否为该按键
        if (Input.GetMouseButton(0))
        {
            //通过鼠标的滑动来计算在哪个轴来尽行旋转
            transform.RotateAround(figure.position, figure.up, Input.GetAxis("Mouse X") * speed);
            //计算摄像机和人物之间的坐标差
            distance = transform.position - figure.position;
            //更新摄像机的位置
            transform.position = figure.position + distance;

            //最大限度
            //在Y轴的旋转是否超过限度
            if (transform.localEulerAngles.x < maxRotationAngleY && Input.GetAxis("Mouse Y") < 0)
            {
                //通过鼠标的滑动来计算在哪个轴来尽行旋转
                transform.RotateAround(figure.position, transform.right, -Input.GetAxis("Mouse Y") * speed);
                //计算摄像机和人物之间的坐标差
                distance = transform.position - figure.position;
                //更新摄像机的位置
                transform.position = figure.position + distance;
            }
            //最小限度
            //在Y轴的旋转是否超过限度
            if (transform.localEulerAngles.x > minRotationAngleY && Input.GetAxis("Mouse Y") > 0)
            {
                //通过鼠标的滑动来计算在哪个轴来尽行旋转
                transform.RotateAround(figure.position, figure.right, -Input.GetAxis("Mouse Y") * speed);
                //计算摄像机和人物之间的坐标差
                distance = transform.position - figure.position;
                //更新摄像机的位置
                transform.position = figure.position + distance;
            }
        }
    }
}