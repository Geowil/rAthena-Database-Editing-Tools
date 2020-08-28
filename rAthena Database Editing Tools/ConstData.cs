using System;
using System.Collections.Generic;

namespace rAthena_Database_Editing_Tools
{
    public static class ConstData
    {

        public static Dictionary<String, int> mobSizes = new Dictionary<String, int>(){
            {"Large", 2},
            {"Medium", 1},
            {"Small", 0}
        };

        public static Dictionary<String, int> mobRaces = new Dictionary<String, int>()
        {
            {"Angel", 8},
            {"Brute", 2},
            {"Demi-Human", 7},
            {"Demon", 6},
            {"Dragon", 9},
            {"Fish", 5},
            {"Formless", 0},
            {"Insect", 4},
            {"Plant", 3},
            {"Player", 10},
            {"Undead", 1}
        };

        public static Dictionary<String, uint> mobBehaviorMasks = new Dictionary<String, uint>() {
            {"None",0},
            {"Agressive 1", 8325},
            {"Agressive 2", 28805},
            {"Agressive 3 (Guardian 1)", 12437},
            {"Agressive 4 (Guardian 2)", 132},
            {"Agressive 5 (Guardian 3)", 8325},
            {"Agressive 6", 12429},
            {"Agressive 7", 12437},
            {"Agressive 8", 12949},
            {"Agressive 9", 13973},
            {"Agressive 10", 46741},
            {"Agressive 11", 32900},
            {"Angry", 14469},
            {"Passive", 192},
            {"Passive 2", 131},
            {"Passive 3", 4233},
            {"Passive 4 (Plant)",0},
            {"Passive 5", 4235},
            {"Passive 6", 145},
            {"Passive 7 (Slave)", 161},
            {"Passive 8 (Pet)",1}
        };

        public static Dictionary<String, uint> mobClassMasks = new Dictionary<String, uint>() {
            {"None",0},
            { "Battlefield Mob", 201326592},
            {"Boss Mob", 102760448},
            {"Event Mob", 16777216},
            {"Guardian Mob", 67108864}
        };

        public static List<uint> mobBehaviorVals = new List<uint>()
        {
            1,2,4,6,16,512,128,64,4096,8192,1024,16384,2048,32768,65536,
            262144,131072,1048576,524288,4194304,2097152,33554432,16777216,
            134217728,67108864,32
        };

        public static Dictionary<String, int> itemTypes = new Dictionary<String, int>() {
            {"Ammo (Arrows/Bullets/Etc)", 10},
            {"Armor/Garment/Boots/Headgear/Accessory", 4},
            {"Card", 6},
            {"Etc", 3},
            {"Healing", 0},
            {"Pet Egg", 11},
            {"Pet Equipment", 7},
            {"Shadow Equipment", 12},
            {"Usable", 2},
            {"Usable (Delayed Consumption; Confirmation)", 18},
            {"Usable(Delayed Consumption; Targetable)", 11},
            {"Weapon", 5}
        };

        public static Dictionary<String, int> genderTypes = new Dictionary<String, int>() {
            {"Both", 2},
            {"Female", 0},
            {"Male", 1}
        };

        public static Dictionary<String, uint> itemLocations = new Dictionary<String, uint>() {
            {"Accessory Left", 128},
            {"Accessory Right", 8},
            {"Ammo", 32768},
            {"Armor", 16},
            {"Costume Garment/Robe", 8192},
            {"Costume Low Headgear", 4096},
            {"Costum Middle Headgear", 2048},
            {"Costum Upper Headgear", 1024},
            {"Footgear", 64},
            {"Garment", 4},
            {"Lower Headgrear", 1},
            {"Middle Headgear", 512},
            {"Shadow Accessory Left", 2097152},
            {"Shadow Accessroy Right", 1048576},
            {"Shadow Armor", 65536},
            {"Shadow Shield", 262144},
            {"Shadow Shoes", 524288},
            {"Shadow Weapon", 131072},
            {"Shield", 32},
            {"Upper Headgear", 256},
            {"Weapon", 2}
        };

        public static List<uint> jobMaskVals = new List<uint>()
        {
            1,2,4,8,16,32,64,128,256,512,1024,2048,4096,16384,32768,65536,131072,
            262144,524288,2097152,4194304,8388608,16777216,33554432,67108864,
            134217728,268435456,536870912,1073741824,2147483648
        };

        public static List<int> classMaskVals = new List<int>(){
            1,2,4,8,16,32
        };

        public static List<String> mobColNames = new List<String>()
        {
            "ID","Sprite_Name","kROName","iROName","LV","HP","SP","EXP","JEXP","Range1","ATK1","ATK2","DEF","MDEF",
            "STR","AGI","VIT","INT","DEX","LUK","Range2","Range3","Scale","Race","Element","Mode","Speed","aDelay",
            "aMotion","dMotion","MEXP","MVP1id","MVP1per","MVP2id","MVP2per","MVP3id","MVP3per","Drop1id","Drop1per",
            "Drop2id","Drop2per","Drop3id","Drop3per","Drop4id","Drop4per","Drop5id","Drop5per","Drop6id","Drop6per",
            "Drop7id","Drop7per","Drop8id","Drop8per","Drop9id","Drop9per","DropCardid","DropCardper"
        };

        public static List<String> itemColNames = new List<String>()
        {
            "id","name_english","name_japanese","type","price_buy","price_sell",
            "weight","`atk:matk`","defence","range","slots","equip_jobs",
            "equip_upper","equip_genders","equip_locations","weapon_level",
            "equip_level","refineable","view","script","equip_script","unequip_script"
        };

    }
}