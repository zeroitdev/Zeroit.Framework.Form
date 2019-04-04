// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ThemeManager.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.Form.Thematic
{
    /// <summary>
    /// Enum representing the themes to use in the <c><see cref="ResizableForm" /> and <see cref="Thematic150" /></c>
    /// </summary>
    public enum Themes
    {
        /// <summary>
        /// The eight ball
        /// </summary>
        EightBall,
        /// <summary>
        /// The adobe
        /// </summary>
        Adobe,
        /// <summary>
        /// The advanced system
        /// </summary>
        Advanced_System,
        /// <summary>
        /// The advantium
        /// </summary>
        Advantium,
        /// <summary>
        /// The alpha
        /// </summary>
        Alpha,
        /// <summary>
        /// The angel
        /// </summary>
        Angel,
        /// <summary>
        /// The anom
        /// </summary>
        Anom,
        /// <summary>
        /// The aryan
        /// </summary>
        Aryan,
        /// <summary>
        /// The atrocity
        /// </summary>
        Atrocity,
        /// <summary>
        /// The avatar
        /// </summary>
        Avatar,
        /// <summary>
        /// The average
        /// </summary>
        AVG,
        /// <summary>
        /// The basic code
        /// </summary>
        BasicCode,
        /// <summary>
        /// The beta blue
        /// </summary>
        BetaBlue,
        /// <summary>
        /// The beyond
        /// </summary>
        Beyond,
        /// <summary>
        /// The bionic
        /// </summary>
        Bionic,
        /// <summary>
        /// The bit defender
        /// </summary>
        BitDefender,
        /// <summary>
        /// The black shades
        /// </summary>
        BlackShades,
        /// <summary>
        /// The bloody
        /// </summary>
        Bloody,
        //BlueAndWhite,
        /// <summary>
        /// The blue
        /// </summary>
        Blue,
        /// <summary>
        /// The booster
        /// </summary>
        Booster,
        /// <summary>
        /// The border
        /// </summary>
        Border,
        /// <summary>
        /// The bullion
        /// </summary>
        Bullion,
        /// <summary>
        /// The butter scotch
        /// </summary>
        ButterScotch,
        /// <summary>
        /// The carbon fibre
        /// </summary>
        CarbonFibre,
        /// <summary>
        /// The chrome
        /// </summary>
        Chrome,
        /// <summary>
        /// The clarity
        /// </summary>
        Clarity,
        /// <summary>
        /// The classic
        /// </summary>
        Classic,
        /// <summary>
        /// The CLS neo bux
        /// </summary>
        clsNeoBux,
        /// <summary>
        /// The coca cola
        /// </summary>
        CocaCola,
        /// <summary>
        /// The complex
        /// </summary>
        Complex,
        /// <summary>
        /// The crystal
        /// </summary>
        Crystal,
        /// <summary>
        /// The cypher
        /// </summary>
        Cypher,
        //CypherX
        /// <summary>
        /// The dark matter
        /// </summary>
        DarkMatter,
        /// <summary>
        /// The dark matter alt
        /// </summary>
        DarkMatterAlt,
        /// <summary>
        /// The design
        /// </summary>
        Design,
        /// <summary>
        /// The destiny
        /// </summary>
        Destiny,
        /// <summary>
        /// The deumos
        /// </summary>
        Deumos,
        /// <summary>
        /// The doom
        /// </summary>
        Doom,
        /// <summary>
        /// The drone
        /// </summary>
        Drone,
        /// <summary>
        /// The earn
        /// </summary>
        Earn,
        /// <summary>
        /// The effectual
        /// </summary>
        Effectual,
        /// <summary>
        /// The electric
        /// </summary>
        Electric,
        /// <summary>
        /// The electrified
        /// </summary>
        Electrified,
        /// <summary>
        /// The elegant
        /// </summary>
        Elegant,
        /// <summary>
        /// The element
        /// </summary>
        Element,
        /// <summary>
        /// The empire
        /// </summary>
        Empire,
        /// <summary>
        /// The empress
        /// </summary>
        Empress,
        /// <summary>
        /// The e theme
        /// </summary>
        ETheme,
        /// <summary>
        /// The evolve
        /// </summary>
        Evolve,
        /// <summary>
        /// The excision
        /// </summary>
        Excision,
        /// <summary>
        /// The exotic
        /// </summary>
        Exotic,
        /// <summary>
        /// The facebook
        /// </summary>
        Facebook,
        /// <summary>
        /// The festus
        /// </summary>
        Festus,
        /// <summary>
        /// The flat UI
        /// </summary>
        FlatUI,
        /// <summary>
        /// The flow
        /// </summary>
        Flow,
        /// <summary>
        /// The frog
        /// </summary>
        Frog,
        /// <summary>
        /// The fusion
        /// </summary>
        Fusion,
        /// <summary>
        /// The future
        /// </summary>
        Future,
        /// <summary>
        /// The g theme
        /// </summary>
        GTheme,
        /// <summary>
        /// The game booster
        /// </summary>
        GameBooster,
        /// <summary>
        /// The genuine
        /// </summary>
        Genuine,
        /// <summary>
        /// The ghostv2
        /// </summary>
        Ghostv2,
        /// <summary>
        /// The ghost theme
        /// </summary>
        GhostTheme,
        /// <summary>
        /// The gray
        /// </summary>
        Gray,
        /// <summary>
        /// The green
        /// </summary>
        Green,
        /// <summary>
        /// The hacker
        /// </summary>
        Hacker,
        /// <summary>
        /// The hero
        /// </summary>
        Hero,
        /// <summary>
        /// The hexadecimal
        /// </summary>
        Hex,
        /// <summary>
        /// The hf
        /// </summary>
        HF,
        /// <summary>
        /// The hura
        /// </summary>
        Hura,
        /// <summary>
        /// The i black
        /// </summary>
        iBlack,
        /// <summary>
        /// The influence
        /// </summary>
        Influence,
        /// <summary>
        /// The influx
        /// </summary>
        Influx,
        /// <summary>
        /// The inner darkness
        /// </summary>
        InnerDarkness,
        /// <summary>
        /// The insomia
        /// </summary>
        Insomia,
        /// <summary>
        /// The intel
        /// </summary>
        Intel,
        /// <summary>
        /// The j theme
        /// </summary>
        JTheme,
        /// <summary>
        /// The knight
        /// </summary>
        Knight,
        /// <summary>
        /// The light
        /// </summary>
        Light,
        /// <summary>
        /// The login
        /// </summary>
        Login,
        /// <summary>
        /// The loyal
        /// </summary>
        Loyal,
        /// <summary>
        /// The meph
        /// </summary>
        Meph,
        /// <summary>
        /// The metal
        /// </summary>
        Metal,
        /// <summary>
        /// The metro UI
        /// </summary>
        MetroUI,
        /// <summary>
        /// The metro disk
        /// </summary>
        MetroDisk,
        /// <summary>
        /// The modern
        /// </summary>
        Modern,
        /// <summary>
        /// The MPGH
        /// </summary>
        MPGH,
        /// <summary>
        /// The mumtz
        /// </summary>
        Mumtz,
        /// <summary>
        /// The mystic
        /// </summary>
        Mystic,
        /// <summary>
        /// The nameless
        /// </summary>
        Nameless,
        /// <summary>
        /// The neo bux
        /// </summary>
        NeoBux,
        /// <summary>
        /// The net seal
        /// </summary>
        NetSeal,
        /// <summary>
        /// The new
        /// </summary>
        New,
        /// <summary>
        /// The nyx
        /// </summary>
        NYX,
        /// <summary>
        /// The orains
        /// </summary>
        Orains,
        /// <summary>
        /// The origin
        /// </summary>
        Origin,
        /// <summary>
        /// The paladin
        /// </summary>
        Paladin,
        /// <summary>
        /// The patrick
        /// </summary>
        Patrick,
        /// <summary>
        /// The perplex
        /// </summary>
        Perplex,
        /// <summary>
        /// The positron
        /// </summary>
        Positron,
        /// <summary>
        /// The prime
        /// </summary>
        Prime,
        /// <summary>
        /// The purity
        /// </summary>
        Purity,
        /// <summary>
        /// The qube
        /// </summary>
        Qube,
        /// <summary>
        /// The reactor
        /// </summary>
        Reactor,
        /// <summary>
        /// The recon
        /// </summary>
        Recon,
        /// <summary>
        /// The redwagon
        /// </summary>
        Redwagon,
        /// <summary>
        /// The redemption
        /// </summary>
        Redemption,
        /// <summary>
        /// The resizable
        /// </summary>
        Resizable,
        /// <summary>
        /// The rockstar
        /// </summary>
        Rockstar,
        /// <summary>
        /// The sasi
        /// </summary>
        Sasi,
        /// <summary>
        /// The secure
        /// </summary>
        Secure,
        /// <summary>
        /// The sharp
        /// </summary>
        Sharp,
        /// <summary>
        /// The simpla
        /// </summary>
        Simpla,
        /// <summary>
        /// The simple grey
        /// </summary>
        SimpleGrey,
        /// <summary>
        /// The simplistic
        /// </summary>
        Simplistic,

        /// <summary>
        /// The situation
        /// </summary>
        Situation,
        /// <summary>
        /// The sky base
        /// </summary>
        SkyBase,
        /// <summary>
        /// The skype
        /// </summary>
        Skype,
        /// <summary>
        /// The SLC
        /// </summary>
        SLC,
        /// <summary>
        /// The somnium
        /// </summary>
        Somnium,
        /// <summary>
        /// The spicylips
        /// </summary>
        Spicylips,
        /// <summary>
        /// The steam
        /// </summary>
        Steam,
        /// <summary>
        /// The steam alt
        /// </summary>
        SteamAlt,
        /// <summary>
        /// The storm
        /// </summary>
        Storm,
        /// <summary>
        /// The studio
        /// </summary>
        Studio,
        /// <summary>
        /// The subspace
        /// </summary>
        Subspace,
        /// <summary>
        /// The sugar
        /// </summary>
        Sugar,
        /// <summary>
        /// The team viewer
        /// </summary>
        TeamViewer,
        /// <summary>
        /// The tech
        /// </summary>
        Tech,
        /// <summary>
        /// The teen
        /// </summary>
        Teen,
        /// <summary>
        /// The tennis
        /// </summary>
        Tennis,
        /// <summary>
        /// The black
        /// </summary>
        TheBlack,
        /// <summary>
        /// The thief
        /// </summary>
        Thief,
        /// <summary>
        /// The twitch
        /// </summary>
        Twitch,
        /// <summary>
        /// The ubuntu
        /// </summary>
        Ubuntu,
        /// <summary>
        /// The uclear
        /// </summary>
        Uclear,
        /// <summary>
        /// The uplay
        /// </summary>
        Uplay,
        /// <summary>
        /// The v theme
        /// </summary>
        VTheme,
        /// <summary>
        /// The visceral
        /// </summary>
        Visceral,
        /// <summary>
        /// The vitality
        /// </summary>
        Vitality,
        /// <summary>
        /// The vs
        /// </summary>
        Vs,
        /// <summary>
        /// The white
        /// </summary>
        White,
        /// <summary>
        /// The winter
        /// </summary>
        Winter,
        /// <summary>
        /// The xbox
        /// </summary>
        Xbox,
        /// <summary>
        /// The xtreme
        /// </summary>
        Xtreme,
        /// <summary>
        /// The x visual
        /// </summary>
        xVisual,
        /// <summary>
        /// The youtube
        /// </summary>
        Youtube,
        /// <summary>
        /// The zeus
        /// </summary>
        Zeus,
        /// <summary>
        /// The custom
        /// </summary>
        Custom


    }

    /// <summary>
    /// Class ThemeManager.
    /// </summary>
    public class ThemeManager
    {

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <param name="Theme">The theme.</param>
        /// <param name="BackColor">Color of the back.</param>
        /// <returns>Color.</returns>
        public static Color GetColor(Themes Theme, Color BackColor)
        {
            
            switch (Theme)
            {
                case Themes.EightBall:
                    return Color.FromArgb(60, 60, 60);
                case Themes.Adobe:
                    return Color.FromArgb(51, 51, 51);
                case Themes.Advanced_System:
                    return Color.FromArgb(30, 30, 40);
                case Themes.Advantium:
                    return Color.FromArgb(28, 28, 28); //Gradient 
                case Themes.Alpha:
                    return Color.FromArgb(105, 105, 105);
                case Themes.Angel:
                    return Color.FromArgb(17, 33, 47); // Header 37, 104, 168
                case Themes.Anom:
                    return Color.FromArgb(189, 189, 189);
                case Themes.Aryan:
                    return Color.FromArgb(25, 25, 25);
                case Themes.Atrocity:
                    return Color.FromArgb(41, 41, 41);
                case Themes.Avatar:
                    return Color.FromArgb(20, 28, 85);
                case Themes.AVG:
                    return Color.FromArgb(39, 43, 57);
                case Themes.BasicCode:
                    return Color.FromArgb(8, 8, 8);
                case Themes.BetaBlue:
                    return Color.FromArgb(0, 95, 218);
                case Themes.Beyond:
                    return Color.FromArgb(15, 15, 15);
                case Themes.Bionic:
                    return Color.FromArgb(48, 48, 48);
                case Themes.BitDefender:
                    return Color.FromArgb(32, 32, 32);
                case Themes.BlackShades:
                    return Color.FromArgb(42, 47, 49);
                case Themes.Bloody:
                    return Color.FromArgb(76, 0, 0);
                case Themes.Blue:
                    return Color.FromArgb(109, 132, 180);
                case Themes.Booster:
                    return Color.FromArgb(45, 45, 45);
                case Themes.Border:
                    return Color.FromArgb(15, 15, 15);
                case Themes.Bullion:
                    return Color.FromArgb(248, 248, 248);
                case Themes.ButterScotch:
                    return Color.FromArgb(34, 29, 23);
                case Themes.CarbonFibre:
                    return Color.FromArgb(22, 22, 22);
                case Themes.Chrome:
                    return Color.FromArgb(255, 255, 255);
                case Themes.Clarity:
                    return Color.FromArgb(32, 32, 32);
                case Themes.Classic:
                    return Color.FromArgb(18, 17, 17);
                case Themes.clsNeoBux:
                    return Color.FromArgb(36, 197, 97);
                case Themes.CocaCola:
                    return Color.FromArgb(179, 37, 47);
                case Themes.Complex:
                    return Color.FromArgb(211, 211, 211);
                case Themes.Crystal:
                    return Color.FromArgb(230, 230, 230);
                case Themes.Cypher:
                    return Color.FromArgb(25, 18, 12);
                case Themes.DarkMatter:
                    return Color.FromArgb(46, 46, 48);
                case Themes.DarkMatterAlt:
                    return Color.FromArgb(15, 15, 17);
                case Themes.Design:
                    return Color.FromArgb(25, 25, 25);
                case Themes.Destiny:
                    return Color.FromArgb(0, 90, 90);
                case Themes.Deumos:
                    return Color.FromArgb(14, 14, 14);
                case Themes.Doom:
                    return Color.FromArgb(30, 30, 30);
                case Themes.Drone:
                    return Color.FromArgb(24, 24, 24);
                case Themes.Earn:
                    return Color.FromArgb(75, 77, 89);
                case Themes.Effectual:
                    return Color.FromArgb(53, 53, 53);
                case Themes.Electric:
                    return Color.FromArgb(22, 84, 107);
                case Themes.Electrified:
                    return Color.FromArgb(205, 205, 205);
                case Themes.Elegant:
                    return Color.FromArgb(183, 210, 166);
                case Themes.Element:
                    return Color.FromArgb(41, 41, 41);
                case Themes.Empire:
                    return Color.FromArgb(55, 173, 242);
                case Themes.Empress:
                    return Color.FromArgb(222, 135, 58);
                case Themes.ETheme:
                    return Color.FromArgb(29, 29, 29);
                case Themes.Evolve:
                    return Color.FromArgb(47, 47, 47);
                case Themes.Excision:
                    return Color.FromArgb(53, 53, 53);
                case Themes.Exotic:
                    return Color.FromArgb(27, 28, 28);
                case Themes.Facebook:
                    return Color.FromArgb(67, 96, 156);
                case Themes.Festus:
                    return Color.FromArgb(224, 224, 224);
                case Themes.FlatUI:
                    return Color.FromArgb(60, 70, 73);
                case Themes.Flow:
                    return Color.FromArgb(35, 35, 35);
                case Themes.Frog:
                    return Color.FromArgb(60, 60, 60);
                case Themes.Fusion:
                    return Color.FromArgb(47, 47, 50);
                case Themes.Future:
                    return Color.FromArgb(34, 34, 34);
                case Themes.GTheme:
                    return Color.FromArgb(25, 25, 25);
                case Themes.GameBooster:
                    return Color.FromArgb(51, 51, 51);
                case Themes.Genuine:
                    return Color.FromArgb(41, 41, 41);
                case Themes.Ghostv2:
                    return Color.FromArgb(18, 18, 18);
                case Themes.GhostTheme:
                    return Color.FromArgb(18, 18, 18);
                case Themes.Gray:
                    return Color.FromArgb(47, 47, 47);
                case Themes.Green:
                    return Color.FromArgb(41, 57, 34);
                case Themes.Hacker:
                    return Color.FromArgb(14, 14, 14);
                case Themes.Hero:
                    return Color.FromArgb(211, 211, 211);
                case Themes.Hex:
                    return Color.FromArgb(30, 33, 40);
                case Themes.HF:
                    return Color.FromArgb(128, 41, 128);
                case Themes.Hura:
                    return Color.FromArgb(40, 40, 40);
                case Themes.iBlack:
                    return Color.FromArgb(35, 43, 49);
                case Themes.Influence:
                    return Color.FromArgb(20, 20, 20);
                case Themes.Influx:
                    return Color.FromArgb(83, 83, 83);
                case Themes.InnerDarkness:
                    return Color.FromArgb(9, 9, 9);
                case Themes.Insomia:
                    return Color.FromArgb(60, 60, 60);
                case Themes.Intel:
                    return Color.FromArgb(0, 191, 255);
                case Themes.JTheme:
                    return Color.FromArgb(20, 20, 20);
                case Themes.Knight:
                    return Color.FromArgb(46, 49, 61);
                case Themes.Light:
                    return Color.FromArgb(197, 197, 197);
                case Themes.Login:
                    return Color.FromArgb(35, 35, 35);
                case Themes.Loyal:
                    return Color.FromArgb(31, 31, 31);
                case Themes.Meph:
                    return Color.FromArgb(45, 45, 45);
                case Themes.Metal:
                    return Color.FromArgb(63, 63, 63);
                case Themes.MetroUI:
                    return Color.FromArgb(53, 157, 181);
                case Themes.MetroDisk:
                    return Color.FromArgb(45, 150, 45);
                case Themes.Modern:
                    return Color.FromArgb(232, 232, 232);
                case Themes.MPGH:
                    return Color.FromArgb(25, 78, 139);
                case Themes.Mumtz:
                    return Color.FromArgb(72, 209, 204);
                case Themes.Mystic:
                    return Color.FromArgb(25, 32, 39);
                case Themes.Nameless:
                    return Color.FromArgb(28, 28, 28);
                case Themes.NeoBux:
                    return Color.FromArgb(34, 195, 112);
                case Themes.NetSeal:
                    return Color.FromArgb(50, 50, 50);
                case Themes.New:
                    return Color.FromArgb(12, 27, 74);
                case Themes.NYX:
                    return Color.FromArgb(48, 48, 48);
                case Themes.Orains:
                    return Color.FromArgb(20, 20, 20);
                case Themes.Origin:
                    return Color.FromArgb(39, 38, 38);
                case Themes.Paladin:
                    return Color.FromArgb(173, 173, 173);
                case Themes.Patrick:
                    return Color.FromArgb(15, 15, 15);
                case Themes.Perplex:
                    return Color.FromArgb(48, 51, 53);
                case Themes.Positron:
                    return Color.FromArgb(208, 208, 208);
                case Themes.Prime:
                    return Color.FromArgb(232, 232, 232);
                case Themes.Purity:
                    return Color.FromArgb(60, 60, 60);
                case Themes.Qube:
                    return Color.FromArgb(68, 76, 99);
                case Themes.Reactor:
                    return Color.FromArgb(26, 25, 21);
                case Themes.Recon:
                    return Color.FromArgb(42, 42, 42);
                case Themes.Redwagon:
                    return Color.FromArgb(185, 0, 0);
                case Themes.Redemption:
                    return Color.FromArgb(15, 15, 15);
                case Themes.Resizable:
                    return Color.FromArgb(37, 37, 38);
                case Themes.Rockstar:
                    return Color.FromArgb(255, 227, 0);
                case Themes.Sasi:
                    return Color.FromArgb(168, 219, 4);
                case Themes.Secure:
                    return Color.FromArgb(53, 53, 53);
                case Themes.Sharp:
                    return Color.FromArgb(43, 53, 63);
                case Themes.Simpla:
                    return Color.FromArgb(34, 34, 34);
                case Themes.SimpleGrey:
                    return Color.FromArgb(128, 128, 128);
                case Themes.Simplistic:
                    return Color.FromArgb(70, 130, 180);
                case Themes.Situation:
                    return Color.FromArgb(47, 79, 79); //65, 65, 65
                case Themes.SkyBase:
                    return Color.FromArgb(62, 60, 58);
                case Themes.Skype:
                    return Color.FromArgb(148, 195, 255);
                case Themes.SLC:
                    return Color.FromArgb(34, 86, 118);
                case Themes.Somnium:
                    return Color.FromArgb(23, 23, 23);
                case Themes.Spicylips:
                    return Color.FromArgb(22, 22, 22);
                case Themes.Steam:
                    return Color.FromArgb(56, 54, 53);
                case Themes.SteamAlt:
                    return Color.FromArgb(35, 34, 32);
                case Themes.Storm:
                    return Color.FromArgb(90, 90, 110);
                case Themes.Studio:
                    return Color.FromArgb(56, 76, 106);
                case Themes.Subspace:
                    return Color.FromArgb(30, 30, 30);
                case Themes.Sugar:
                    return Color.FromArgb(190, 210, 217);
                case Themes.TeamViewer:
                    return Color.FromArgb(10, 112, 214);
                case Themes.Tech:
                    return Color.FromArgb(33, 52, 69);
                case Themes.Teen:
                    return Color.FromArgb(30, 144, 255);
                case Themes.Tennis:
                    return Color.FromArgb(35, 35, 35);
                case Themes.TheBlack:
                    return Color.FromArgb(0, 12, 12);
                case Themes.Thief:
                    return Color.FromArgb(164, 164, 164);
                case Themes.Twitch:
                    return Color.FromArgb(80, 50, 60);
                case Themes.Ubuntu:
                    return Color.FromArgb(81, 80, 75);
                case Themes.Uclear:
                    return Color.FromArgb(43, 43, 43);
                case Themes.Uplay:
                    return Color.FromArgb(58, 58, 58);
                case Themes.VTheme:
                    return Color.FromArgb(12, 12, 12);
                case Themes.Visceral:
                    return Color.FromArgb(19, 19, 19);
                case Themes.Vitality:
                    return Color.FromArgb(230, 230, 230);
                case Themes.Vs:
                    return Color.FromArgb(35, 49, 71);
                case Themes.White:
                    return Color.FromArgb(255,255,255);
                case Themes.Winter:
                    return Color.FromArgb(211, 222, 228);
                case Themes.Xbox:
                    return Color.FromArgb(10, 185, 0);
                case Themes.Xtreme:
                    return Color.FromArgb(36, 37, 45);
                case Themes.xVisual:
                    return Color.FromArgb(58, 55, 51);
                case Themes.Youtube:
                    return Color.FromArgb(215, 0, 0);
                case Themes.Zeus:
                    return Color.FromArgb(38, 38, 38);

                case Themes.Custom:
                    return BackColor;
                default:
                    return SystemColors.Control;
            }
            
        }
        
    }
}
