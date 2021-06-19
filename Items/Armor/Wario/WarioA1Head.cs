using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MarioLand.Items.Armor.Wario
{
    [AutoloadEquip(EquipType.Head)]
    public class WarioA1Head : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Wario's Cap +1");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 0;
            item.rare = 8;
            item.defense = 3;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("WarioBody") && legs.type == mod.ItemType("WarioLegs");
        }

        public override void UpdateArmorSet(Player player)
        {
            WarioPlayer wp = player.GetModPlayer<WarioPlayer>();
            wp.PowerUp1 = true;

            player.setBonus = "HP, Melee damage \nand Defense up\n" +
                "Powered up!";

            player.AddBuff(mod.BuffType("WarioBuff"), 1);

            player.statLifeMax2 += 15;
            player.meleeDamage  += 0.15f;
            player.statDefense  += 8;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("WarioAHead"));
            recipe.AddIngredient(ItemID.DemoniteBar, 1);
            recipe.AddIngredient(ItemID.ShadowScale, 1);
            recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddIngredient(ItemID.FallenStar, 3);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("WarioAHead"));
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