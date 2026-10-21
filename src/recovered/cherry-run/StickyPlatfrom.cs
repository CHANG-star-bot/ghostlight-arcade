// Recovered C# from the distributed game's Assembly-CSharp.dll.
// Decompiled with ILSpy 9.1.0.7988; this is not the original project source.

using UnityEngine;

public class StickyPlatfrom : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			collision.gameObject.transform.SetParent(base.transform);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			collision.gameObject.transform.SetParent(null);
		}
	}
}
