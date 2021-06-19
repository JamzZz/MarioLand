using Terraria;
using Terraria.ModLoader;

namespace MarioLand
{
    public class MarioLand : Mod
    {

        public override void Load()
        {
            if (!Main.dedServ)
            {
                //    MARIO     \\

                //    Super Mario  
                AddEquipTexture(new Items.Costumes.SuperMarioHead(), null, EquipType.Head, "SuperMarioHead", "MarioLand/Items/Costumes/Super/MarioSuper_Head");
                AddEquipTexture(new Items.Costumes.SuperMarioBody(), null, EquipType.Body, "SuperMarioBody", "MarioLand/Items/Costumes/Super/MarioSuper_Body", "MarioLand/Items/Costumes/Super/MarioSuper_Arms");
                AddEquipTexture(new Items.Costumes.SuperMarioLegs(), null, EquipType.Legs, "SuperMarioLegs", "MarioLand/Items/Costumes/Super/MarioSuper_Legs");

                //    Fire Mario
                AddEquipTexture(new Items.Costumes.FireMarioHead(), null, EquipType.Head, "FireMarioHead", "MarioLand/Items/Costumes/Fire/MarioFire_Head");
                AddEquipTexture(new Items.Costumes.FireMarioBody(), null, EquipType.Body, "FireMarioBody", "MarioLand/Items/Costumes/Fire/MarioFire_Body", "MarioLand/Items/Costumes/Fire/MarioFire_Arms");
                AddEquipTexture(new Items.Costumes.FireMarioLegs(), null, EquipType.Legs, "FireMarioLegs", "MarioLand/Items/Costumes/Fire/MarioFire_Legs");

                //    Leaf Mario
                AddEquipTexture(new Items.Costumes.LeafMarioHead(), null, EquipType.Head, "LeafMarioHead", "MarioLand/Items/Costumes/Leaf/MarioLeaf_Head");
                AddEquipTexture(new Items.Costumes.LeafMarioBody(), null, EquipType.Body, "LeafMarioBody", "MarioLand/Items/Costumes/Leaf/MarioLeaf_Body", "MarioLand/Items/Costumes/Leaf/MarioLeaf_Arms");
                AddEquipTexture(new Items.Costumes.LeafMarioLegs(), null, EquipType.Legs, "LeafMarioLegs", "MarioLand/Items/Costumes/Leaf/MarioLeaf_Legs");

                //    Invincibility Leaf Mario
                AddEquipTexture(new Items.Costumes.InvLeafMarioHead(), null, EquipType.Head, "InvLeafMarioHead", "MarioLand/Items/Costumes/InvLeaf/MarioInvLeaf_Head");
                AddEquipTexture(new Items.Costumes.InvLeafMarioBody(), null, EquipType.Body, "InvLeafMarioBody", "MarioLand/Items/Costumes/InvLeaf/MarioInvLeaf_Body", "MarioLand/Items/Costumes/InvLeaf/MarioInvLeaf_Arms");
                AddEquipTexture(new Items.Costumes.InvLeafMarioLegs(), null, EquipType.Legs, "InvLeafMarioLegs", "MarioLand/Items/Costumes/InvLeaf/MarioInvLeaf_Legs");

                //    Tanooki Mario
                AddEquipTexture(new Items.Costumes.TanookiMarioHead(), null, EquipType.Head, "TanookiMarioHead", "MarioLand/Items/Costumes/Tanooki/MarioTanooki_Head");
                AddEquipTexture(new Items.Costumes.TanookiMarioBody(), null, EquipType.Body, "TanookiMarioBody", "MarioLand/Items/Costumes/Tanooki/MarioTanooki_Body", "MarioLand/Items/Costumes/Tanooki/MarioTanooki_Arms");
                AddEquipTexture(new Items.Costumes.TanookiMarioLegs(), null, EquipType.Legs, "TanookiMarioLegs", "MarioLand/Items/Costumes/Tanooki/MarioTanooki_Legs");

                //    Invincibility Tanooki Mario
                AddEquipTexture(new Items.Costumes.InvTanookiMarioHead(), null, EquipType.Head, "InvTanookiMarioHead", "MarioLand/Items/Costumes/InvTanooki/MarioInvTanooki_Head");
                AddEquipTexture(new Items.Costumes.InvTanookiMarioBody(), null, EquipType.Body, "InvTanookiMarioBody", "MarioLand/Items/Costumes/InvTanooki/MarioInvTanooki_Body", "MarioLand/Items/Costumes/InvTanooki/MarioInvTanooki_Arms");
                AddEquipTexture(new Items.Costumes.InvTanookiMarioLegs(), null, EquipType.Legs, "InvTanookiMarioLegs", "MarioLand/Items/Costumes/InvTanooki/MarioInvTanooki_Legs");

                //    Ice Mario
                AddEquipTexture(new Items.Costumes.IceMarioHead(), null, EquipType.Head, "IceMarioHead", "MarioLand/Items/Costumes/Ice/MarioIce_Head");
                AddEquipTexture(new Items.Costumes.IceMarioBody(), null, EquipType.Body, "IceMarioBody", "MarioLand/Items/Costumes/Ice/MarioIce_Body", "MarioLand/Items/Costumes/Ice/MarioIce_Arms");

                //    Frog Mario
                AddEquipTexture(new Items.Costumes.FrogMarioHead(), null, EquipType.Head, "FrogMarioHead", "MarioLand/Items/Costumes/Frog/MarioFrog_Head");
                AddEquipTexture(new Items.Costumes.FrogMarioBody(), null, EquipType.Body, "FrogMarioBody", "MarioLand/Items/Costumes/Frog/MarioFrog_Body", "MarioLand/Items/Costumes/Frog/MarioFrog_Arms");
                AddEquipTexture(new Items.Costumes.FrogMarioLegs(), null, EquipType.Legs, "FrogMarioLegs", "MarioLand/Items/Costumes/Frog/MarioFrog_Legs");

                //    Hammer Mario
                AddEquipTexture(new Items.Costumes.HammerMarioHead(), null, EquipType.Head, "HammerMarioHead", "MarioLand/Items/Costumes/Hammer/MarioHammer_Head");
                AddEquipTexture(new Items.Costumes.HammerMarioBody(), null, EquipType.Body, "HammerMarioBody", "MarioLand/Items/Costumes/Hammer/MarioHammer_Body", "MarioLand/Items/Costumes/Super/MarioSuper_Arms");


                //    Cape Mario
                AddEquipTexture(new Items.Costumes.CapeMarioHead(), null, EquipType.Head, "CapeMarioHead", "MarioLand/Items/Costumes/Cape/MarioCape_Head");
                AddEquipTexture(new Items.Costumes.CapeMarioBody(), null, EquipType.Body, "CapeMarioBody", "MarioLand/Items/Costumes/Cape/MarioCape_Body", "MarioLand/Items/Costumes/Leaf/MarioLeaf_Arms");
                AddEquipTexture(new Items.Costumes.CapeMarioLegs(), null, EquipType.Legs, "CapeMarioLegs", "MarioLand/Items/Costumes/Cape/MarioCape_Legs");

                //    Bunny Mario
                AddEquipTexture(new Items.Costumes.CarrotMarioHead(), null, EquipType.Head, "CarrotMarioHead", "MarioLand/Items/Costumes/Carrot/MarioCarrot_Head");

                //    Builder Mario
                AddEquipTexture(new Items.Costumes.BuilderMarioHead(), null, EquipType.Head, "BuilderMarioHead", "MarioLand/Items/Costumes/Builder/MarioBuilder_Head");
                AddEquipTexture(new Items.Costumes.BuilderMarioBody(), null, EquipType.Body, "BuilderMarioBody", "MarioLand/Items/Costumes/Builder/MarioBuilder_Body", "MarioLand/Items/Costumes/Builder/MarioBuilder_Arms");




                //    LUIGI

                //    Super Luigi
                AddEquipTexture(new Items.Costumes.SuperLuigiHead(), null, EquipType.Head, "SuperLuigiHead", "MarioLand/Items/Costumes/Super/LuigiSuper_Head");
                AddEquipTexture(new Items.Costumes.SuperLuigiBody(), null, EquipType.Body, "SuperLuigiBody", "MarioLand/Items/Costumes/Super/LuigiSuper_Body", "MarioLand/Items/Costumes/Super/LuigiSuper_Arms");
                AddEquipTexture(new Items.Costumes.SuperLuigiLegs(), null, EquipType.Legs, "SuperLuigiLegs", "MarioLand/Items/Costumes/Super/LuigiSuper_Legs");

                //    Fire Luigi
                AddEquipTexture(new Items.Costumes.FireLuigiHead(), null, EquipType.Head, "FireLuigiHead", "MarioLand/Items/Costumes/Fire/LuigiFire_Head");
                AddEquipTexture(new Items.Costumes.FireLuigiBody(), null, EquipType.Body, "FireLuigiBody", "MarioLand/Items/Costumes/Fire/LuigiFire_Body", "MarioLand/Items/Costumes/Fire/LuigiFire_Arms");
                AddEquipTexture(new Items.Costumes.FireLuigiLegs(), null, EquipType.Legs, "FireLuigiLegs", "MarioLand/Items/Costumes/Fire/LuigiFire_Legs");

                //    Leaf Luigi
                AddEquipTexture(new Items.Costumes.LeafLuigiHead(), null, EquipType.Head, "LeafLuigiHead", "MarioLand/Items/Costumes/Leaf/LuigiLeaf_Head");
                AddEquipTexture(new Items.Costumes.LeafLuigiBody(), null, EquipType.Body, "LeafLuigiBody", "MarioLand/Items/Costumes/Leaf/LuigiLeaf_Body", "MarioLand/Items/Costumes/Leaf/LuigiLeaf_Arms");
                AddEquipTexture(new Items.Costumes.LeafLuigiLegs(), null, EquipType.Legs, "LeafLuigiLegs", "MarioLand/Items/Costumes/Leaf/LuigiLeaf_Legs");

                //    Invincibility Leaf Luigi
                AddEquipTexture(new Items.Costumes.InvLeafLuigiHead(), null, EquipType.Head, "InvLeafLuigiHead", "MarioLand/Items/Costumes/InvLeaf/LuigiInvLeaf_Head");
                AddEquipTexture(new Items.Costumes.InvLeafLuigiBody(), null, EquipType.Body, "InvLeafLuigiBody", "MarioLand/Items/Costumes/InvLeaf/LuigiInvLeaf_Body", "MarioLand/Items/Costumes/InvLeaf/LuigiInvLeaf_Arms");
                AddEquipTexture(new Items.Costumes.InvLeafLuigiLegs(), null, EquipType.Legs, "InvLeafLuigiLegs", "MarioLand/Items/Costumes/InvLeaf/LuigiInvLeaf_Legs");

                //    Tanooki Luigi
                AddEquipTexture(new Items.Costumes.TanookiLuigiHead(), null, EquipType.Head, "TanookiLuigiHead", "MarioLand/Items/Costumes/Tanooki/LuigiTanooki_Head");
                AddEquipTexture(new Items.Costumes.TanookiLuigiBody(), null, EquipType.Body, "TanookiLuigiBody", "MarioLand/Items/Costumes/Tanooki/LuigiTanooki_Body", "MarioLand/Items/Costumes/Tanooki/LuigiTanooki_Arms");
                AddEquipTexture(new Items.Costumes.TanookiLuigiLegs(), null, EquipType.Legs, "TanookiLuigiLegs", "MarioLand/Items/Costumes/Tanooki/LuigiTanooki_Legs");

                //    Invincibility Tanooki Luigi
                AddEquipTexture(new Items.Costumes.InvTanookiLuigiHead(), null, EquipType.Head, "InvTanookiLuigiHead", "MarioLand/Items/Costumes/InvTanooki/LuigiInvTanooki_Head");
                AddEquipTexture(new Items.Costumes.InvTanookiLuigiBody(), null, EquipType.Body, "InvTanookiLuigiBody", "MarioLand/Items/Costumes/InvTanooki/LuigiInvTanooki_Body", "MarioLand/Items/Costumes/InvTanooki/LuigiInvTanooki_Arms");
                AddEquipTexture(new Items.Costumes.InvTanookiLuigiLegs(), null, EquipType.Legs, "InvTanookiLuigiLegs", "MarioLand/Items/Costumes/InvTanooki/LuigiInvTanooki_Legs");

                //    Ice Luigi
                AddEquipTexture(new Items.Costumes.IceLuigiHead(), null, EquipType.Head, "IceLuigiHead", "MarioLand/Items/Costumes/Ice/LuigiIce_Head");
                AddEquipTexture(new Items.Costumes.IceLuigiBody(), null, EquipType.Body, "IceLuigiBody", "MarioLand/Items/Costumes/Ice/LuigiIce_Body", "MarioLand/Items/Costumes/Ice/LuigiIce_Arms");

                //    Frog Luigi
                AddEquipTexture(new Items.Costumes.FrogLuigiHead(), null, EquipType.Head, "FrogLuigiHead", "MarioLand/Items/Costumes/Frog/LuigiFrog_Head");
                AddEquipTexture(new Items.Costumes.FrogLuigiBody(), null, EquipType.Body, "FrogLuigiBody", "MarioLand/Items/Costumes/Frog/LuigiFrog_Body", "MarioLand/Items/Costumes/Frog/LuigiFrog_Arms");
                AddEquipTexture(new Items.Costumes.FrogLuigiLegs(), null, EquipType.Legs, "FrogLuigiLegs", "MarioLand/Items/Costumes/Frog/LuigiFrog_Legs");

                //    Hammer Luigi
                AddEquipTexture(new Items.Costumes.HammerLuigiHead(), null, EquipType.Head, "HammerLuigiHead", "MarioLand/Items/Costumes/Hammer/LuigiHammer_Head");
                AddEquipTexture(new Items.Costumes.HammerLuigiBody(), null, EquipType.Body, "HammerLuigiBody", "MarioLand/Items/Costumes/Hammer/LuigiHammer_Body", "MarioLand/Items/Costumes/Super/LuigiSuper_Arms");

                //    Cape Mario
                AddEquipTexture(new Items.Costumes.CapeLuigiHead(), null, EquipType.Head, "CapeLuigiHead", "MarioLand/Items/Costumes/Cape/LuigiCape_Head");
                AddEquipTexture(new Items.Costumes.CapeLuigiBody(), null, EquipType.Body, "CapeLuigiBody", "MarioLand/Items/Costumes/Cape/LuigiCape_Body", "MarioLand/Items/Costumes/Leaf/LuigiLeaf_Arms");

                //    Builder Mario
                AddEquipTexture(new Items.Costumes.BuilderLuigiHead(), null, EquipType.Head, "BuilderLuigiHead", "MarioLand/Items/Costumes/Builder/LuigiBuilder_Head");
                AddEquipTexture(new Items.Costumes.BuilderLuigiBody(), null, EquipType.Body, "BuilderLuigiBody", "MarioLand/Items/Costumes/Builder/LuigiBuilder_Body", "MarioLand/Items/Costumes/Builder/LuigiBuilder_Arms");




                //    WARIO

                //    Regular Wario
                AddEquipTexture(new Items.Costumes.WarioHead(), null, EquipType.Head, "WarioHead", "MarioLand/Items/Costumes/Wario/Wario_Head");
                AddEquipTexture(new Items.Costumes.WarioBody(), null, EquipType.Body, "WarioBody", "MarioLand/Items/Costumes/Wario/Wario_Body", "MarioLand/Items/Costumes/Wario/Wario_Arms");
                AddEquipTexture(new Items.Costumes.WarioLegs(), null, EquipType.Legs, "WarioLegs", "MarioLand/Items/Costumes/Wario/Wario_Legs");

                //    Jet Wario
                AddEquipTexture(new Items.Costumes.WarioHead(), null, EquipType.Head, "WarioJetHead", "MarioLand/Items/Costumes/Wario/WarioJet_Head");

            }
        }
    }
}
