using System;
using Constants;
using Operators.Models;
using UnityEngine;

namespace Operators
{
    public class CursorOperator : MonoBehaviour
    {
        [SerializeField] 
        private GameCursor[] gameCursors;
    
        private void Awake() // Metodo si es obligatorio o perteneciente a Unity
        {
            Cursor.lockState = CursorLockMode.Confined;
            ChangeGameCursor(CursorType.Normal); // Metodo personalizado
        }

        public void ChangeGameCursor(CursorType cursorType)
        {
            var foundCursor = Array.Find(gameCursors, cursor => cursor.Type == cursorType);
            if (foundCursor == null) return;
        
            Vector2 hotspot = new Vector2(foundCursor.Texture.width / 2, foundCursor.Texture.height / 2);
            Cursor.SetCursor(foundCursor.Texture, hotspot, CursorMode.Auto);
        }
    }
}