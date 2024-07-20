using Game.Selectables;
using UnityEngine;

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
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (!hit.transform.TryGetComponent<SelectableEntity>(out var selection))
                {
                    if (_lastSelection != null)
                    {
                        cursorOperator.ChangeCursor(_lastSelection.IsSelected ? CursorType.ZoomOut : CursorType.Normal);
                        
                        if (!Input.GetMouseButtonDown(MOUSE_RIGHT_BUTTON)) return;
                        _lastSelection.UnSelect();
                    }
                    else
                    {
                        cursorOperator.ChangeCursor(CursorType.Normal);
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
                        cursorOperator.ChangeCursor(CursorType.ZoomOut);
                    }
                }
                
                if (!selection.IsAllowed)
                {
                    cursorOperator.ChangeCursor(CursorType.NotAllowed);
                    return;
                }
                
                if (selection.CanInteractable)
                {
                    cursorOperator.ChangeCursor(CursorType.Interact);
                }
                else
                {
                    cursorOperator.ChangeCursor(selection.IsSelected ? CursorType.ZoomOut : CursorType.ZoomIn);
                }
                
                if (Input.GetMouseButtonDown(MOUSE_LEFT_BUTTON))
                {
                    selection.Select();
                }
            }
        }
    }
}
