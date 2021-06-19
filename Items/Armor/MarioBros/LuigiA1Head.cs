using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MarioLand.Items.Armor.MarioBros
{
    [AutoloadEquip(EquipType.Head)]
    public class LuigiA1Head : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Luigi's Cap +1");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 0;
            item.rare = ItemRarityID.Green;
        }

        public override void UpdateEquip(Player player)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            mp.PowerUp1 = true;

            player.setBonus = "HP and Defense up\n" +
                              "Powered up!";

            player.AddBuff(mod.BuffType("LuigiBuff"), 1);

            player.statLifeMax2 += 15;
            player.statDefense  += 8;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("LuigiAHead"));
            recipe.AddIngredient(ItemID.DemoniteBar, 1);
            recipe.AddIngredient(ItemID.ShadowScale, 1);
            recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddIngredient(ItemID.FallenStar, 3);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("LuigiAHead"));
            recipe.AddIngredient(ItemID.CrimtaneBar, 1);
            recipe.AddIngredient(ItemID.TissueSample, 1);
            recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddIngredient(ItemID.FallenStar, 3);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}