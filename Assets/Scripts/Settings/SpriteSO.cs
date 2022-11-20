// <auto-generated> to shut up linter
using UnityEngine;
using UnityEngine.Events;

namespace ArcCreate
{
    [CreateAssetMenu(fileName = "String", menuName = "ScriptableObject/String")]
    public class SpriteSO : ScriptableObject
    {
        private Sprite value;
        public Sprite Value 
        {
            get => value;
            set
            {
                this.value = value;
                OnValueChange.Invoke(value);
            }
        }

        public OnChangeEvent OnValueChange { get; set; }

        public class OnChangeEvent : UnityEvent<Sprite>
        {
        }
    }
}