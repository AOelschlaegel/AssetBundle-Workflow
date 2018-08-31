//Put this into Assets/Editor

using UnityEditor;
using UnityEngine;

public class CreateAssetBundles : Editor
{
	[MenuItem("Assets/Create Asset Bundle")]
	static void ExportBundle()
	{
		string bundlePath = "Assets/AssetBundles";
		Object[] selectedAssets = Selection.GetFiltered(typeof(Object), SelectionMode.Assets);
		BuildPipeline.BuildAssetBundles(bundlePath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
	}
}
