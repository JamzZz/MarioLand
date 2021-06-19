using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MarioLand.Items.Accessories
{
    // Code obtained from tModLoader/ExclusiveAccessory

    public abstract class MarioAccessories : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.accessory = true;
        }

        public override bool CanEquipAccessory(Player player, int slot)
        {
            // To prevent the accessory from being equipped, we need to return false if there is one already in another slot
            // Therefore we go through each accessory slot ignoring vanity slots using FindDifferentEquippedExclusiveAccessory()
            // which we declared in this class below
            if (slot < 10) // This allows the accessory to equip in vanity slots with no reservations
            {
                // Here we use named ValueTuples and retrieve the index of the item, since this is what we need here
                int index = FindDifferentEquippedExclusiveAccessory().index;
                if (index != -1)
                {
                    return slot == index;
                }
            }
            // Here we want to respect individual items having custom conditions for equipability
            return base.CanEquipAccessory(player, slot);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we want to add a tooltip to the item if it can be swapped with another one of its kind
            // Therefore we retrieve the accessory from the ValueTuple, because the index isn't needed here
            Item accessory = FindDifferentEquippedExclusiveAccessory().accessory;
            if (accessory != null)
            {
                tooltips.Add(new TooltipLine(mod, "Swap", "Right-click to swap with the " + accessory.Name + "!")
                {
                    overrideColor = Color.DeepSkyBlue
                });
            }
        }

        public override bool CanRightClick()
        {
            // An intricacy of vanilla is that it directly swaps the items on right click if the items are the same and just their prefixes differ,
            // even in vanity slots. For this, FindDifferentEquippedExclusiveAccessory() doesn't find these items
            // That means, if for whatever reason you have Green equipped, Yellow in a vanity slot, and then right click a Yellow item in your inventory
            // that has a different prefix than the vanity Yellow, it will swap with the vanity Yellow instead of the equipped Green
            // Therefore we need to reimplement this behavior by doing the following check

            // Check vanity accessory slots for the same item type equipped and return false (so vanilla handles it)
            int maxAccessoryIndex = 5 + Main.LocalPlayer.extraAccessorySlots;
            for (int i = 13; i < 13 + maxAccessoryIndex; i++)
            {
                if (Main.LocalPlayer.armor[i].type == item.type) return false;
            }

            // Only allow right clicking if there is a different ExclusiveAccessory equipped
            if (FindDifferentEquippedExclusiveAccessory().accessory != null)
            {
                return true;
            }
            // If this hook returns true, the item is consumed (just like crates and boss bags)
            return base.CanRightClick();
        }

        public override void RightClick(Player player)
        {
            // Here we implement the "swapping" when right clicked to equip this item inplace of another one
            // Because we need both index and accessory, we "unpack" this ValueTuple like this:
            var (index, accessory) = FindDifferentEquippedExclusiveAccessory();
            if (accessory != null)
            {
                Main.LocalPlayer.QuickSpawnClonedItem(accessory);
                // We need to use index instead of accessory because we directly want to alter the equipped accessory
                Main.LocalPlayer.armor[index] = item.Clone();
            }
        }

        // We make our own method for compacting the code because we will need to check equipped accessories often
        // This method returns a named ValueTuple, indicated by the (Type name1, Type name2, ...) as the return type
        // This allows us to return more than one value from a method
        protected (int index, Item accessory) FindDifferentEquippedExclusiveAccessory()
        {
            int maxAccessoryIndex = 5 + Main.LocalPlayer.extraAccessorySlots;
            for (int i = 3; i < 3 + maxAccessoryIndex; i++)
            {
                Item otherAccessory = Main.LocalPlayer.armor[i];
                // IsAir makes sure we don't check for "empty" slots
                // IsTheSameAs() compares two items and returns true if their types match
                // "is ExclusiveAccessory" is a way of performing pattern matching
                // Here, inheritance helps us determine if the given item is indeed one of our ExclusiveAccessory ones
                if (!otherAccessory.IsAir &&
                    !item.IsTheSameAs(otherAccessory) &&
                    otherAccessory.modItem is MarioAccessories)
                {
                    // If we find an item that matches these criteria, return both the index and the item itself
                    // The second argument is just for convenience, technically we don't need it since we can get the item from just i
                    return (i, otherAccessory);
                }
            }
            // If no item is found, we return default values for index and item, always check one of them with this default when you call this method!
            return (-1, null);
        }
    }

    // Here we add our accessories, note that they inherit from ExclusiveAccessory, and not ModItem

    public class FireFlower : MarioAccessories
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Makes Mario and Luigi able to burn enemies");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.rare = ItemRarityID.Yellow;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            mp.Fire = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Daybloom, 5);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class IceFlower : MarioAccessories
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Makes Mario and Luigi able to frostburn enemies");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.rare = ItemRarityID.Lime;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            mp.Ice = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Shiverthorn, 5);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    [AutoloadEquip(EquipType.Wings)]
    public class SuperLeaf : MarioAccessories
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Makes Mario and Luigi fly for a bit.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            mp.Leaf = true;

            if (player.velocity.X >= 3.4f || player.velocity.X <= -3.4f)
            {
                player.wingTimeMax = 30;
            }
        }

        public override bool WingUpdate(Player player, bool inUse)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            if (inUse)
            {
                player.flapSound = true;
            }

            if ((player.wingFrame == 3 && (mp.Mario || mp.Luigi)) && !player.wet)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/tail_cape_spin"));
            }
            return false;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.5f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 0.5f;
            maxAscentMultiplier = 1f;
            constantAscend = 1f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            if (mp.Mario || mp.Luigi)
            {
                speed = 5f;
                acceleration *= 1.5f;
            }
            if (!mp.Mario && !mp.Luigi)
            {
                player.wingsLogic = 0;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 3);
            recipe.AddTile(TileID.Trees);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    [AutoloadEquip(EquipType.Wings)]
    public class TanookiSuit : MarioAccessories
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Makes Mario and Luigi fly for a while.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            mp.Tanooki = true;

            if (player.velocity.X >= 3.4f || player.velocity.X <= -3.4f)
            {
                player.wingTimeMax = 150;
            }
        }

        public override bool WingUpdate(Player player, bool inUse)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            if (inUse)
            {
                player.flapSound = true;
            }

            if ((player.wingFrame == 3 && (mp.Mario || mp.Luigi)) && !player.wet)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/tail_cape_spin"));
            }
            return false;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.6f;
            ascentWhenRising = 0.25f;
            maxCanAscendMultiplier = 0.6f;
            maxAscentMultiplier = 1.1f;
            constantAscend = 1.1f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            if (mp.Mario || mp.Luigi)
            {
                speed = 5f;
                acceleration *= 1.5f;
            }
            if (!mp.Mario && !mp.Luigi)
            {
                player.wingsLogic = 0;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SuperLeaf"));
            recipe.AddIngredient(ItemID.SoulofFlight, 20);
            recipe.AddIngredient(ItemID.FallenStar, 3);
            recipe.AddTile(TileID.Trees);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class FrogSuit : MarioAccessories
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Boosts Mario and Luigi's abilities underwater.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.rare = ItemRarityID.Pink;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            mp.Frog = true;
            player.accDivingHelm = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Flipper, 1);
            recipe.AddIngredient(ItemID.FrogLeg, 1);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.FrogCage);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class HammerSuit : MarioAccessories
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Improves Mario and Luigi's throwing damage and defense");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.rare = ItemRarityID.Orange;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            mp.Hammer = true;
        }
    }

    [AutoloadEquip(EquipType.Wings)]
    public class CapeFeather : MarioAccessories
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Makes Mario and Luigi fly for a long time.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            mp.Cape = true;

            for (int i = 0; i < 100; i++)
            {
                if (player.velocity.X >= 3.5f || player.velocity.X <= -3.5f)
                {
                    player.wingTimeMax = 100;
                }
                if (player.velocity.Y > 5.5f && (player.velocity.X > 4f || player.velocity.X < -4f))
                {
                    player.wingTime = (0.125f * i);
                }
            }
        }

        public override bool WingUpdate(Player player, bool inUse)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            if (inUse)
            {
                player.flapSound = true;
            }

            if ((player.wingFrame == 3 && mp.MarioChar) && !player.wet && player.wingTime < 10 && (player.velocity.X > 4f || player.velocity.X < -4f))
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/smw_cape_rise"));
            }
            return false;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 3f;
            ascentWhenRising = 3f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 1f;
            constantAscend = 1f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            if (mp.MarioChar)
            {
                speed = 8f;
                acceleration *= 3f;
            }
            if (!mp.MarioChar || player.controlUseItem)
            {
                player.wingsLogic = 0;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GiantHarpyFeather, 1);
            recipe.AddIngredient(ItemID.SoulofFlight, 20);
            recipe.AddIngredient(ItemID.FallenStar, 3);
            recipe.AddTile(TileID.Trees);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class Carrot : MarioAccessories
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Lets Mario jump higher and descent slower");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.rare = ItemRarityID.Orange;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            if (mp.Mario == true)
            {
                mp.Carrot = true;
                player.jumpSpeedBoost += 1f;
                player.autoJump = true;

                if (!player.releaseJump)
                {
                    player.maxFallSpeed += -9.5f;
                }

                if (player.velocity.X > 1.5 || player.velocity.X < -1.5)
                {
                    player.jumpSpeedBoost -= 0.5f;
                }
            }
        }
                
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 3);
            recipe.AddTile(TileID.Trees);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class BuilderHat : MarioAccessories
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases Mario and Luigi's tile and wall placement speed and reach\n");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.rare = ItemRarityID.Lime;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            mp.Builder = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MiningHelmet, 1);
            recipe.AddIngredient(ItemID.FallenStar, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

//  WARIO

    [AutoloadEquip(EquipType.Wings)]
    public class JetPot : MarioAccessories
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Improves Wario's speed, jump height and grants flight!\n");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.rare = ItemRarityID.LightPurple;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            WarioPlayer wp = player.GetModPlayer<WarioPlayer>();
            if (wp.Wario)
            {
                wp.Jet = true;

                if (!player.wet)
                {
                    player.maxRunSpeed += 1f;
                    Player.jumpHeight += 6;
                    Player.jumpSpeed += 2;

                    player.wingTimeMax = 150;
                }
            }
        }

        public override bool WingUpdate(Player player, bool inUse)
        {
            if (inUse)
            {
                player.flapSound = true;
            }

            return false;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 1f;        // changing to 0 causes character to not be able to float, even with wingTime left.
            ascentWhenRising = 1f;         // Unsure
            maxCanAscendMultiplier = 1f;   // Unsure
            maxAscentMultiplier = -0.001f; // Height when flying, 0 is a mess, so always a bit above/below.
            constantAscend = 1f;           // Unsure
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            WarioPlayer wp = player.GetModPlayer<WarioPlayer>();

            if (wp.Wario)
            {
                speed = 6f;
                acceleration *= 4f;

                if (!player.wet)
                {

                    //If the dash is not active, immediately return so we don't do any of the logic for it
                    if (!wp.DashActive)
                    {
                        return;
                    }

                    //If the dash has just started, apply the dash velocity in whatever direction we wanted to dash towards
                    if (wp.DashTimer == WarioPlayer.MAX_DASH_TIMER)
                    {
                        Vector2 newVelocity = player.velocity;

                        if ((wp.DashDir == WarioPlayer.DashLeft && player.velocity.X > -wp.DashVelocity) || (wp.DashDir == WarioPlayer.DashRight && player.velocity.X < wp.DashVelocity))
                        {
                            //X-velocity is set here
                            int dashDirection = wp.DashDir == WarioPlayer.DashRight ? 1 : -1;
                            newVelocity.X = dashDirection * wp.DashVelocity;

                            Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y,
                            mod.GetSoundSlot(SoundType.Custom, "Sounds/Wario/WarioDash"));
                        }

                        player.velocity = newVelocity;
                    }

                    //Decrement the timers
                    wp.DashTimer--;
                    wp.DashDelay--;

                    if (wp.DashDelay == 0)
                    {
                        //The dash has ended.  Reset the fields
                        wp.DashDelay = WarioPlayer.MAX_DASH_DELAY;
                        wp.DashTimer = WarioPlayer.MAX_DASH_TIMER;
                        wp.DashActive = false;
                    }
                }
            }

            if (!wp.Wario)
            {
                player.wingsLogic = 0;
            }

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.AddIngredient(ItemID.SoulofFlight, 20);
            recipe.AddIngredient(ItemID.FallenStar, 3);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}