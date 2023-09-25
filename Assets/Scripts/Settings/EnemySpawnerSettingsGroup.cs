using System.Collections.Generic;
using System.Globalization;
using Enemy;
using UnityEditor;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "EnemySpawnerSettingsGroup", menuName = "ObjectSettings/EnemySpawnerSettingsGroup")]
    public class EnemySpawnerSettingsGroup : ScriptableObject
    {
        [SerializeField] private TextAsset _textAsset;
    
        [ContextMenuItem("Parse", nameof(Parse))]
        [ContextMenuItem("Clear", nameof(Clear))]
        [SerializeField] private List<EnemySpawnerSettings> _enemySpawnerSettingsList;

        public List<EnemySpawnerSettings> EnemySpawnerSettingsList
        {
            get => _enemySpawnerSettingsList;
            set => _enemySpawnerSettingsList = value;
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
                var firstSpawnDelay = float.Parse(columns[1], CultureInfo.InvariantCulture);
                var spawnDelay = float.Parse(columns[2], CultureInfo.InvariantCulture);
            
                AddObject(spawnerName:columns[0],
                    firstSpawnDelay:firstSpawnDelay,
                    spawnDelay:spawnDelay);
            }

            Debug.Log($"{typeof(EnemySpawnerSettingsGroup)} parsed successfully!");
        }

        private void AddObject(string spawnerName, float firstSpawnDelay, float spawnDelay)
        {
            EnemySpawnerSettings enemySpawnerSettings = CreateInstance<EnemySpawnerSettings>();
            enemySpawnerSettings.name = spawnerName + "SpawnerSettings";
            enemySpawnerSettings.Init(spawnerName, firstSpawnDelay, spawnDelay);
            EnemySpawnerSettingsList.Add(enemySpawnerSettings);
            
            AssetDatabase.AddObjectToAsset(enemySpawnerSettings, this);
            AssetDatabase.SaveAssets();
            
            EditorUtility.SetDirty(this);
            EditorUtility.SetDirty(enemySpawnerSettings);
        }

        private void Clear()
        {
            if (EnemySpawnerSettingsList == null) return;
            
            for (int i = EnemySpawnerSettingsList.Count - 1; i >= 0; i--)
            {
                Undo.DestroyObjectImmediate(EnemySpawnerSettingsList[i]);
                EnemySpawnerSettingsList.Remove(EnemySpawnerSettingsList[i]);
            }

            AssetDatabase.SaveAssets();
            EditorUtility.SetDirty(this);
            foreach (var item in EnemySpawnerSettingsList)
            {
                EditorUtility.SetDirty(item);
            }
        }

#endif

    }
}