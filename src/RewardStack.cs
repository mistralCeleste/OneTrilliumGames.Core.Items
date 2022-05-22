using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace OneTrilliumGames.Core.Items
{
    [Serializable]
    public class RewardStack
        : ItemStack
    {
        [SerializeField]
        [Range(0, 1)]
        [TableColumnWidth(100)]
        public float chance = 1f;

        public int EvaluateQuantity()
        {
            var evaluation = UnityEngine.Random.value;

            var evaluatedQuantity = evaluation < this.chance 
                    ? this.quantity
                    : 0;

            return evaluatedQuantity;
        }
    }
}