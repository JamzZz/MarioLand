//using System;
//using System.Linq;
//using System.Collections.Generic;
//using System.IO;

  using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;

  using Terraria;
  using Terraria.ID;
  using Terraria.DataStructures;
  using Terraria.ModLoader;
  using Terraria.ModLoader.IO;
  using Terraria.GameInput;
//using Terraria.Graphics.Effects;
//using Terraria.Graphics.Shaders;
//using Terraria.GameContent.Dyes;

namespace MarioLand
{
    public class WarioPlayer : ModPlayer
    {
        public bool nullified = false;

        int count = 1;
//      int previous = -1;

//----- Wario & Power Ups
        public bool Wario       = false;
               bool WarioActive = false;

        public bool Jet       = false;
               bool JetActive = false;

//----- Power Up for transformation
        public bool PowerUp1 = false;
//      public bool PowerUp2 = false; etc.


//----- Custom for dev reasons
        public bool Invincible = false; // Checks if the character gets all the buffs associated with invincibility.
        public bool Dev        = false; // Checks if the character has access to the mod combos.



//----- Code from Examplemod's DashAccessory, modified to work with WarioBuff and WarioPlayer to make Wario perform the "shoulder" bash.

        public static readonly int DashRight = 2;
        public static readonly int DashLeft = 3;

//----- The direction the player is currently dashing towards.  Defaults to -1 if no dash is ocurring.
        public int DashDir = -1;

//----- The fields related to the dash BUFF
        public bool DashActive = false;
        public int  DashDelay  = MAX_DASH_DELAY;
        public int  DashTimer  = MAX_DASH_TIMER;

        //The initial velocity.  10 velocity is about 37.5 tiles/second or 50 mph
        public readonly float DashVelocity = 10f;

        //These two fields are the max values for the delay between dashes and the length of the dash in that order
        //The time is measured in frames
        public static readonly int MAX_DASH_DELAY = 50;
        public static readonly int MAX_DASH_TIMER = 35;

        public override void ResetEffects()
        {
             Wario = false;

               Jet = false;

        Invincible = false;
               Dev = false;

          PowerUp1 = false;

            {
                if (player.mount.Active || DashActive)
                    return;

                //When a directional key is pressed and released, vanilla starts a 15 tick (1/4 second) timer during which a second press activates a dash
                //If the timers are set to 15, then this is the first press just processed by the vanilla logic.  Otherwise, it's a double-tap
                if (player.controlRight && player.releaseRight && player.doubleTapCardinalTimer[DashRight] < 15)
                    DashDir = DashRight;
                else if (player.controlLeft && player.releaseLeft && player.doubleTapCardinalTimer[DashLeft] < 15)
                    DashDir = DashLeft;
                else
                    return;  //No dash was activated, return

                DashActive = true;
            }

        }

        public override void FrameEffects() //  Changes the appearance when a full set is worn
        {                                  //   Set depends on conditions met          
            if (Wario)
            {
                player.head = mod.GetEquipSlot("WarioHead", EquipType.Head);
                player.body = mod.GetEquipSlot("WarioBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("WarioLegs", EquipType.Legs);
            }

            if (Wario && Jet)
            {
                player.head = mod.GetEquipSlot("WarioJetHead", EquipType.Head);
            }

            if (nullified)
            {
                Nullify();
            }
        }

        private void Nullify()
        {
            player.ResetEffects();
            player.head = -1;
            player.body = -1;
            player.legs = -1;
            nullified = true;
        }

//----- For Power-Up/Power-Down effects and loops

        public override void PostUpdateEquips()
        {
            if (Dev /*&& (Leaf || Tanooki)*/)
            {
                Invincible = true;
            }

//--------- Invincible code - Makes you immune to pretty much anything
            if (Invincible)
            {
                player.waterWalk = true;
                player.lavaImmune = true;
                player.ignoreWater = true;
                player.iceSkate = true;
                if (player.wet)
                {
                    player.AddBuff(BuffID.Gills, 1);
                }

                player.wingTimeMax = 1000000;

                player.thorns = 100f;
                player.maxRunSpeed += 1.5f;

                player.buffImmune[BuffID.Poisoned] = true;
                player.buffImmune[BuffID.Darkness] = true;
                player.buffImmune[BuffID.Cursed] = true;
                player.buffImmune[BuffID.OnFire] = true;
                player.buffImmune[BuffID.Bleeding] = true;
                player.buffImmune[BuffID.Confused] = true;
                player.buffImmune[BuffID.Slow] = true;
                player.buffImmune[BuffID.Weak] = true;
                player.buffImmune[BuffID.Silenced] = true;
                player.buffImmune[BuffID.BrokenArmor] = true;
                player.buffImmune[BuffID.Horrified] = true;
                player.buffImmune[BuffID.TheTongue] = true;
                player.buffImmune[BuffID.CursedInferno] = true;
                player.buffImmune[BuffID.Frostburn] = true;
                player.buffImmune[BuffID.Chilled] = true;
                player.buffImmune[BuffID.Frozen] = true;
                player.buffImmune[BuffID.Burning] = true;
                player.buffImmune[BuffID.Suffocation] = true;
                player.buffImmune[BuffID.Ichor] = true;
                player.buffImmune[BuffID.Venom] = true;
                player.buffImmune[BuffID.Blackout] = true;
                player.buffImmune[BuffID.ChaosState] = true;
                player.buffImmune[BuffID.Electrified] = true;
                player.buffImmune[BuffID.MoonLeech] = true;
                player.buffImmune[BuffID.Rabies] = true;
                player.buffImmune[BuffID.Webbed] = true;
                player.buffImmune[BuffID.Stoned] = true;
                player.buffImmune[BuffID.Obstructed] = true;
                player.buffImmune[BuffID.VortexDebuff] = true;
                player.buffImmune[BuffID.WitheredArmor] = true;
                player.buffImmune[BuffID.WitheredWeapon] = true;
                player.buffImmune[BuffID.OgreSpit] = true;

                Lighting.AddLight(player.position, 1f, 1f, 1f);

                if (Main.rand.NextBool(10))
                {
                    Dust.NewDust(player.position, player.width, player.height, mod.DustType("SparkleDust"));
                }
            }
        }

        public override void PostUpdate()
        {         
            if (Wario)
            {
                if (player.controlJump && player.wet && PlayerInput.Triggers.JustPressed.Jump)
                {
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Wario/WarioSwim"));
                }

                if (!player.wet)
                {
                    if (player.legFrame.Y == 11 * 56 || player.legFrame.Y == 18 * 56)
                    {
                        if ((player.velocity.X > 2f || player.velocity.X < -2f) && (!player.mount.Active))
                        {
                        Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Wario/WarioWalk"));
                        }
                    }

                    if (player.controlJump && player.justJumped)
                    {
                        Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Wario/wario_jump"));
                    }
                }

//------------- Horizontal (bash) damage

                if ((player.velocity.X > 6f || player.velocity.X < -6f) && !player.mount.Active && !player.wet) // When moving faster than (x)f.
                {
                    Rectangle rect = player.getRect();
                    rect.Inflate(12, 6);
                    for (int i = 0; i < 200; i++)
                    {
                        NPC nPC = Main.npc[i];
                        if (nPC.active && !nPC.dontTakeDamage && !nPC.friendly && nPC.immune[player.whoAmI] == 0)
                        {
                            Rectangle rect2 = nPC.getRect();
                            if (rect.Intersects(rect2) && (nPC.noTileCollide || Terraria.Collision.CanHit(player.position, player.width, player.height, nPC.position, nPC.width, nPC.height)))
                            {
                                float num;

                                num = 20 * player.meleeDamage;

                                if (PowerUp1) { num = 25f * player.meleeDamage; }
                                //    if (PowerUp2) { num = (35f - (count - 1) * 5) * player.meleeDamage; }

                                float knockback = 5f; // Sets the knockback of the enemy when being bashed
                                int direction = player.direction;

                                if (player.whoAmI == Main.myPlayer)
                                {
                                    player.ApplyDamageToNPC(nPC, (int)num, knockback, direction, false);

                                    if (player.direction == 1)
                                    {
                                        player.velocity.X = -5;
                                    }

                                    if (player.direction == -1)
                                    {
                                        player.velocity.X = 5;
                                    }
                                }

                                nPC.immune[player.whoAmI] = 10;
                                player.immune = true;          //  makes immune upon a stomp, in this case to prevent damage because of collission with a damaging NPC.
                                player.immuneNoBlink = true;  //   stops blinking when immune
                                player.immuneTime = 12;       //    immunity time after jump

                                player.grappling[0] = -1;
                                player.grapCount = 0;
                                for (int p = 0; p < 1000; p++)
                                {
                                    if (Main.projectile[p].active && Main.projectile[p].owner == player.whoAmI && Main.projectile[p].aiStyle == 7)
                                    {
                                        Main.projectile[p].Kill();
                                    }
                                }

                                Dust.NewDust(player.position, player.width, player.height, mod.DustType("Stars"));

                                Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y,
                                mod.GetSoundSlot(SoundType.Custom, "Sounds/Wario/wario_bash"));

                                count++;

                                player.wingTime = 0;

                                break;
                            }
                        }
                    }
                }

                //------------- Jump "damage"

                if (player.velocity.Y == 0f) // If the player doesn't go upward/downward
                {
                    count = 1;
                }

                if (!Invincible && player.velocity.Y > 0f && !player.wet) // If not invincible, and falling downward
                {
                    Rectangle rect = player.getRect();
                    rect.Offset(0, player.height + 1);
                    rect.Height = 2;
                    rect.Inflate(6, 6);
                    for (int i = 0; i < 200; i++)
                    {
                        NPC nPC = Main.npc[i];
                        if (nPC.active && !nPC.dontTakeDamage && !nPC.friendly && nPC.immune[player.whoAmI] == 0)
                        {
                            Rectangle rect2 = nPC.getRect();
                            if (rect.Intersects(rect2) && (nPC.noTileCollide || Terraria.Collision.CanHit(player.position, player.width, player.height, nPC.position, nPC.width, nPC.height)))
                            {
                                float num;

//----------------------------- Jump damage is decided by num

                                num = 0;

                                float knockback = 5f;
                                int direction = player.direction;

                                if (player.velocity.X < 0f)
                                {
                                    direction = -1;
                                }

                                if (player.velocity.X > 0f)
                                {
                                    direction = 1;
                                }

                                if (player.whoAmI == Main.myPlayer)
                                {
                                    player.ApplyDamageToNPC(nPC, (int)num, knockback, direction, false);
                                }

                                nPC.immune[player.whoAmI] = 10;
                                if (player.controlJump)
                                {
                                    player.velocity.Y = -10f;
                                }
                                if (!player.controlJump)
                                {
                                    player.velocity.Y = -6f;
                                }
                                                                // Decides how high you jump when the enemy's damaged. /count to reduce the velocity. Or *count to go wild.
                                player.immune = true;          //  makes immune upon a stomp, in this case to prevent damage because of collission with a damaging NPC.
                                player.immuneNoBlink = true;  //   stops blinking when immune
                                player.immuneTime = 12;       //    immunity time after jump

//----------------------------- When using the grappling hook, it will deactivate once you damage an enemy
                                player.grappling[0] = -1;
                                player.grapCount = 0;
                                for (int p = 0; p < 1000; p++)
                                {
                                    if (Main.projectile[p].active && Main.projectile[p].owner == player.whoAmI && Main.projectile[p].aiStyle == 7)
                                    {
                                        Main.projectile[p].Kill();
                                    }
                                }

                                Dust.NewDust(player.position, player.width, player.height, mod.DustType("Stars"));

                                Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y,
                                mod.GetSoundSlot(SoundType.Custom, "Sounds/Wario/wario_jump_hit"));
                                
                                count++;

                                break;
                            }
                        }
                    }
                }
                
                
                
//------------- When Jet gets put on
                if (Jet && !JetActive)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                    }
                    count++;
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Wario/wario_power_up"));
                    JetActive = true;
                }

//------------- When Jet gets put off
                if (!Jet && JetActive)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                    }
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Wario/wario_power_down"));
                    JetActive = false;
                }

//------------- When Wario's transform activates
                if (!WarioActive)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                    }
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Wario/wario_power_up"));
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Wario/wario_time"));
                    WarioActive = true;
                }
            }

//--------- When Wario's outfit set gets cancelled by removing at least one part.
            if (!Wario && WarioActive)
            {
                for (int i = 0; i < 10; i++)
                {
                    Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                }
                Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Wario/wario_power_down"));
                WarioActive = false;
            }
        }

//----- If Dev is true, you're invincible.
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,  // Dev doesn't get hit. 
        ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)        // Different from simply using player.immune, since this still has collision to make thorns work
        {
            if (Invincible)
            {
                return false;
            }
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }

//----- No gore
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (Wario)
            {
                playSound = false;
                genGore = false;
            }
            return true;
        }

//----- Wario death sound
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (Wario)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Wario/wario_death"));
            }
        }
    }
}
