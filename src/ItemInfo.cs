using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace OneTrilliumGames.Core.Items
{
    [
        CreateAssetMenu
        (
            fileName = "ItemInfo"
          , menuName = "One Trillium Games/Inventory/Item Info"
        )
    ]
    public class ItemInfo
        : ScriptableObject
    {
        [BoxGroup("Item Info")]

        [HorizontalGroup("Item Info/Description", 80)]
        [PreviewField(80)]
        [HideLabel]
        [SerializeField]
        protected Sprite icon;
        public Sprite Icon => this.icon;

        [VerticalGroup("Item Info/Description/Data")]
        [LabelWidth(80)]
        [SerializeField]
        protected string itemName;
        public string ItemName => this.itemName;

        [VerticalGroup("Item Info/Description/Data")]
        [LabelWidth(80)]
        [TextArea]
        [SerializeField]
        protected string description;
        public string Description => this.description;

        [BoxGroup("Game Data")]
        [LabelWidth(100)]
        [SerializeField]
        protected GameObject modelPrefab;
        public GameObject ModelPrefab => this.modelPrefab;

        [BoxGroup("Game Data")]
        [LabelWidth(80)]
        [SerializeField]
        protected string price;
        public string Price => this.price;

        [BoxGroup("Game Data")]
        [PropertySpace(SpaceBefore = 0, SpaceAfter = 10)]
        [SerializeField]
        protected List<string> categories;
        public List<string> Categories => this.categories;
    }
}
