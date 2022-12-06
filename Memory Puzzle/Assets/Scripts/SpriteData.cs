using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryPuzzle.Base
{

    [CreateAssetMenu(menuName = "Sprite/List")]
    public class SpriteData : ScriptableObject
    {
        [SerializeField] int _spriteId;

        public int SpriteId { get => _spriteId; }
    }

}
