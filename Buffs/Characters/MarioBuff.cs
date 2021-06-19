using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MarioLand.Buffs.Characters
{
    public class MarioBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mario Time!");
            Description.SetDefault(
                "\n Jumps deal damage," +
                "\n wall jumps, swimming\n"
            );

            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MarioPlayer mp = player.GetModPlayer<MarioPlayer>();
            mp.MarioChar = true;
            mp.Mario = true;

            player.accFlipper = true;
            player.noFallDmg = true;

            if (!player.wet)
            {
                player.spikedBoots    += 1;
                player.maxRunSpeed    += 1f;
                player.jumpSpeedBoost += .5f;

                if (player.velocity.X > 1.5 || player.velocity.X < -1.5)
                {
                    player.jumpSpeedBoost += 0.5f;
                }
            }
        }
    }
}