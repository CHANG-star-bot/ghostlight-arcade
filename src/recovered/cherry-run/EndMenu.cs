// Recovered C# from the distributed game's Assembly-CSharp.dll.
// Decompiled with ILSpy 9.1.0.7988; this is not the original project source.

using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
	public void ReloadGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
	}
}
