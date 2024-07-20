using UnityEngine;

namespace Game.Selectables
{
    public abstract class SelectableEntity : MonoBehaviour
    {

        [field: SerializeField]
        public bool IsAllowed { get; protected set; }
        [field: SerializeField]
        public bool IsSelected { get; protected set; }
        
        [field: SerializeField]
        public bool CanInteractable { get; protected set; }

        public abstract void Select();
        public abstract void UnSelect();
    }
}