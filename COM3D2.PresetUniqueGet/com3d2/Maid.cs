using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace COM3D2.PresetUniqueGet
{
    class Maid
    {
		public static MaidProp CreateProp(int minval, int maxval, int defval, MPN mpn, int type)
		{
			NDebug.Assert(type == 0 || type == 1 || type == 2, "プロパティオブジェクトのタイプが不正です。");
			MaidProp maidProp = new MaidProp();
			maidProp.name = mpn.ToString();
			maidProp.type = type;
			maidProp.min = minval;
			maidProp.max = maxval;
			if (defval < minval)
			{
				defval = minval;
			}
			if (defval > maxval)
			{
				defval = maxval;
			}
			maidProp.value_Default = defval;
			maidProp.listSubProp = null;
			maidProp.strFileName = string.Empty;
			maidProp.temp_value = (maidProp.value = defval);
			maidProp.idx = (int)mpn;
			maidProp.boDut = true;
			maidProp.boTempDut = false;
			return maidProp;
		}

		public static bool DeserializeBodyRead(BinaryReader f_brRead)
		{
			string a = f_brRead.ReadString();
			if (a != "CM3D2_MAID_BODY")
			{
				MyLog.Log("메이드 Body 헤더가 잘못되었습니다.");
				return false;
			}
			//NDebug.Assert(a == "CM3D2_MAID_BODY", "메이드 Body 헤더가 잘못되었습니다.");
			int num = f_brRead.ReadInt32();
			return true;
		}

		public static List<MaidProp> DeserializePropPre(BinaryReader f_brRead)
		{
			List<MaidProp> list = new List<MaidProp>();
			string a = f_brRead.ReadString();
			if (a != "CM3D2_MPROP_LIST")
			{
				MyLog.Log("메이드 속성 목록의 헤더가 잘못되었습니다。");
				return null;
			}
			//NDebug.Assert(a == "CM3D2_MPROP_LIST", "메이드 속성 목록의 헤더가 잘못되었습니다。");
			int num = f_brRead.ReadInt32();
			int num2 = f_brRead.ReadInt32();
			HashSet<MPN> hashSet = new HashSet<MPN>();
			for (int i = 0; i < num2; i++)
			{
				if (4 <= num)
				{
					string text = f_brRead.ReadString();
				}
				MaidProp maidProp = new MaidProp();
				maidProp.Deserialize(f_brRead);
				hashSet.Add((MPN)maidProp.idx);
				list.Add(maidProp);
				if (num <= 110 && maidProp.idx == 10)
				{
					list.Add(new MaidProp
					{
						type = maidProp.type,
						idx = 11,
						name = MPN.EyeSclX.ToString(),
						value = maidProp.value,
						min = maidProp.min,
						max = maidProp.max,
						boDut = true
					});
					list.Add(new MaidProp
					{
						type = maidProp.type,
						idx = 12,
						name = MPN.EyeSclY.ToString(),
						value = maidProp.value,
						min = maidProp.min,
						max = maidProp.max,
						boDut = true
					});
				}
			}
			if (num < 200)
			{
				list.Add(Maid.CreateProp(0, 100, 0, MPN.EyeClose, 2));
				list.Add(Maid.CreateProp(0, 100, 0, MPN.FaceShape, 2));
				list.Add(Maid.CreateProp(0, 100, 50, MPN.MayuX, 2));
				list.Add(Maid.CreateProp(0, 100, 50, MPN.MayuY, 2));
			}
			if (num < 210)
			{
				list.Add(Maid.CreateProp(0, 100, 50, MPN.EyeBallPosX, 2));
				list.Add(Maid.CreateProp(0, 100, 50, MPN.EyeBallPosY, 2));
				list.Add(Maid.CreateProp(0, 100, 50, MPN.EyeBallSclX, 2));
				list.Add(Maid.CreateProp(0, 100, 50, MPN.EyeBallSclY, 2));
			}
			if (!hashSet.Contains(MPN.FaceShapeSlim))
			{
				list.Add(Maid.CreateProp(0, 100, 0, MPN.FaceShapeSlim, 2));
			}
			if (!hashSet.Contains(MPN.EarNone))
			{
				list.Add(Maid.CreateProp(0, 1, 0, MPN.EarNone, 2));
			}
			if (!hashSet.Contains(MPN.EarElf))
			{
				list.Add(Maid.CreateProp(0, 100, 0, MPN.EarElf, 2));
			}
			if (!hashSet.Contains(MPN.EarRot))
			{
				list.Add(Maid.CreateProp(0, 100, 50, MPN.EarRot, 2));
			}
			if (!hashSet.Contains(MPN.EarScl))
			{
				list.Add(Maid.CreateProp(0, 100, 50, MPN.EarScl, 2));
			}
			if (!hashSet.Contains(MPN.NosePos))
			{
				list.Add(Maid.CreateProp(0, 100, 50, MPN.NosePos, 2));
			}
			if (!hashSet.Contains(MPN.NoseScl))
			{
				list.Add(Maid.CreateProp(0, 100, 50, MPN.NoseScl, 2));
			}
			if (!hashSet.Contains(MPN.MayuShapeIn))
			{
				list.Add(Maid.CreateProp(0, 100, 50, MPN.MayuShapeIn, 2));
			}
			if (!hashSet.Contains(MPN.MayuShapeOut))
			{
				list.Add(Maid.CreateProp(0, 100, 50, MPN.MayuShapeOut, 2));
			}
			if (!hashSet.Contains(MPN.MayuRot))
			{
				list.Add(Maid.CreateProp(0, 100, 50, MPN.MayuRot, 2));
			}
			return list;
		}


		// Token: 0x06001C5E RID: 7262 RVA: 0x000D0E74 File Offset: 0x000CF274

	}

}
