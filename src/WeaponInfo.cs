using System.Collections.Generic;
using OneTrilliumGames.Core.Attributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace OneTrilliumGames.Core.Items
{
    [
        CreateAssetMenu
        (
            fileName = "WeaponInfo"
            , menuName = "One Trillium Games/Inventory/Equipment/Weapon Info"
        )
    ]
    [InlineEditor]
    public class WeaponInfo
        : EquipmentInfo
    {
        protected static readonly List<AttributeModifier> DefaultModifiers = new()
        {
            new AttributeModifier
            {
                attributeType = AttributeType.Attack
                , modifierType = AttributeModifierType.Value
                , value = 0
            }
        };

        public WeaponInfo()
        {
            this.equipmentType = EquipmentType.Weapon;
            this.modifiers.AddRange(DefaultModifiers);
        }
    }
}