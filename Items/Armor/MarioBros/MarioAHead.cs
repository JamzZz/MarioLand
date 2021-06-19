using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MarioLand.Items.Armor.MarioBros
{
    [AutoloadEquip(EquipType.Head)]
    public class MarioAHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Mario's Cap");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 0;
            item.rare = ItemRarityID.Red;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.CreeperShirt && legs.type == ItemID.FishCostumeFinskirt;
        }

        public override void UpdateArmorSet(Player player)
        {
            if (player.name == "VaniIIiyan")
            {
                player.setBonus = "Oh, you sneaky...";

                MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
                mp.Dev = true;
            }
        }

        public override void UpdateEquip(Player player)
        {
            player.setBonus = "Melee damage and Melee speed up";

            player.AddBuff(mod.BuffType("MarioBuff"), 1);

            player.meleeDamage += 0.05f;
            player.meleeSpeed  += 0.05f;
            player.statDefense += 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddIngredient(ItemID.Mushroom, 3);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}