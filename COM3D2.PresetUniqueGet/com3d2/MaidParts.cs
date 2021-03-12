using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace COM3D2.PresetUniqueGet
{

    public class MaidParts
    {
		public unsafe static MaidParts.PartsColor[] DeserializePre(BinaryReader f_brRead)
		{
			MaidParts.PartsColor[] array = new MaidParts.PartsColor[13];
			for (int i = 0; i < 13; i++)
			{
				array[i] = MaidParts.m_aryPartsColorDefault[i];
			}
			string a = f_brRead.ReadString();
			if (a != "CM3D2_MULTI_COL")
			{
				MyLog.Log("無限色のヘッダーが不正です。");
				return null;
			}
			//NDebug.Assert(a == "CM3D2_MULTI_COL", "無限色のヘッダーが不正です。");
			int num = f_brRead.ReadInt32();
			int num2 = f_brRead.ReadInt32();
			if (num <= 1200 && ((200 > num) ? (7 != num2) : (9 != num2)))
			{
				//NDebug.Assert("無限色数が異なります。セーブデータが破損しています。", false);
				return null;
			}
			if (num <= 1200)
			{
				string[] array2 = new string[]
				{
				"EYE_L",
				"EYE_R",
				"HAIR",
				"EYE_BROW",
				"UNDER_HAIR",
				"SKIN",
				"NIPPLE",
				"HAIR_OUTLINE",
				"SKIN_OUTLINE"
				};
				for (int j = 0; j < num2; j++)
				{
					MaidParts.PartsColor partsColor = default(MaidParts.PartsColor);
					partsColor.m_bUse = f_brRead.ReadBoolean();
					partsColor.m_nMainHue = f_brRead.ReadInt32();
					partsColor.m_nMainChroma = f_brRead.ReadInt32();
					partsColor.m_nMainBrightness = f_brRead.ReadInt32();
					partsColor.m_nMainContrast = f_brRead.ReadInt32();
					partsColor.m_nShadowRate = f_brRead.ReadInt32();
					partsColor.m_nShadowHue = f_brRead.ReadInt32();
					partsColor.m_nShadowChroma = f_brRead.ReadInt32();
					partsColor.m_nShadowBrightness = f_brRead.ReadInt32();
					partsColor.m_nShadowContrast = f_brRead.ReadInt32();
					MaidParts.PARTS_COLOR parts_COLOR = (MaidParts.PARTS_COLOR)Enum.Parse(typeof(MaidParts.PARTS_COLOR), array2[j], true);
					array[(int)parts_COLOR] = partsColor;
				}
			}
			else
			{
				string value;
				while ((value = f_brRead.ReadString()) != MaidParts.PARTS_COLOR.MAX.ToString())
				{
					PARTS_COLOR parts_COLOR2 = (PARTS_COLOR)Enum.Parse(typeof(PARTS_COLOR), value, true);
					fixed (MaidParts.PartsColor* ptr = &array[(int)parts_COLOR2])
					{
						ptr->m_bUse = f_brRead.ReadBoolean();
						ptr->m_nMainHue = f_brRead.ReadInt32();
						ptr->m_nMainChroma = f_brRead.ReadInt32();
						ptr->m_nMainBrightness = f_brRead.ReadInt32();
						ptr->m_nMainContrast = f_brRead.ReadInt32();
						ptr->m_nShadowRate = f_brRead.ReadInt32();
						ptr->m_nShadowHue = f_brRead.ReadInt32();
						ptr->m_nShadowChroma = f_brRead.ReadInt32();
						ptr->m_nShadowBrightness = f_brRead.ReadInt32();
						ptr->m_nShadowContrast = f_brRead.ReadInt32();
					}
				}
			}
			return array;
		}


		// Token: 0x040017A3 RID: 6051
		private static readonly MaidParts.PartsColor[] m_aryPartsColorDefault = new MaidParts.PartsColor[]
		{
		new MaidParts.PartsColor
		{
			m_nMainHue = 6,
			m_nMainChroma = 117,
			m_nMainBrightness = 179,
			m_nMainContrast = 94
		},
		new MaidParts.PartsColor
		{
			m_nMainHue = 6,
			m_nMainChroma = 117,
			m_nMainBrightness = 179,
			m_nMainContrast = 94
		},
		new MaidParts.PartsColor
		{
			m_nMainHue = 69,
			m_nMainChroma = 186,
			m_nMainBrightness = 270,
			m_nMainContrast = 94
		},
		new MaidParts.PartsColor
		{
			m_nMainHue = 0,
			m_nMainChroma = 0,
			m_nMainBrightness = 183,
			m_nMainContrast = 0
		},
		new MaidParts.PartsColor
		{
			m_nMainHue = 0,
			m_nMainChroma = 0,
			m_nMainBrightness = 0,
			m_nMainContrast = 0
		},
		new MaidParts.PartsColor
		{
			m_nMainHue = 18,
			m_nMainChroma = 149,
			m_nMainBrightness = 247,
			m_nMainContrast = 100
		},
		new MaidParts.PartsColor
		{
			m_nMainHue = 18,
			m_nMainChroma = 149,
			m_nMainBrightness = 247,
			m_nMainContrast = 100
		},
		new MaidParts.PartsColor
		{
			m_nMainHue = 69,
			m_nMainChroma = 0,
			m_nMainBrightness = 67,
			m_nMainContrast = 100
		},
		new MaidParts.PartsColor
		{
			m_nMainHue = 18,
			m_nMainChroma = 100,
			m_nMainBrightness = 138,
			m_nMainContrast = 85
		},
		new MaidParts.PartsColor
		{
			m_nMainHue = 18,
			m_nMainChroma = 36,
			m_nMainBrightness = 434,
			m_nMainContrast = 100,
			m_nShadowRate = 255,
			m_nShadowHue = 18,
			m_nShadowChroma = 79,
			m_nShadowBrightness = 321,
			m_nShadowContrast = 0
		},
		new MaidParts.PartsColor
		{
			m_nMainHue = 0,
			m_nMainChroma = 56,
			m_nMainBrightness = 185,
			m_nMainContrast = 47
		},
		new MaidParts.PartsColor
		{
			m_nMainHue = 0,
			m_nMainChroma = 56,
			m_nMainBrightness = 185,
			m_nMainContrast = 47
		},
		new MaidParts.PartsColor
		{
			m_nMainHue = 18,
			m_nMainChroma = 60,
			m_nMainBrightness = 200,
			m_nMainContrast = 128
		}
		};


		public struct PartsColor
        {
            public bool m_bUse;
            public int m_nMainHue;
            public int m_nMainChroma;
            public int m_nMainBrightness;
            public int m_nMainContrast;
            public int m_nShadowRate;
            public int m_nShadowHue;
            public int m_nShadowChroma;
            public int m_nShadowBrightness;
            public int m_nShadowContrast;
        }


        public enum PARTS_COLOR
        {
            NONE = -1,
            EYE_L = 0,
            EYE_R = 1,
            HAIR = 2,
            EYE_BROW = 3,
            UNDER_HAIR = 4,
            SKIN = 5,
            NIPPLE = 6,
            HAIR_OUTLINE = 7,
            SKIN_OUTLINE = 8,
            EYE_WHITE = 9,
            MATSUGE_UP = 10,
            MATSUGE_LOW = 11,
            FUTAE = 12,
            MAX = 13
        }
    }


}
