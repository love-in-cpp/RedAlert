using System;
using UnityEngine;
/// <summary>
///  挂在要销毁的游戏物体身上
/// </summary>
public class DestroyForTime:MonoBehaviour
{
    public float time = 1f;

     void Start()
    {
        Invoke("Destory",time); // invoke可以在某段时间后调用某个方法
    }

    void Destory()
    {
        GameObject.DestroyImmediate(this.gameObject);
    }
}