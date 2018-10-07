using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MechDataEditor : EditorWindow 
{
    string jsonAsData;
    public MechArray mechArray;
    public MechData mechData;
    public ComponentLoadout componentLoadout;
    public string targetFile;
    Vector2 scrollPos;
    public int windowState;
    public string[] modes = new string[] { "Mech", "Equipment", "Mech Lists"};

    private string dataProjectFilePath = "/StreamingAssets/JSONs/";

    [MenuItem ("Window/Game Data Editor")]
    static void Init()
    {
        MechDataEditor window = (MechDataEditor)EditorWindow.GetWindow(typeof(MechDataEditor));
        window.Show () ;
    }

    void OnGUI()
    {
        windowState = EditorGUILayout.Popup(windowState, modes);
        SerializedObject serializedObject;
        SerializedProperty targetFileSerlialized;
        switch (windowState)
        {
            case 0:
                EditorGUILayout.BeginVertical();
                scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(Screen.width), GUILayout.Height(Screen.height));
                serializedObject = new SerializedObject(this);
                SerializedProperty mechdataSerialized = serializedObject.FindProperty("mechData");
                targetFileSerlialized = serializedObject.FindProperty("targetFile");

                EditorGUILayout.PropertyField(mechdataSerialized, true);
                EditorGUILayout.PropertyField(targetFileSerlialized, true);

                serializedObject.ApplyModifiedProperties();

                if (GUILayout.Button("saveData"))
                {
                    SaveData();
                }

                if (GUILayout.Button("loadData"))
                {
                    LoadData();
                }
                EditorGUILayout.EndVertical();
                EditorGUILayout.EndScrollView();
                break;
            case 1:
                EditorGUILayout.BeginVertical();
                scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(Screen.width), GUILayout.Height(Screen.height));
                serializedObject = new SerializedObject(this);
                SerializedProperty componentLoadoutSerialized = serializedObject.FindProperty("componentLoadout");
                targetFileSerlialized = serializedObject.FindProperty("targetFile");

                EditorGUILayout.PropertyField(componentLoadoutSerialized, true);
                EditorGUILayout.PropertyField(targetFileSerlialized, true);

                serializedObject.ApplyModifiedProperties();

                if (GUILayout.Button("saveData"))
                {
                    SaveData();
                }

                if (GUILayout.Button("loadData"))
                {
                    LoadData();
                }
                EditorGUILayout.EndVertical();
                EditorGUILayout.EndScrollView();
                break;
            case 2:
                EditorGUILayout.BeginVertical();
                scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(Screen.width), GUILayout.Height(Screen.height));
                serializedObject = new SerializedObject(this);
                SerializedProperty mechListSerialized = serializedObject.FindProperty("mechArray");
                targetFileSerlialized = serializedObject.FindProperty("targetFile");

                EditorGUILayout.PropertyField(mechListSerialized, true);
                EditorGUILayout.PropertyField(targetFileSerlialized, true);

                serializedObject.ApplyModifiedProperties();

                if (GUILayout.Button("Save Data"))
                {
                    SaveData();
                }

                if (GUILayout.Button("Load Data"))
                {
                    LoadData();
                }
                EditorGUILayout.EndVertical();
                EditorGUILayout.EndScrollView();
                break;
        }
    }

	void LoadData ()
	{
		string filePath = Application.dataPath + dataProjectFilePath + targetFile + (".json");

        if (File.Exists (filePath)) {
			string jsonAsData = File.ReadAllText (filePath);
            switch (windowState)
            {
                case 0:
                    mechData = JsonUtility.FromJson<MechData>(jsonAsData);
                    break;
                case 1:
                    componentLoadout = JsonUtility.FromJson<ComponentLoadout>(jsonAsData);
                    break;
                case 2:
                    mechArray = JsonUtility.FromJson<MechArray>(jsonAsData);
                    break;
            }
		}
        else
        {
            mechData = new MechData();
        }
	}

    void SaveData ()
    {
        switch (windowState)
        {
            case 0:
                jsonAsData = JsonUtility.ToJson(mechData);
                break;
            case 1:
                jsonAsData = JsonUtility.ToJson(componentLoadout);
                break;
            case 2:
                jsonAsData = JsonUtility.ToJson(mechArray);
                break;
        }
        string filePath = Application.dataPath + dataProjectFilePath + targetFile + (".json");
        File.WriteAllText(filePath, jsonAsData);
    }
}
