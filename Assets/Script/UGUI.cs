using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGUI : MonoBehaviour {
	//外侧的血条边框
	public RectTransform rectBloodPos;
	//内侧的血条
	public RectTransform blood;
	//减少的血条，先要将内部血条设为stretch，然后这里的reduceBlood对应right属性
	public int Blood = 50;

	void Update()
	{
		//为了保证物体移动的时候血条跟着动
		this.transform.LookAt (Camera.main.transform.position);
		blood.GetComponent<RectTransform>().Right(Blood);
	}

	private void OnGUI()
	{
		if (GUI.Button(new Rect(370, 190, 40, 20), "减血"))
		{
			Blood += 10;
			if(Blood > 50)
			{
				Blood = 50;
			}
		}
		if (GUI.Button(new Rect(540, 190, 40, 20), "加血"))
		{
			Blood -= 10;
			if(Blood < -50)
			{
				Blood = -50;
			}
		}
	}
}
public static class ExtensionMethod
{
	// 扩展方法必须是静态的
	// this 必须有，RectTransform表示我要扩展的类型，rTrans表示对象名
	// 如果要带参数就在后面带上
	public static void Left(this RectTransform rTrans, int value)
	{
		rTrans.offsetMin = new Vector2(value, rTrans.offsetMin.y);
	}

	public static void Right(this RectTransform rTrans, int value)
	{
		rTrans.offsetMax = new Vector2(-value, rTrans.offsetMax.y);
	}

	public static void Bottom(this RectTransform rTrans, int value)
	{
		rTrans.offsetMin = new Vector2(rTrans.offsetMin.x, value);
	}

	public static void Top(this RectTransform rTrans, int value)
	{
		rTrans.offsetMax = new Vector2(rTrans.offsetMax.x, -value);
	}
}