using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace OneTrilliumGames.Core.Items
{
    [Serializable]
    public class ItemStack
    {
        [SerializeField]
        [TableColumnWidth(120)]
        public ItemInfo item;

        [SerializeField]
        [TableColumnWidth(30)]
        public int quantity = 1;

        public bool StackHasSameItem(ItemStack stack)
        {
            var hasSameItem = this.item.ItemName == stack.item.ItemName;
            return hasSameItem;
        }

        public ItemStack GetCopyOf()
        {
            var stack = new ItemStack {quantity = this.quantity, item = this.item};
            return stack;
        }
    }
}