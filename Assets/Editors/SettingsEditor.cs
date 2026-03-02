using UnityEngine;
using UnityEditor;

public class AutoSettingsWindow : EditorWindow
{
    private GameSettings gameSettings;
    private SerializedObject serializedObject;
    private Vector2 scrollPosition;
    
    [MenuItem("Tools/Settings Editor")]
    public static void ShowWindow()
    {
        GetWindow<AutoSettingsWindow>("Settings Editor");
    }
    
    private void OnEnable()
    {
        // Автоматически ищем GameSettings при открытии окна
        FindGameSettings();
    }
    
    private void FindGameSettings()
    {
        // Поиск всех GameSettings в проекте
        string[] guids = AssetDatabase.FindAssets("t:GameSettings");
        
        if (guids.Length == 0)
        {
            Debug.LogWarning("No Game Settings found!");
            return;
        }
        
        // Берем первый найденный
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        gameSettings = AssetDatabase.LoadAssetAtPath<GameSettings>(path);
        
        if (gameSettings != null)
        {
            serializedObject = new SerializedObject(gameSettings);
        }
    }
    
    private void OnGUI()
    {
        if (gameSettings == null)
        {
            EditorGUILayout.HelpBox("No Game Settings found!", MessageType.Error);
            return;
        }
        
        if (serializedObject == null)
        {
            serializedObject = new SerializedObject(gameSettings);
        }
        
        serializedObject.Update();
        
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        
        SerializedProperty property = serializedObject.GetIterator();
        bool enterChildren = true;
        
        while (property.NextVisible(enterChildren))
        {
            enterChildren = false;
            if (property.name != "m_Script")
            {
                EditorGUILayout.PropertyField(property, true);
            }
        }
        
        EditorGUILayout.EndScrollView();
        
        if (serializedObject.hasModifiedProperties)
        {
            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(gameSettings);
        }
    }
}