using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MarioLand.Items.CharacterEquips.Mario
{
    public class MariosCap : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mario's Cap");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 20;
            item.rare = ItemRarityID.Red;
        }

        public override bool? PrefixChance(int pre, UnifiedRandom rand)
        {
            if (pre == -3 || pre == -1) return false;
            return base.AllowPrefix(pre);
        }

        public class MarioHead : EquipTexture
        {
            public override bool DrawHead()
            {
                return false;
            }
        }

        public class MarioBody : EquipTexture
        {
            public override bool DrawBody()
            {
                return false;
            }
        }

        public class MarioLegs : EquipTexture
        {
            public override bool DrawLegs()
            {
                return false;
            }
        }
    }
}