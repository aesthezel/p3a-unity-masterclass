using System.Collections.Generic;
using Constants;
using Operators.Models;
using UnityEngine;

namespace Operators
{
    public class CursorOperator : MonoBehaviour
    {
        [SerializeField] 
        private GameCursor[] gameCursors;
        private Dictionary<CursorType, Texture2D> _cursors = new(); // Cache

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.None;
            ChangeGameCursor(CursorType.Normal);

            foreach (var gameCursor in gameCursors)
            {
                _cursors.TryAdd(gameCursor.Type, gameCursor.Texture);
            }
        }

        public void 
            ChangeGameCursor(CursorType cursorType)
        {
            // var foundCursor = Array.Find(gameCursors, cursor => cursor.Type == cursorType);
            // if (foundCursor == null) return;

            if (!_cursors.TryGetValue(cursorType, out var texture)) return; // O(1)
            Vector2 hotspot = new Vector2(texture.width / 2, texture.height / 2);
            Cursor.SetCursor(texture, hotspot, CursorMode.Auto);
        }
    }
}