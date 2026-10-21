// Recovered C# from the distributed game's Assembly-CSharp.dll.
// Decompiled with ILSpy 9.1.0.7988; this is not the original project source.

using UnityEngine;

public class FacingCamera : MonoBehaviour
{
	private Transform[] childs;

	private void Start()
	{
		childs = new Transform[base.transform.childCount];
		for (int i = 0; i < base.transform.childCount; i++)
		{
			childs[i] = base.transform.GetChild(i);
		}
	}

	private void Update()
	{
		for (int i = 0; i < childs.Length; i++)
		{
			childs[i].rotation = Camera.main.transform.rotation;
		}
	}
}
