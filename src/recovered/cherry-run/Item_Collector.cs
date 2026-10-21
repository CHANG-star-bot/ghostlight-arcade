// Recovered C# from the distributed game's Assembly-CSharp.dll.
// Decompiled with ILSpy 9.1.0.7988; this is not the original project source.

using UnityEngine;
using UnityEngine.UI;

public class Item_Collector : MonoBehaviour
{
	private int cherries = AllControl.GameManager.Instance.score;

	[SerializeField]
	private Text cherriesText;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("cherry"))
		{
			Object.Destroy(collision.gameObject);
			cherries++;
			cherriesText.text = "Cherries:" + cherries;
			AllControl.GameManager.Instance.score = cherries;
		}
	}
}
