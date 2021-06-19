using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MarioLand.Items.Weapons
{
	public class HammerSuitHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Suit Hammer");
			Tooltip.SetDefault("Can be used while wearing the Hammer Suit");
	    }
		
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			
			item.useStyle = 1;
			item.useTime = 20;
			item.useAnimation = 20;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/fireball");

            item.damage = 35;
			item.maxStack = 1;
			item.knockBack = 2;
			item.shootSpeed = 10f;
			item.shoot = mod.ProjectileType("HammerSuitHammer");

			item.rare = 3;
			item.value = 1000;

			item.thrown = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.consumable = false;
			item.noUseGraphic = true;
		}

        public override bool CanUseItem(Player player)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            if (mp.Hammer && mp.MarioChar)
            {
                return true;
            }
            return false;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            Vector2 direction = new Vector2(speedX, speedY);
            speedX = ((player.direction * 2.5f) + (player.velocity.X *1.5f));
            speedY = -6f + (player.velocity.Y * 0.2f);
            direction.Normalize();
            position += direction * item.width;
            return true;
        }
    }
}