using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MarioLand.Items.Powerups
{
	public class FireFlower1 : ModItem
	{

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Orange;
		}

		public override bool? PrefixChance(int pre, UnifiedRandom rand)
		{
			if (pre == -3 || pre == -1) return false;
			return base.AllowPrefix(pre);
		}
	}
}