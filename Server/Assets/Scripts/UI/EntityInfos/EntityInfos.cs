﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace PhotonB4
{
    public class EntityInfos
    {
        public VitalInfos vitalInfos = new VitalInfos();
        //ResistanceInfos res = new ResistanceInfos();
        //Str, intel etc...
        public BaseStatsInfos baseStats = new BaseStatsInfos();

        //Buffs and items
        public VitalInfos vitalInfosBon = new VitalInfos();
        public BaseStatsInfos baseStatsBon = new BaseStatsInfos();
        public ResistanceInfos resBon = new ResistanceInfos();
        public SpellBonusInfos spellBon = new SpellBonusInfos();

        public SpecialEffects specialEffects = new SpecialEffects();

        //appearance for players and npcs
        public String model = "";
        public string classe = "Monster";
        public float range = 4f;
        public float attackMoveSpeed = 0.1f;
        public float baseSpeed = 0.3f;
        public int level=1;
        public bool ridable = false;
        public bool isBoss = false;
        public float castRate = 1; //the percentage of chances the unit will was a spell instead of attacking.

        public string[] spells = new string[0]; //combat spells
        public string[] nonCombatSpells = new string[0];
        public string[] defensiveSpells = new string[0];
        public Dictionary<string, float> itemsDropped = new Dictionary<string,float>(); //the float is the drop rate /1
        public string[] invokeOnDeath = new string[0];

        public EntityInfos()
        {}

        public EntityInfos(String _model)
        {
            model = _model;
        }

        public EntityInfos(EntityInfos original)
        {
            vitalInfos = new VitalInfos(original.vitalInfos);
            baseStats = new BaseStatsInfos(original.baseStats);
            vitalInfosBon = new VitalInfos(original.vitalInfosBon);
            baseStatsBon = new BaseStatsInfos(original.baseStatsBon);
            resBon = new ResistanceInfos(original.resBon);
            spellBon = new SpellBonusInfos(original.spellBon);

            specialEffects = original.specialEffects;
            model = original.model;
            range = original.range;
            attackMoveSpeed = original.attackMoveSpeed;
            baseSpeed = original.baseSpeed;
            level = original.level;
            ridable = original.ridable;
            isBoss = original.isBoss;

            spells = original.spells;
            invokeOnDeath = original.invokeOnDeath;
            castRate = original.castRate;
            classe = original.classe;
        }
        public String toString()
        {
            return "EntityInfos";
        }

        public int toInt()
        {
            float totalXp = baseStats.agi + baseStats.intel + baseStats.sou + baseStats.sta + baseStats.str;
            totalXp += baseStatsBon.agi + baseStatsBon.intel + baseStatsBon.sou + baseStatsBon.sta + baseStatsBon.str;

            return (int)totalXp;
        }
		
		public Hashtable toHashtable()
		{
			Hashtable tmpInfos = new Hashtable();
			tmpInfos.Add("vitalInfos", vitalInfos.toHashtable());
			tmpInfos.Add("baseStats", baseStats.toHashtable());
			tmpInfos.Add("vitalInfosBon", vitalInfosBon.toHashtable());
			tmpInfos.Add("baseStatsBon", baseStatsBon.toHashtable());
			tmpInfos.Add("resBon", resBon.toHashtable());
			tmpInfos.Add("spellBon", spellBon.toHashtable());
			tmpInfos.Add("specialEffects", specialEffects.toHashtable());
			
			tmpInfos.Add("model", model);
			tmpInfos.Add("range", range);
			tmpInfos.Add("attackMoveSpeed", attackMoveSpeed);
			tmpInfos.Add("baseSpeed", baseSpeed);
			tmpInfos.Add("level", level);

            return tmpInfos;
		}
    }
}
