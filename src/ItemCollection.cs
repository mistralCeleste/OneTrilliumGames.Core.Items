using System.Collections.Generic;
using System.Linq;
using OneTrilliumGames.Core.UI.Notifications.Rewards;
using Sirenix.OdinInspector;
using UnityEngine;

namespace OneTrilliumGames.Core.Items
{
    public class ItemCollection
        : MonoBehaviour
    {
        [SerializeField]
        [TableList]
        protected List<ItemStack> itemStacks;
        public List<ItemStack> ItemStacks => this.itemStacks;

        [SerializeField]
        protected RewardsPanel rewardsPanel;

        public void Merge(ItemCollection collection)
        {
            foreach (var stack in collection.ItemStacks)
            {
                this.Merge(stack);
            }
        }

        public void GiveTo(GameObject recipient)
        {
            if (this.itemStacks.Count <= 0)
            {
                return;
            }

            var recipientContainer = recipient.GetComponent<ItemCollection>();

            if (recipientContainer != null)
            {
                recipientContainer.Merge(this);
            }

            this.rewardsPanel.Show(this.itemStacks);
            this.itemStacks.Clear();
        }

        public void Merge(ItemStack stack)
        {
            if (stack.quantity <= 0)
            {
                return;
            }

            foreach (var entry in this.itemStacks)
            {
                if (entry.item == stack.item)
                {
                    entry.quantity += stack.quantity;
                    return;
                }
            }

            var copy = stack.GetCopyOf();
            this.itemStacks.Add(copy);
        }

        public void Remove(ItemInfo item)
        {
            for (var index = 0; index < this.itemStacks.Count(); index++)
            {
                if (this.itemStacks[index].item == item)
                {
                    var stack = this.itemStacks[index];
                    stack.quantity -= 1;

                    if (stack.quantity <= 0)
                    {
                        this.itemStacks.RemoveAt(index);
                    }

                    return;
                }
            }
        }

        public bool ContainsSameItem(ItemStack stack)
        {
            return this.itemStacks.Any(stackedItem => stackedItem.item == stack.item);
        }

        public void Consolidate()
        {
            var consolidated = this.itemStacks
                .GroupBy(itemStack => itemStack.item)
                .Select(grouping => new ItemStack
                    {
                        item = grouping.First().item
                        , quantity = grouping.Sum(itemStack => itemStack.quantity)
                    }
                );

            this.itemStacks = new List<ItemStack>(consolidated);
        }
    }
}
