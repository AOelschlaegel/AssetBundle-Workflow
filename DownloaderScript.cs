//Put this on an Empty Gameobject
using System.Collections;
using UnityEngine;

namespace AssetBundleHelper
{
	public class DownloaderScript : MonoBehaviour
	{
		[Tooltip("URLs to the AssetBundles.")]
		[SerializeField] private string _prefabAssetsURL, _matAssetsURL;

		private AssetBundle _assetBundle, _matBundle;

		IEnumerator Start()
		{
			//Download the AssetBundle with the dependencies first.
			WWW www = new WWW(_matAssetsURL);
			yield return www;

			_matBundle = www.assetBundle;
			_matBundle.LoadAllAssets();

			//Then download the AssetBundle with the Prefab.
			www = new WWW(_prefabAssetsURL);
			yield return www;

			_assetBundle = www.assetBundle;

			//Instantiate the downloaded prefab.
			Spawn("_prefab");
		}

		private void Spawn(string assetName)
		{
			Instantiate(_assetBundle.LoadAsset("_prefab"));
		}

		//Clear the memory
		private void UnloadAllBundles()
		{
			_guessBundle.Unload(false);
		}
	}
}
