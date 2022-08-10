using UnityEngine;

public static class UnityTool
{
    public static GameObject FindChild(GameObject parent, string childName)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        bool isFound = false;
        Transform target = null;
        foreach (Transform transform in children)
        {
            if (transform.name == childName)
            {
                if (isFound)
                {
                    Debug.LogWarning("在游戏物体"+parent+"下存在不止一个子物体:" + childName);
                }
                isFound = true;
                target = transform;
            }
        }
        return target is null ? null : target.gameObject;
    }

    public static void Attach(GameObject parent, GameObject child)
    {
        child.transform.parent = parent.transform; // 设置父级
        child.transform.localPosition = Vector3.zero;
        child.transform.localScale = Vector3.one;
        child.transform.localEulerAngles = Vector3.zero;
        

    }
}