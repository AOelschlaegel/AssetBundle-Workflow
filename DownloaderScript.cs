//Put this on an Empty Gameobject

using System.Collections;
using UnityEngine;

namespace MapFramework
{

	public class DownloaderScript : MonoBehaviour
	{
		[Tooltip("URLs to the AssetBundles.")]
		[SerializeField] private string _guessAssetsURL, _matAssetsURL;

		private AssetBundle _guessBundle, _matBundle;

		IEnumerator Start()
		{
			//Download the AssetBundle with the dependencies first.
			WWW www = new WWW(_matAssetsURL);
			yield return www;

			_matBundle = www.assetBundle;
			_matBundle.LoadAllAssets();

			//Then download the AssetBundle with the Prefab.
			www = new WWW(_guessAssetsURL);
			yield return www;

			_guessBundle = www.assetBundle;

			//Instantiate the downloaded prefab.
			Spawn("_guessBundle");
		}

		private void Spawn(string assetName)
		{
			Instantiate(_guessBundle.LoadAsset("Building_Guess"));
		}

		//Clear the memory
		private void UnloadAllBundles()
		{
			_guessBundle.Unload(false);
		}
	}
}
