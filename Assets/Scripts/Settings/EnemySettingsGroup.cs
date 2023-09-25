using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "EnemySettingsGroup", menuName = "ObjectSettings/EnemySettingsGroup")]
    public class EnemySettingsGroup : ScriptableObject
    {
        [SerializeField] private TextAsset _textAsset;
    
        [ContextMenuItem("Parse", nameof(Parse))]
        [SerializeField] private List<EnemySettings> _enemySettingsList;

        public List<EnemySettings> EnemySettingsList
        {
            get => _enemySettingsList;
            set => _enemySettingsList = value;
        }

#if UNITY_EDITOR
    
        public void Parse()
        {
            Clear();
        
            string[] rows = _textAsset.text.Split("\n");

            for (int i = 1; i < rows.Length; i++)
            {
                if (rows[i].Length < 1) break;
                string[] columns = rows[i].Split(",");
                var moveSpeed = float.Parse(columns[1], CultureInfo.InvariantCulture);
                uint.TryParse(columns[2], out uint movePointsNumber);
            
                AddObject(enemyName:columns[0],
                    moveSpeed:moveSpeed,
                    movePointsNumber:movePointsNumber);
            }

            Debug.Log($"{typeof(EnemySettingsGroup)} parsed successfully!");
        }

        private void Clear()
        {
            if (EnemySettingsList == null) return;
            
            for (int i = EnemySettingsList.Count - 1; i >= 0; i--)
            {
                Undo.DestroyObjectImmediate(EnemySettingsList[i]);
                EnemySettingsList.Remove(EnemySettingsList[i]);
            }

            AssetDatabase.SaveAssets();
            EditorUtility.SetDirty(this);
            foreach (var item in EnemySettingsList)
            {
                EditorUtility.SetDirty(item);
            }
        }

        private void AddObject(string enemyName, float moveSpeed, uint movePointsNumber)
        {
            EnemySettings enemySettings = CreateInstance<EnemySettings>();
            enemySettings.name = enemyName + "Settings";
            enemySettings.Init(enemyName, moveSpeed, movePointsNumber);
            EnemySettingsList.Add(enemySettings);
            
            AssetDatabase.AddObjectToAsset(enemySettings, this);
            AssetDatabase.SaveAssets();
            
            EditorUtility.SetDirty(this);
            EditorUtility.SetDirty(enemySettings);
        }
    
#endif

    }
}