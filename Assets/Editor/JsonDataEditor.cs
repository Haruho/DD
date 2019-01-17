using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System;

public class JsonDataEditor : EditorWindow {
    public BlueprintFile bpf;
    private bool isPrettyPrint = false;
    private string filepath = "";
    [MenuItem("DD/JsonEditor")]
    static void Init()
    {
        GetWindow(typeof(JsonDataEditor)).Show();
    }
    private void OnGUI()
    {
        EditorGUILayout.Space();
        if (GUILayout.Button("读取Json"))
        {
            LoadJsonData();
        }
        EditorGUILayout.Space();
        if (GUILayout.Button("创建Json"))
        {
            CreateNewJson();
        }
        EditorGUILayout.Space();
        GUILayout.BeginHorizontal();
        isPrettyPrint = GUILayout.Toggle(isPrettyPrint, "格式化输出");
        if (GUILayout.Button("保存Json"))
        {
            SaveJsonData();
        }
        GUILayout.EndHorizontal();
        EditorGUILayout.Space();
        GUILayout.BeginVertical("Box");
        if (bpf != null)
        {
            GUILayout.Label(filepath);
            SerializedObject obj = new SerializedObject(this);
            SerializedProperty sp = obj.FindProperty("blueprint");
            EditorGUILayout.PropertyField(sp, true);
            obj.ApplyModifiedProperties();
        }
        GUILayout.EndVertical();
    }

    private void SaveJsonData()
    {
        filepath = EditorUtility.SaveFilePanel("保存Json",Application.streamingAssetsPath,"blueprint","json");
        if (string.IsNullOrEmpty(filepath))
        {
            string dataAsJson = JsonUtility.ToJson(bpf, isPrettyPrint);
            File.WriteAllText(filepath,dataAsJson);

        }
    }

    private void CreateNewJson()
    {
        filepath = "";
        bpf = new BlueprintFile();
    }

    private void LoadJsonData()
    {
        //使用文件系统打开Json
        filepath = EditorUtility.OpenFilePanel("选择Json文件", Application.streamingAssetsPath,"json");
        if (!string.IsNullOrEmpty(filepath))
        {
            string dataAsJson = File.ReadAllText(filepath);
           /// Debug.Log(JsonUtility.FromJson<Blueprint>(dataAsJson));
            bpf = JsonUtility.FromJson<BlueprintFile>(dataAsJson);
        }
    }
}
