using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MarioLand.Buffs.Characters
{
    public class LuigiBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Luigi Time!");
            Description.SetDefault(
                "\n Damaging jump attack," +
                "\n wall jumps, swimming\n"
            );

            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            mp.MarioChar = true;
            mp.Luigi = true;

            player.maxFallSpeed += -1.5f;
            player.accFlipper = true;
            player.noFallDmg = true;

            if (!player.wet)
            {
                player.spikedBoots += 1;
                player.maxRunSpeed    += .5f;
                player.jumpSpeedBoost +=  1f;

                if (player.velocity.X > 1.5 || player.velocity.X < -1.5)
                {
                    player.jumpSpeedBoost += 0.5f;
                }

                if (player.velocity.X < 1.5f && player.velocity.X > -1.5f)
                {
                    player.slippy = true;         // Slippery movement

                    if (player.iceSkate)
                    {
                        player.iceSkate = false;
                    }
                }
            }
        }
    }
}