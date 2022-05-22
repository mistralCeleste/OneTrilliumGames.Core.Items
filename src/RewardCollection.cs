using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace OneTrilliumGames.Core.Items
{
    [Serializable]
    public class RewardCollection
    {
        [SerializeField]
        [TableList]
        protected List<RewardStack> items;
        public List<RewardStack> Items => this.items;

        public RewardCollection()
        {
            this.items = new List<RewardStack>();
        }

        public RewardCollection(int count)
        {
            this.items = new List<RewardStack>(count);
        }

        public RewardCollection(IEnumerable<RewardStack> rewardStack)
        {
            this.items = new List<RewardStack>(rewardStack);
        }

        public List<ItemStack> ConsolidateStacks()
        {
            var consolidated = this.items
                .GroupBy(rewardStack => rewardStack.item)
                .Select(
                    grouping => new ItemStack
                    {
                        item = grouping.First().item
                        , quantity = grouping.Sum(rewardStack => rewardStack.EvaluateQuantity())
                    }
                )
                .Where(itemStack => itemStack.item && itemStack.quantity > 0)
                .ToList();

            return consolidated;
        }
    }
}
