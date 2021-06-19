using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameInput;

namespace MarioLand
{
    public class MarioPlayer : ModPlayer
    {
        int count = 1;
        //      int previous = -1;
        public bool nullified = false;
        public bool examplePet = false;
        public bool exampleLightPet = false;

        //    Bool for character groups, not individuals. (MarioChar includes Mario, Luigi, Peach, Toad, not just Mario)

        public bool MarioChar = false;    // Character from Mario. Includes Mario, Luigi, Peach, Daisy, Toad
        bool MarioCharActive = false;    // Used for one-time activators when turned true/false  

        ////    Mario individual characters

        public bool Mario = false;
        bool MarioActive = false;

        public bool Luigi = false;
        bool LuigiActive = false;

        //      Power-Ups (Mario series)

        public bool Fire = false; // Checks if Fire Flower's equipped       Mario, Luigi, Peach, Daisy, Toad
        bool FireActive = false;

        public bool Ice = false; // Checks if character has the Ice power-up.                 Mario, Luigi, Peach, Daisy, Toad
        bool IceActive = false;

        //      Super Mario Bros. 3

        public bool Leaf = false; // Checks if character has the Leaf power-up.                Mario, Luigi, Peach, Daisy, Toad;
        bool LeafActive = false;

        public bool Tanooki = false;
        bool TanookiActive = false;

        public bool Frog = false;
        bool FrogActive = false;

        public bool Hammer = false;
        bool HammerActive = false;

        //      Super Mario World

        public bool Cape = false;
        bool CapeActive = false;

        //      Super Mario Land 2: 6 Golden Coins

        public bool Carrot = false;
        bool CarrotActive = false;

        //      Super Mario Maker

        public bool Builder = false;
        bool BuilderActive = false;

        //      Mounts

        public bool GoombaShoe = false;



        public bool Invincible = false; // Checks if the character gets all the buffs associated with invincibility.
        public bool Dev = false; // Checks if the character has access to the mod combos.



        public bool PowerUp1 = false;

        //      End of booleans regarding series and individual characters



        public override void ResetEffects()
        {
            examplePet = false;
            exampleLightPet = false;

            //          Character series

            MarioChar = false;
            Mario = false;
            Luigi = false;

            Fire = false;
            Ice = false;

            Leaf = false;
            Tanooki = false;
            Frog = false;
            Hammer = false;

            Cape = false;

            Carrot = false;

            Builder = false;

            Invincible = false;
            Dev = false;

            GoombaShoe = false;

            PowerUp1 = false;

        }

        public override void FrameEffects() //  Transformation visual override
        {
            if (Mario)
            {
                player.head = mod.GetEquipSlot("SuperMarioHead", EquipType.Head);
                player.body = mod.GetEquipSlot("SuperMarioBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("SuperMarioLegs", EquipType.Legs);
            }

            if (Mario && Fire)
            {
                player.head = mod.GetEquipSlot("FireMarioHead", EquipType.Head);
                player.body = mod.GetEquipSlot("FireMarioBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("FireMarioLegs", EquipType.Legs);
            }

            if (Mario && Ice)
            {
                player.head = mod.GetEquipSlot("IceMarioHead", EquipType.Head);
                player.body = mod.GetEquipSlot("IceMarioBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("FireMarioLegs", EquipType.Legs);
            }

            if (Mario && Leaf)
            {
                player.head = mod.GetEquipSlot("LeafMarioHead", EquipType.Head);
                player.body = mod.GetEquipSlot("LeafMarioBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("LeafMarioLegs", EquipType.Legs);
            }

            if (Mario && Leaf && Dev)
            {
                player.head = mod.GetEquipSlot("InvLeafMarioHead", EquipType.Head);
                player.body = mod.GetEquipSlot("InvLeafMarioBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("InvLeafMarioLegs", EquipType.Legs);
            }

            if (Mario && Tanooki)
            {
                player.head = mod.GetEquipSlot("TanookiMarioHead", EquipType.Head);
                player.body = mod.GetEquipSlot("TanookiMarioBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("TanookiMarioLegs", EquipType.Legs);
            }

            if (Mario && Tanooki && Dev)
            {
                player.head = mod.GetEquipSlot("InvTanookiMarioHead", EquipType.Head);
                player.body = mod.GetEquipSlot("InvTanookiMarioBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("InvTanookiMarioLegs", EquipType.Legs);
            }

            if (Mario && Frog)
            {
                player.head = mod.GetEquipSlot("FrogMarioHead", EquipType.Head);
                player.body = mod.GetEquipSlot("FrogMarioBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("FrogMarioLegs", EquipType.Legs);
            }

            if (Mario && Hammer)
            {
                player.head = mod.GetEquipSlot("HammerMarioHead", EquipType.Head);
                player.body = mod.GetEquipSlot("HammerMarioBody", EquipType.Body);
            }

            if (Mario && Cape)
            {
                player.head = mod.GetEquipSlot("CapeMarioHead", EquipType.Head);
                player.body = mod.GetEquipSlot("CapeMarioBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("CapeMarioLegs", EquipType.Legs);
            }

            if (Mario && Carrot)
            {
                player.head = mod.GetEquipSlot("CarrotMarioHead", EquipType.Head);
            }

            if (Mario && Builder)
            {
                player.head = mod.GetEquipSlot("BuilderMarioHead", EquipType.Head);
                player.body = mod.GetEquipSlot("BuilderMarioBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("FireMarioLegs", EquipType.Legs);
            }

            if (Luigi)
            {
                player.head = mod.GetEquipSlot("SuperLuigiHead", EquipType.Head);
                player.body = mod.GetEquipSlot("SuperLuigiBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("SuperLuigiLegs", EquipType.Legs);

            }

            if (Luigi && Fire)
            {
                player.head = mod.GetEquipSlot("FireLuigiHead", EquipType.Head);
                player.body = mod.GetEquipSlot("FireLuigiBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("FireLuigiLegs", EquipType.Legs);
            }

            if (Luigi && Ice)
            {
                player.head = mod.GetEquipSlot("IceLuigiHead", EquipType.Head);
                player.body = mod.GetEquipSlot("IceLuigiBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("FireLuigiLegs", EquipType.Legs);
            }

            if (Luigi && Leaf)
            {
                player.head = mod.GetEquipSlot("LeafLuigiHead", EquipType.Head);
                player.body = mod.GetEquipSlot("LeafLuigiBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("LeafLuigiLegs", EquipType.Legs);
            }

            if (Luigi && Leaf && Dev)
            {
                player.head = mod.GetEquipSlot("InvLeafLuigiHead", EquipType.Head);
                player.body = mod.GetEquipSlot("InvLeafLuigiBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("InvLeafLuigiLegs", EquipType.Legs);
            }

            if (Luigi && Tanooki)
            {
                player.head = mod.GetEquipSlot("TanookiLuigiHead", EquipType.Head);
                player.body = mod.GetEquipSlot("TanookiLuigiBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("TanookiLuigiLegs", EquipType.Legs);
            }

            if (Luigi && Tanooki && Dev)
            {
                player.head = mod.GetEquipSlot("InvTanookiLuigiHead", EquipType.Head);
                player.body = mod.GetEquipSlot("InvTanookiLuigiBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("InvTanookiLuigiLegs", EquipType.Legs);
            }

            if (Luigi && Frog)
            {
                player.head = mod.GetEquipSlot("FrogLuigiHead", EquipType.Head);
                player.body = mod.GetEquipSlot("FrogLuigiBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("FrogLuigiLegs", EquipType.Legs);
            }

            if (Luigi && Hammer)
            {
                player.head = mod.GetEquipSlot("HammerLuigiHead", EquipType.Head);
                player.body = mod.GetEquipSlot("HammerLuigiBody", EquipType.Body);
            }

            if (Luigi && Cape)
            {
                player.head = mod.GetEquipSlot("CapeLuigiHead", EquipType.Head);
                player.body = mod.GetEquipSlot("CapeLuigiBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("LeafLuigiLegs", EquipType.Legs);
            }

            if (Luigi && Builder)
            {
                player.head = mod.GetEquipSlot("BuilderLuigiHead", EquipType.Head);
                player.body = mod.GetEquipSlot("BuilderLuigiBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("FireLuigiLegs", EquipType.Legs);
            }

            if (nullified) // Won't happen unless specifically called for
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
            /*  player.handon = -1;
                player.handoff = -1;
                player.back = -1;
                player.front = -1;
                player.shoe = -1;
                player.waist = -1;
                player.shield = -1;
                player.neck = -1;
                player.face = -1;
                player.balloon = -1;  */
            nullified = true;
        }

        //      For Power-Up/Power-Down effects and loops

        public override void PostUpdateEquips()
        {
            if (Dev && (Leaf || Tanooki))
            {
                Invincible = true;
            }

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

            if (Builder && (Mario || Luigi))
            {
                player.wallSpeed += 1f;
                player.tileSpeed += 1f;
                player.blockRange += 5;

                player.statDefense += 2;
            }

            if ((Mario || Luigi) && Frog)
            {
                player.jumpSpeedBoost += 1f;
                if (player.legFrame.Y == 7 * 56)
                {
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/FrogWalk"));
                }

                if (!player.wet && !player.justJumped)
                {
                    player.runSlowdown += 1.50f;
                    player.maxRunSpeed += -0.5f;
                }

                if (player.wet)
                {
                    player.ignoreWater = true;
                    player.maxRunSpeed += 1.0f;
                    player.maxFallSpeed += 1.00f;
                }
            }

            if (Mario && Carrot)
            {
                if (!player.releaseJump && (player.velocity.Y > 0.1) && !player.wet)
                {
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/CarrotJump"));
                }
            }

            if ((Mario || Luigi) && Hammer)
            {
                player.statDefense += 3;
                player.thrownDamage += 0.05f;
                player.thrownVelocity += 0.00f;
                player.thrownCrit += 5;
                //player.thrownCost50 = false;
                //player.thrownCost33 = true;
            }
        }

        public override void PostUpdate()
        {
            if (Mario && !MarioActive)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/mario_lets_go"));
                MarioActive = true;
            }

            if (!Mario)
            {
                MarioActive = false;
            }

            if (Luigi && !LuigiActive)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/luigi_goigi"));
                LuigiActive = true;
            }

            if (!Luigi)
            {
                LuigiActive = false;
            }

            //////  Mario series individual characters ends here

            if (MarioChar)
            {
                if (player.controlJump && player.wet && PlayerInput.Triggers.JustPressed.Jump)
                {
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/swim"));
                }

                if (!player.wet)
                {
                    if (player.legFrame.Y == 11 * 56 || player.legFrame.Y == 18 * 56 && (player.velocity.X > 0.5f || player.velocity.X < -0.5f))
                    {
                        if (!Frog)
                        {
                            Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/mariochar_walk"));
                        }
                    }

                    if (player.controlJump && player.justJumped)
                    {
                        Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/smw_jump"));
                    }
                }

                if (player.velocity.Y > 0.0f)
                {
                    if (Cape && !player.releaseJump)
                    {
                        player.bodyFrame.Y = 5 * player.bodyFrame.Height;
                    }
                }

                //              Jump damage

                if (player.velocity.Y == 0f)
                {
                    count = 1;
                }

                if (!Invincible && player.velocity.Y > 0f) // If not invincible, and falling downward
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
                            if ((!player.wet) && rect.Intersects(rect2) && (nPC.noTileCollide || Terraria.Collision.CanHit(player.position, player.width, player.height, nPC.position, nPC.width, nPC.height)))
                            {
                                float num;

                                num = (20f - (count - 1) * 5) * player.meleeDamage;

                                if (PowerUp1) { num = (30f - (count - 1) * 5) * player.meleeDamage; }
                                //    if (PowerUp2)   { num = (35f - (count - 1) * 5) * player.meleeDamage; }


                                if (count > 3)
                                {

                                    num = 8 * player.meleeDamage;
                                    if (PowerUp1) { num = 12 * player.meleeDamage; }
                                    //  if (PowerUp2)   { num = 15 * player.meleeDamage; }
                                }

                                float knockback = 2f / count;
                                int direction = player.direction;

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
                                player.immuneTime = 3;       //    immunity time after jump

                                Dust.NewDust(player.position, player.width, player.height, mod.DustType("Stars"));

                                if (count < 8)
                                {
                                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y,
                                    mod.GetSoundSlot(SoundType.Custom, "Sounds/hit" + count));
                                }

                                if (count >= 8)
                                {
                                    // Healing amount after 8 jumps

                                    int healingAmount;

                                    /*(NoPowerUp)*/
                                    { healingAmount = (10 - ((count - 8) * 2)); }
                                    if (PowerUp1) { healingAmount = (15 - ((count - 8) * 2)); }
                                    //  if (PowerUp2)   { healingAmount = (20 - ((count - 8) * 2)); }

                                    if (count >= 13)
                                    {
                                        healingAmount = 1;
                                    }

                                    player.statLife += healingAmount;
                                    player.HealEffect(healingAmount, true);
                                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/1up"));
                                }

                                count++;

                                break;
                            }
                        }
                    }
                }

                if (Fire && !FireActive)
                {
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/smw_power_up"));
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("DiagonalLinesDust"));
                    }
                    FireActive = true;
                }

                if (!Fire && FireActive)
                {
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/smw_power_down"));
                    FireActive = false;
                }

                if (Leaf && !LeafActive)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("Stars"));
                    }
                    count++;
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/leaf_transform"));
                    LeafActive = true;
                }

                if (!Leaf && LeafActive)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                    }
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/smw_power_down"));
                    LeafActive = false;
                }

                if (Tanooki && !TanookiActive)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("Stars"));
                    }
                    count++;
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/leaf_transform"));
                    TanookiActive = true;
                }

                if (!Tanooki && TanookiActive)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                    }
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/transform_off"));
                    TanookiActive = false;
                }

                if (Frog && !FrogActive)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("Stars"));
                    }
                    count++;
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/leaf_transform"));
                    FrogActive = true;
                }

                if (!Frog && FrogActive)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                    }
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/transform_off"));
                    FrogActive = false;
                }

                if (Hammer && !HammerActive)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("Stars"));
                    }
                    count++;
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/leaf_transform"));
                    HammerActive = true;
                }

                if (!Hammer && HammerActive)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                    }
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/transform_off"));
                    HammerActive = false;
                }

                if (Ice && !IceActive)
                {
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/smw_power_up"));
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("DiagonalLinesDust"));
                    }
                    IceActive = true;
                }

                if (!Ice && IceActive)
                {
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/smw_power_down"));
                    IceActive = false;
                }

                if (Cape && !CapeActive)
                {
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/smw_feather_get"));
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                    }
                    CapeActive = true;
                }

                if (!Cape && CapeActive)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                    }
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/smw_power_down"));
                    CapeActive = false;
                }

                if (Carrot && !CarrotActive)
                {
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/sml2_power_up"));
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("Stars"));
                    }
                    CarrotActive = true;
                }

                if (!Carrot && CarrotActive)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                    }
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/sml2_power_down"));
                    CarrotActive = false;
                }

                if (Builder && !BuilderActive)
                {
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/smw_power_up"));
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                    }
                    BuilderActive = true;
                }

                if (!Builder && BuilderActive)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                    }
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/smw_power_down"));
                    BuilderActive = false;
                }

                if (!MarioCharActive)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                    }
                    Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/smw_power_up"));
                    MarioCharActive = true;
                }


            }

            // Put code here if MarioChar isn't true, but still needs to be in PostUpdate.

            if (!MarioChar && MarioCharActive)
            {
                for (int i = 0; i < 10; i++)
                {
                    Dust.NewDust(player.position, player.width, player.height, mod.DustType("SmokeTransformDust"));
                }
                Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/smw_power_down"));
                MarioCharActive = false;
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,  // Dev doesn't get hit. 
        ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)        // Different from simply using player.immune, since this still has collision to make thorns work
        {
            if (Invincible)
            {
                return false;
            }
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (MarioChar)
            {
                playSound = false;
                genGore = false;
            }
            return true;
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (Mario)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/mlpit_mario_mamma-mia_2"));
            }

            if (Luigi)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/mlpit_luigi_mamma-mia_2"));
            }
        }

        //      Buffs when values are set to true. OnHitNPC for Melee attacks, OnHitNPCWithProj for Projectiles

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (Fire && MarioChar)
            {
                target.AddBuff(BuffID.OnFire, 60);
            }

            if (Ice && MarioChar)
            {
                target.AddBuff(BuffID.Frostburn, 30);
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (Fire && MarioChar)
            {
                target.AddBuff(BuffID.OnFire, 60);
            }

            if (Ice && MarioChar)
            {
                target.AddBuff(BuffID.Frostburn, 30);
            }
        }
    }
}
