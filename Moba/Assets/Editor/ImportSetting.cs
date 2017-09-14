using UnityEditor;
using UnityEngine;

// 解决FairyGUI在Unity5.5下的白屏问题
// http://www.fairygui.com/question/5-5-sdk-%E7%9A%84%E6%98%BE%E7%A4%BA%E9%97%AE%E9%A2%98
public class ImportEditor : AssetPostprocessor
{
    public void OnPreprocessTexture()
    {
        Debug.Log("OnPreProcessTexture=" + assetPath);

        TextureImporter importer = assetImporter as TextureImporter;
        if (importer != null)
        {
            importer.mipmapEnabled = false;
            importer.textureShape = TextureImporterShape.Texture2D;
            importer.maxTextureSize = 2048;
            importer.npotScale = 0;
        }
    }

    public void OnPreprocessModel()
    {
        ModelImporter modelImporter = (ModelImporter)assetImporter;
        modelImporter.importMaterials = false;
        modelImporter.materialSearch = ModelImporterMaterialSearch.Everywhere;
    }
}