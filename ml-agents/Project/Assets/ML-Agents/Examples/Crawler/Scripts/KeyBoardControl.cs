using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardControl : MonoBehaviour
{
    private Transform m_Transform;
    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        MoveControl();
    }

    void MoveControl()
    {
        if (Input.GetKey(KeyCode.W))    //前進
        {
            m_Transform.Translate(Vector3.forward * 0.2f, Space.Self);
        }

        if (Input.GetKey(KeyCode.S))    //後退
        {
            m_Transform.Translate(Vector3.back * 0.2f, Space.Self);
        }

        if (Input.GetKey(KeyCode.A))    //左移
        {
            m_Transform.Translate(Vector3.left * 0.2f, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))    //右移
        {
            m_Transform.Translate(Vector3.right * 0.2f, Space.Self);
        }
        if (Input.GetKey(KeyCode.Q))    //鏡頭左移
        {

            m_Transform.Rotate(Vector3.up, -2.0f);
        }

        if (Input.GetKey(KeyCode.E))    //鏡頭右移
        {
            m_Transform.Rotate(Vector3.up, 2.0f);
        }

        if (Input.GetKey(KeyCode.Space))    //上升
        {
            m_Transform.Translate(Vector3.up * 0.2f, Space.Self);
        }

        if (Input.GetKey(KeyCode.LeftShift))    //下降
        {
            m_Transform.Translate(Vector3.down * 0.2f, Space.Self);
        }

        //滑鼠轉動視角
        //m_Transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));

        //m_Transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y"));

    }

}
