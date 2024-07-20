using System;
using UnityEngine;

namespace Game.Operators
{
    public class CursorOperator : MonoBehaviour
    {
        [SerializeField] 
        private GameCursor[] gameCursors;
    
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Confined;
            ChangeCursor(CursorType.Normal);
        }

        public void ChangeCursor(CursorType cursorType)
        {
            var foundCursor = Array.Find(gameCursors, cursor => cursor.Type == cursorType);
            if (foundCursor == null) return;
        
            Vector2 hotspot = new Vector2(foundCursor.Texture.width / 2, foundCursor.Texture.height / 2);
            Cursor.SetCursor(foundCursor.Texture, hotspot, CursorMode.Auto);
        }
    }

    [Serializable]
    public class GameCursor
    {
        public Texture2D Texture;
        public CursorType Type;
    }

    public enum CursorType
    {
        Normal,
        ZoomIn,
        ZoomOut,
        Interact,
        NotAllowed,
        Wait
    }
}