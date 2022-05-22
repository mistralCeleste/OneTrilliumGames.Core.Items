using System.Collections.Generic;
using OneTrilliumGames.Core.Attributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace OneTrilliumGames.Core.Items
{
    [InlineEditor]
    public class EquipmentInfo
        : ItemInfo
    {
        [BoxGroup("Weapon Data")]
        [SerializeField]
        protected float level = CharacterAttributes.MinLevel;
        public float Level => this.level;

        [BoxGroup("Weapon Data")]
        [SerializeField]
        protected EquipmentType equipmentType;
        public EquipmentType EquipmentType => this.equipmentType;

        [BoxGroup("Weapon Data")]
        [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
        [TableList]
        [SerializeField]
        protected List<AttributeModifier> modifiers = new();
        public List<AttributeModifier> Modifiers => this.modifiers;
    }
}
