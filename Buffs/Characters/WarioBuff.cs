using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MarioLand.Buffs.Characters
{
    public class WarioBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Wario Time!");
            Description.SetDefault(
                "\n Bash enemies! (Tap left or right twice)" +
                "\n Jump attacks, swimming");

            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            WarioPlayer wp = player.GetModPlayer<WarioPlayer>();
            wp.Wario = true;

            player.accFlipper = true;
            player.noFallDmg = true;

            if (!player.wet)
            {
                player.maxFallSpeed += 3f;

//------------- ExampleDashAccessory code, modified to work with WarioBuff and WarioPlayer

                //If the dash is not active, immediately return so we don't do any of the logic for it
                if (!wp.DashActive)
                {
                    return;
                }

                player.eocDash = wp.DashTimer;
                player.armorEffectDrawShadowEOCShield = true;

                //If the dash has just started, apply the dash velocity in whatever direction we wanted to dash towards
                if (wp.DashTimer == WarioPlayer.MAX_DASH_TIMER)
                {
                    Vector2 newVelocity = player.velocity;

                    if (player.velocity.Y == 0 && ((wp.DashDir == WarioPlayer.DashLeft && player.velocity.X > -wp.DashVelocity) || (wp.DashDir == WarioPlayer.DashRight && player.velocity.X < wp.DashVelocity)))
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
    }
}
