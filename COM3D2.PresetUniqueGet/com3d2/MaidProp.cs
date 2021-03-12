using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace COM3D2.PresetUniqueGet
{

	public class MaidProp
	{

		// Token: 0x06001C6B RID: 7275 RVA: 0x000D1DB0 File Offset: 0x000D01B0
		public bool Deserialize(BinaryReader f_brRead)
		{
			//NDebug.Assert(f_brRead.ReadString() == "CM3D2_MPROP", "メイドプロパティのヘッダーが不正です。");
			if (f_brRead.ReadString() != "CM3D2_MPROP")
			{
				MyLog.Log("メイドプロパティのヘッダーが不正です");
				return false;
			}
			int num = f_brRead.ReadInt32();
			this.idx = f_brRead.ReadInt32();
			if (num <= 110 && 10 <= this.idx)
			{
				this.idx += 2;
			}
			this.name = f_brRead.ReadString();
			this.idx = (int)Enum.Parse(typeof(MPN), this.name, true);
			this.type = f_brRead.ReadInt32();
			this.value_Default = f_brRead.ReadInt32();
			this.value = f_brRead.ReadInt32();
			if (101 <= num)
			{
				this.temp_value = f_brRead.ReadInt32();
			}
			this.value_LinkMAX = f_brRead.ReadInt32();
			this.strFileName = f_brRead.ReadString();
			this.nFileNameRID = f_brRead.ReadInt32();
			this.boDut = f_brRead.ReadBoolean();
			this.max = f_brRead.ReadInt32();
			this.min = f_brRead.ReadInt32();
			if (this.listSubProp != null && this.listSubProp.Count != 0)
			{
				this.listSubProp = null;
			}
			if (200 <= num)
			{
				int num2 = f_brRead.ReadInt32();
				if (num2 != 0)
				{
					this.listSubProp = new List<SubProp>();
				}
				for (int i = 0; i < num2; i++)
				{
					bool flag = f_brRead.ReadBoolean();
					if (flag)
					{
						SubProp subProp = new SubProp();
						subProp.bDut = f_brRead.ReadBoolean();
						subProp.strFileName = f_brRead.ReadString();
						subProp.nFileNameRID = f_brRead.ReadInt32();
						if (211 <= num)
						{
							subProp.fTexMulAlpha = f_brRead.ReadSingle();
						}
						subProp.bDut = true;
						this.listSubProp.Add(subProp);
					}
					else
					{
						this.listSubProp.Add(null);
					}
				}
			}
			else if (this.type == 3 && (this.name == "acctatoo" || this.name == "hokuro") && !string.IsNullOrEmpty(this.strFileName) && !this.strFileName.Contains("_del"))
			{
				this.listSubProp = new List<SubProp>();
				SubProp subProp2 = new SubProp();
				subProp2.bDut = true;
				subProp2.strFileName = this.strFileName;
				subProp2.nFileNameRID = this.nFileNameRID;
				this.listSubProp.Add(subProp2);
				this.strFileName = CM3.dicDelItem[(MPN)Enum.Parse(typeof(MPN), this.name, true)];
				this.nFileNameRID = this.strFileName.ToLower().GetHashCode();
			}
			if (this.name == "eye_hi" && string.IsNullOrEmpty(this.strFileName))
			{
				this.strFileName = "_I_SkinHi.menu";
				this.nFileNameRID = this.strFileName.ToLower().GetHashCode();
			}
			else if (this.name == "mayu" && string.IsNullOrEmpty(this.strFileName))
			{
				this.strFileName = "_I_mayu_001_mugen.menu";
				this.nFileNameRID = this.strFileName.ToLower().GetHashCode();
			}
			if (num <= 208 && this.idx == 65 && this.strFileName.ToLower() == "_I_acctatoo_del.menu".ToLower())
			{
				this.strFileName = CM3.dicDelItem[MPN.accnail];
				this.nFileNameRID = this.strFileName.ToLower().GetHashCode();
			}
			this.m_dicTBodySkinPos.Clear();
			this.m_dicTBodyAttachPos.Clear();
			this.m_dicMaterialProp.Clear();
			this.m_dicBoneLength.Clear();
			if (200 <= num)
			{
				int num3 = f_brRead.ReadInt32();
				for (int j = 0; j < num3; j++)
				{
					TBody.SlotID key = (TBody.SlotID)f_brRead.ReadInt32();
					int key2 = f_brRead.ReadInt32();
					BoneAttachPos boneAttachPos = new BoneAttachPos();
					boneAttachPos.bEnable = f_brRead.ReadBoolean();
					boneAttachPos.pss.position.x = f_brRead.ReadSingle();
					boneAttachPos.pss.position.y = f_brRead.ReadSingle();
					boneAttachPos.pss.position.z = f_brRead.ReadSingle();
					boneAttachPos.pss.rotation.x = f_brRead.ReadSingle();
					boneAttachPos.pss.rotation.y = f_brRead.ReadSingle();
					boneAttachPos.pss.rotation.z = f_brRead.ReadSingle();
					boneAttachPos.pss.rotation.w = f_brRead.ReadSingle();
					boneAttachPos.pss.scale.x = f_brRead.ReadSingle();
					boneAttachPos.pss.scale.y = f_brRead.ReadSingle();
					boneAttachPos.pss.scale.z = f_brRead.ReadSingle();
					KeyValuePair<int, BoneAttachPos> keyValuePair = new KeyValuePair<int, BoneAttachPos>(key2, boneAttachPos);
					this.m_dicTBodySkinPos[key] = keyValuePair;
				}
				int num4 = f_brRead.ReadInt32();
				for (int k = 0; k < num4; k++)
				{
					TBody.SlotID key3 = (TBody.SlotID)f_brRead.ReadInt32();
					int num5 = f_brRead.ReadInt32();
					Dictionary<string, KeyValuePair<int, VtxAttachPos>> dictionary = new Dictionary<string, KeyValuePair<int, VtxAttachPos>>();
					for (int l = 0; l < num5; l++)
					{
						string key4 = f_brRead.ReadString();
						int key5 = f_brRead.ReadInt32();
						VtxAttachPos vtxAttachPos = new VtxAttachPos();
						vtxAttachPos.bEnable = f_brRead.ReadBoolean();
						vtxAttachPos.vtxcount = f_brRead.ReadInt32();
						vtxAttachPos.vidx = f_brRead.ReadInt32();
						vtxAttachPos.prs.position.x = f_brRead.ReadSingle();
						vtxAttachPos.prs.position.y = f_brRead.ReadSingle();
						vtxAttachPos.prs.position.z = f_brRead.ReadSingle();
						vtxAttachPos.prs.rotation.x = f_brRead.ReadSingle();
						vtxAttachPos.prs.rotation.y = f_brRead.ReadSingle();
						vtxAttachPos.prs.rotation.z = f_brRead.ReadSingle();
						vtxAttachPos.prs.rotation.w = f_brRead.ReadSingle();
						vtxAttachPos.prs.scale.x = f_brRead.ReadSingle();
						vtxAttachPos.prs.scale.y = f_brRead.ReadSingle();
						vtxAttachPos.prs.scale.z = f_brRead.ReadSingle();
						dictionary.Add(key4, new KeyValuePair<int, VtxAttachPos>(key5, vtxAttachPos));
					}
					this.m_dicTBodyAttachPos.Add(key3, dictionary);
				}
				int num6 = f_brRead.ReadInt32();
				for (int m = 0; m < num6; m++)
				{
					TBody.SlotID slotID = (TBody.SlotID)f_brRead.ReadInt32();
					int key6 = f_brRead.ReadInt32();
					MatPropSave matPropSave = new MatPropSave();
					matPropSave.nMatNo = f_brRead.ReadInt32();
					matPropSave.strPropName = f_brRead.ReadString();
					matPropSave.strTypeName = f_brRead.ReadString();
					matPropSave.strValue = f_brRead.ReadString();
					if (num < 204 && slotID == TBody.SlotID.head && matPropSave.nMatNo == 3 && (matPropSave.strPropName == "_ZTest" || matPropSave.strPropName == "ZTest"))
					{
						matPropSave.strPropName = "_ZTest2";
						matPropSave.strValue = ((!(matPropSave.strValue == "8")) ? "1" : "7");
					}
					this.m_dicMaterialProp.Add(slotID, new KeyValuePair<int, MatPropSave>(key6, matPropSave));
				}
				if (213 <= num)
				{
					int num7 = f_brRead.ReadInt32();
					for (int n = 0; n < num7; n++)
					{
						TBody.SlotID key7 = (TBody.SlotID)f_brRead.ReadInt32();
						int key8 = f_brRead.ReadInt32();
						int num8 = f_brRead.ReadInt32();
						Dictionary<string, float> dictionary2 = new Dictionary<string, float>();
						for (int num9 = 0; num9 < num8; num9++)
						{
							string key9 = f_brRead.ReadString();
							float num10 = f_brRead.ReadSingle();
							dictionary2.Add(key9, num10);
						}
						this.m_dicBoneLength[key7] = new KeyValuePair<int, Dictionary<string, float>>(key8, dictionary2);
					}
				}
			}
			if (num < 200 && this.idx == 58 && Path.GetFileNameWithoutExtension(this.strFileName.ToLower()) == "hair_r095_i_")
			{
				this.strFileName = "hair_r110_i_.menu";
				this.nFileNameRID = this.strFileName.ToLower().GetHashCode();
			}
			this.boDut = true;
			this.boTempDut = false;
			this.strTempFileName = string.Empty;
			this.nTempFileNameRID = 0;
			return true;
		}

		

		public override bool Equals(object obj)
        {
            if (obj is MaidProp prop)
            {
				bool b = strFileName.Equals( prop.strFileName);
				//MyLog.Log("MaidProp.Equals:" + strFileName + "," + prop.strFileName + "," + b);
				return b;
			}
			return false;
        }

        public override int GetHashCode()
        {
			//MyLog.Log("MaidProp.GetHashCode:"+ strFileName+ ",\t" + strFileName.GetHashCode());
			return strFileName.GetHashCode();
		}


        // Token: 0x04001862 RID: 6242
        public int idx;

		// Token: 0x04001863 RID: 6243
		public string name;

		// Token: 0x04001864 RID: 6244
		public int type;

		// Token: 0x04001865 RID: 6245
		public int value_Default;

		// Token: 0x04001866 RID: 6246
		public int value;

		// Token: 0x04001867 RID: 6247
		public int temp_value;

		// Token: 0x04001868 RID: 6248
		public int value_LinkMAX;

		// Token: 0x04001869 RID: 6249
		public string strFileName = string.Empty;

		// Token: 0x0400186A RID: 6250
		public int nFileNameRID;

		// Token: 0x0400186B RID: 6251
		public string strTempFileName = string.Empty;

		// Token: 0x0400186C RID: 6252
		public int nTempFileNameRID;

		// Token: 0x0400186D RID: 6253
		public bool boDut;

		// Token: 0x0400186E RID: 6254
		public bool boTempDut;

		// Token: 0x0400186F RID: 6255
		public int max;

		// Token: 0x04001870 RID: 6256
		public int min;

		// Token: 0x04001871 RID: 6257
		public bool bSubDut;

		// Token: 0x04001872 RID: 6258
		public List<SubProp> listSubProp;

		// Token: 0x04001873 RID: 6259
		public bool bNoScale;

		// Token: 0x04001874 RID: 6260
		public bool boAdjustDut;

		// Token: 0x04001875 RID: 6261
		public Dictionary<TBody.SlotID, KeyValuePair<int, BoneAttachPos>> m_dicTBodySkinPos = new Dictionary<TBody.SlotID, KeyValuePair<int, BoneAttachPos>>();

		// Token: 0x04001876 RID: 6262
		public Dictionary<TBody.SlotID, Dictionary<string, KeyValuePair<int, VtxAttachPos>>> m_dicTBodyAttachPos = new Dictionary<TBody.SlotID, Dictionary<string, KeyValuePair<int, VtxAttachPos>>>();

		// Token: 0x04001877 RID: 6263
		public Dictionary<TBody.SlotID, KeyValuePair<int, MatPropSave>> m_dicMaterialProp = new Dictionary<TBody.SlotID, KeyValuePair<int, MatPropSave>>();

		// Token: 0x04001878 RID: 6264
		public Dictionary<TBody.SlotID, KeyValuePair<int, Dictionary<string, float>>> m_dicBoneLength = new Dictionary<TBody.SlotID, KeyValuePair<int, Dictionary<string, float>>>();
	}

}
