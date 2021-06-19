using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MarioLand.Items.Armor.MarioBros
{
    [AutoloadEquip(EquipType.Head)]
    public class LuigiAHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Luigi's Cap");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 0;
            item.rare = ItemRarityID.Green;
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
            player.setBonus = "HP and Defense up";

            player.AddBuff(mod.BuffType("LuigiBuff"), 1);

            player.statLifeMax2 += 10;
            player.statDefense += 4;
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