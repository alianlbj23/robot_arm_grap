using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 原理：
 *     1、获取中点位置，myGo.GetComponent<BoxCollider>().bounds.center。这一步是关键步骤。
 *     2、在中心点处，创建一个圆柱体（或者空物体），并作为该物体的子物体——命名为【中心点物体】。
 *     3、如果要让物体围绕中点旋转，则把【中心点物体】作为该物体的父物体，然后让“中心点物体”rotate即可。
 * 实际应用中，如果BoxCollider组件在运行时不需要，可以在editor中deactive。
 */

public class get_center_point : MonoBehaviour
{
    [Header("要获取中点位置的物体")]
    [Tooltip("有右键编辑器菜单")]
    public GameObject myGo;

    /// <summary>
    /// 中点位置
    /// </summary>
    private Vector3 center;

    /// <summary>
    /// 获取物体的中点(center)位置，并在中点位置处创建一个圆柱体
    /// </summary>
#if UNITY_EDITOR
    [ContextMenu("设置中点位置")]
#endif
    public void  setCenterObject()
    { 
        if (myGo.GetComponent<BoxCollider>() == null)
        {
            var bc = myGo.AddComponent<BoxCollider>();
            center = bc.bounds.center;
            DestroyImmediate(myGo.GetComponent<BoxCollider>());
        }
        else
        {
            center = myGo.GetComponent<BoxCollider>().bounds.center;
        }
        
        GameObject go1 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        go1.transform.position = center;
        go1.transform.SetParent(myGo.transform);
        go1.name = "中心点物体";
        Debug.Log(center);
    }
}
