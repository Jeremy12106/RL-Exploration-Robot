using UnityEngine;

public class CameraCircularMovement : MonoBehaviour
{
    [SerializeField] private GameObject target;//Camera要面向的物件
    [SerializeField] private float speed;//相機環繞移動的速度
    private Vector3 cameraPosition;//相機要移動的位置
    private float number;
    private float radius;//移動的半徑

    private void Start()
    {
        //由於我這個範例是x和z軸的移動，而y軸不會改變，所以要先設定好y軸的初始位置
        cameraPosition.y = transform.position.y;
        transform.position = cameraPosition;

        //計算當前攝影機和目標物件的半徑
        radius = Vector3.Distance(target.transform.position, transform.position);
    }


    private void Update()
    {
        //使用Time.deltaTime，使得移動時更加平滑
        //將速度進行一定比例縮放，方便控制速度(縮放多少都隨意，自己覺得數值修改方便就好)
        number += Time.deltaTime * speed * 0.1f;


        //計算並設定新的x和y軸位置
        //負數是順時針旋轉，正數是逆時針旋轉
        cameraPosition.x = radius * Mathf.Cos(-number);
        cameraPosition.z = radius * Mathf.Sin(-number);
        transform.position = cameraPosition;

        //使相機永遠面對著目標物件
        transform.LookAt(target.transform.position);
    }
}

