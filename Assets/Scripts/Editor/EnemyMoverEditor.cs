using Enemy;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(EnemyMover), true)]
    public class EnemyMoverEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var enemyMover = (EnemyMover) target;

            if (GUILayout.Button("Set settings"))
            {
                enemyMover.SetMoveSettings();
            }
        }
    }
}