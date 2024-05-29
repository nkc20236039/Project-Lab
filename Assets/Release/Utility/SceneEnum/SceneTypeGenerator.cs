using System.Collections.Generic;
using System.IO;
using System.Text;

using UnityEngine;
using UnityEditor;

namespace Utility.SceneTypeGenerator
{
    public class SceneTypeGenerator : MonoBehaviour
    {
        private const string GENERATE_PATH = "/Release/Utility/";
        private const string GENERATE_SCRIPT_NAME = "SceneTypeEnum";

        /// <summary> ESceneType生成 </summary>
        [InitializeOnLoadMethod]
        static void SceneTypeGenerate()
        {
            EditorBuildSettings.sceneListChanged += () =>
            {
                // コード生成
                List<string> writeCodes = new List<string>();
                writeCodes.Add("namespace Utility.SceneTypeGenerator");
                writeCodes.Add("{");
                writeCodes.Add("\t[System.Serializable]");
                writeCodes.Add("\tpublic enum " + GENERATE_SCRIPT_NAME);
                writeCodes.Add("\t{");
                writeCodes.Add("\t\tNone = -1,");
                // シーン一覧からシーン名と状態を取得
                foreach (var scene in EditorBuildSettings.scenes)
                {
                    string sceneName = scene.path;
                    sceneName = sceneName.Remove(0, sceneName.LastIndexOf("/") + 1).Replace(".unity", "").Replace(" ", "_");
                    writeCodes.Add("\t\t" + sceneName + ",");
                }
                writeCodes.Add("\t}");
                writeCodes.Add("}");
                // 生成
                string filePath = $"{Application.dataPath}{GENERATE_PATH}{GENERATE_SCRIPT_NAME}.cs";
                FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(stream, Encoding.UTF8);
                sw.Write("");
                foreach (var code in writeCodes)
                {
                    sw.WriteLine(code);
                }
                sw.Close();
                AssetDatabase.Refresh();
            };
        }
    }
}