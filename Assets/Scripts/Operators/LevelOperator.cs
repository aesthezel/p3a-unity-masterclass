using System.Collections.Generic;
using Game.Operators;
using UnityEngine;

namespace Game.Operators
{
    public class LevelOperator : MonoBehaviour
    {
        [SerializeField] 
        private CursorOperator cursorOperator;
        [SerializeField] 
        private List<SelectionOperator> selectionOperators;

        private void LinkSelectionOperator(SelectionOperator selection)
        {
            if (selectionOperators.Contains(selection)) return;
        
        
            selectionOperators.Add(selection);
        }
    }
}
