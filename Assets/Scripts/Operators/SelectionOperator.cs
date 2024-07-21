using Game.Selectables;
using UnityEngine;
using Game.Constants;

namespace Game.Operators
{
    public class SelectionOperator : MonoBehaviour
    {
        [SerializeField] 
        private string tagToFilter;
        [SerializeField]
        private CursorOperator cursorOperator;

        private const int MOUSE_LEFT_BUTTON = 0;
        private const int MOUSE_RIGHT_BUTTON = 1;

        private SelectableEntity _lastSelection;
    
        private void Update()
        {
            // Se ubica un rayo en el centro de la camara en relacion al mouse
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (!hit.transform.TryGetComponent<SelectableEntity>(out var selection))
                {
                    if (_lastSelection != null)
                    {
                        cursorOperator.ChangeGameCursor(_lastSelection.IsSelected ? CursorType.ZoomOut : CursorType.Normal);
                        
                        if (!Input.GetMouseButtonDown(MOUSE_RIGHT_BUTTON)) return;
                        _lastSelection.UnSelect();
                    }
                    else
                    {
                        cursorOperator.ChangeGameCursor(CursorType.Normal);
                    }
                    
                    return;
                }
                
                if (selection.CompareTag(tagToFilter))
                {
                    _lastSelection = selection;
                }
                else
                {
                    if (_lastSelection.IsSelected)
                    {
                        cursorOperator.ChangeGameCursor(CursorType.ZoomOut);
                    }
                }
                
                if (!selection.IsAllowed)
                {
                    cursorOperator.ChangeGameCursor(CursorType.NotAllowed);
                    return;
                }
                
                if (selection.CanInteractable)
                {
                    cursorOperator.ChangeGameCursor(CursorType.Interact);
                }
                else
                {
                    cursorOperator.ChangeGameCursor(selection.IsSelected ? CursorType.ZoomOut : CursorType.ZoomIn);
                }
                
                if (Input.GetMouseButtonDown(MOUSE_LEFT_BUTTON))
                {
                    selection.Select();
                }
            }
        }
    }
}
