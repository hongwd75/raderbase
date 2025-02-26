

using System;

namespace RadarBase.Objects
{
	enum eRealm
	{
		none = 0,
		Albion = 1,
		Midgard,
		Hibernia,

	}

	public enum eRace
	{
		Unknown = 0,
		Briton = 1,
		Avalonian = 2,
		Highlander = 3,
		Saracen = 4,
		Norseman = 5,
		Troll = 6,
		Dwarf = 7,
		Kobold = 8,
		Celt = 9,
		Firbolg = 10,
		Elf = 11,
		Lurikeen = 12,
		Inconnu = 13,
		Valkyn = 14,
		Sylvan = 15,
		HalfOgre = 16,
		Frostalf = 17,
		Shar = 18,
		AlbionMinotaur = 19,
		MidgardMinotaur = 20,
		HiberniaMinotaur = 21,
		Korazh = 19,
		Deifrang = 20,
		Graoch = 21,
	}


	public enum eObjectTag
	{
		ChargeEnd,
		StunImmunity,
		MezImmunity,
	}

	[Flags]
	public enum ObjectState 
    {
		none = 0,
		Mez = 1,
		Stun = 1 << 1,
		Root = 1 << 2,
		Chage = 1 << 3,
		Stealth = 1 << 4,
    }
}
