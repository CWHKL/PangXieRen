using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Hand_L;
    public GameObject Hand_R;
    public GameObject Foot_L;
    public GameObject Foot_R;
    public GameObject Head;

    public GameObject Hand_L_bone;
    public GameObject Hand_R_bone;
    public GameObject Foot_L_bone;
    public GameObject Foot_R_bone;
    public GameObject Head_bone;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FollowMouseRotate();
        FollowMouseMove();
    }

    //物体跟随鼠标旋转
    private void FollowMouseRotate()
    {
        //获取鼠标的坐标，鼠标是屏幕坐标，Z轴为0，这里不做转换  
        Vector3 mouse = Input.mousePosition;
        //获取物体坐标，物体坐标是世界坐标，将其转换成屏幕坐标，和鼠标一直  
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        //屏幕坐标向量相减，得到指向鼠标点的目标向量，即黄色线段  
        Vector3 direction = mouse - obj;
        //将Z轴置0,保持在2D平面内  
        direction.z = 0f;
        //将目标向量长度变成1，即单位向量，这里的目的是只使用向量的方向，不需要长度，所以变成1  
        direction = direction.normalized;
        //物体自身的Y轴和目标向量保持一直，这个过程XY轴都会变化数值  
        transform.up = direction;
    }

    //跟随鼠标移动
    private void FollowMouseMove()
    {
        float moveSpeed = 30.0f;
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        if (Input.GetMouseButton(0))    //如果按下鼠标左键
        {
            Hand_L.transform.Translate(Input.mousePosition);
        }
        else if (Input.GetKeyDown(KeyCode.Z))    //如果按下z
        {
            Hand_L.transform.Translate(Input.mousePosition);
        }
        else
        {

        }
        //else
        //{
        //    //Hand_L.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        //}

        //if (Input.GetMouseButton(1)|| Input.GetKeyDown(KeyCode.X))    //如果按下鼠标右键/x
        //{
        //    //Hand_R.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        //}

        //if (Input.GetMouseButton(2)|| (Input.GetKeyDown(KeyCode.C))    //如果按下鼠标中键/c
        //{

        //}

    }


}
