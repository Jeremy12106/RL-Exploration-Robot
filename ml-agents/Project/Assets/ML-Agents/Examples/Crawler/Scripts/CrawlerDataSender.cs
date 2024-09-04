using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class CrawlerDataSender : MonoBehaviour
{
    private TcpClient client;
    private NetworkStream stream;
    public Camera crawlerCamera; // 添加對crawler Camera的引用
    public string targetTag = "TargetObject"; // 替換為你的目標物體標籤

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            client = new TcpClient("localhost", 8000);
            stream = client.GetStream();
        }
        catch (SocketException e)
        {
            UnityEngine.Debug.LogError("Socket exception: " + e.ToString());
            this.enabled = false;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 獲得 crawler 的世界座標和旋轉角度
        Vector3 crawlerPosition = transform.position;
        Vector3 crawlerRotation = transform.eulerAngles;

        // 獲得所有带有指定標籤的目標物體
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);

        // 初始化數據字串
        StringBuilder dataStringBuilder = new StringBuilder();

        // 將 crawler 座標和旋轉角度添加到數據字串
        dataStringBuilder.Append($"{crawlerPosition.x},{crawlerPosition.y},{crawlerPosition.z},");
        dataStringBuilder.Append($"{crawlerRotation.x},{crawlerRotation.y},{crawlerRotation.z},");

        // 獲得每个目標物體的世界座標和螢幕座標
        foreach (GameObject targetObject in targetObjects)
        {
            Vector3 targetPosition = targetObject.transform.position;
            Vector3 screenPosition = crawlerCamera.WorldToScreenPoint(targetPosition);

            // 将目標物體座標和螢幕座標添加到數據字串
            dataStringBuilder.Append($"{targetPosition.x},{targetPosition.y},{targetPosition.z},");
            dataStringBuilder.Append($"{screenPosition.x},{screenPosition.y},");
        }

        // 移除最后一个多餘的逗號
        if (dataStringBuilder.Length > 0)
        {
            dataStringBuilder.Length--;
        }

        // 將數據發送到 Python 伺服器
        byte[] data = Encoding.UTF8.GetBytes(dataStringBuilder.ToString());
        stream.Write(data, 0, data.Length);
    }

    void OnApplicationQuit()
    {
        // 關閉連接
        stream.Close();
        client.Close();
    }
}
