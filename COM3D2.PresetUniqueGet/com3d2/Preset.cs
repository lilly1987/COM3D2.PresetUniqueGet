using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace COM3D2.PresetUniqueGet
{
    
    public class Preset
    {
        public Preset(string strFileName, List<MaidProp> listMprop)
        {
            this.strFileName = strFileName;
            this.listMprop = listMprop;
        }

        public Preset()
        {
        }

        // Token: 0x040014D6 RID: 5334
        public int nVersion;

        // Token: 0x040014D8 RID: 5336
        public string strFileName;

        // Token: 0x040014D9 RID: 5337
        public PresetType ePreType;


        // Token: 0x040014DA RID: 5338
        public List<MaidProp> listMprop = new List<MaidProp>();


        public MaidParts.PartsColor[] aryPartsColor;





        public static List<Preset> PresetListLoad()
        {
            List<Preset> list = new List<Preset>();
            string presetDirectory = PresetUtill.PresetDirectory;
            if (!Directory.Exists(presetDirectory))
            {
                return null;
            }
            foreach (string f_strFileName in Directory.GetFiles(presetDirectory, "*.preset"))
            {
                MyLog.Log(f_strFileName);
                Preset item = PresetLoad(f_strFileName);
                if (item == null)
                {
                    continue;
                }
                list.Add(item);
            }
            return list;
        }

        public static Preset PresetLoad(string f_strFileName)
        {
            FileStream fileStream = new FileStream(f_strFileName, FileMode.Open);
            if (fileStream == null)
            {
                return null;
            }
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, (int)fileStream.Length);
            fileStream.Close();
            fileStream.Dispose();
            BinaryReader binaryReader = new BinaryReader(new MemoryStream(buffer));
            Preset result = PresetLoad(binaryReader, Path.GetFileName(f_strFileName));
            binaryReader.Close();
            return result;
        }

        public static Preset PresetLoad(BinaryReader brRead, string f_strFileName)
        {
            Preset preset = new Preset();
            preset.strFileName = f_strFileName;
            string a = brRead.ReadString();
            if (a != "CM3D2_PRESET")
            {
                MyLog.Log("프리셋 파일의 헤더가 잘못되었습니다。");
                return null;
            }
            //NDebug.Assert(a == "CM3D2_PRESET", "프리셋 파일의 헤더가 잘못되었습니다。");
            int num = brRead.ReadInt32();
            preset.nVersion = num;
            int ePreType = brRead.ReadInt32();
            preset.ePreType = (PresetType)ePreType;
            int num2 = brRead.ReadInt32();
            if (num2 != 0)
            {
                byte[] data = brRead.ReadBytes(num2);
                //preset.texThum = new Texture2D(1, 1);
                //preset.texThum.LoadImage(data);
                //preset.texThum.wrapMode = TextureWrapMode.Clamp;
            }
            else
            {
                //preset.texThum = null;
            }
            preset.listMprop = Maid.DeserializePropPre(brRead);
            if (num >= 2)
            {
                preset.aryPartsColor = MaidParts.DeserializePre(brRead);
            }
            if (num >= 200)
            {
                Maid.DeserializeBodyRead(brRead);
            }
            return preset;
        }

        static MaidPropComparer comparer = new MaidPropComparer();

        public override bool Equals(object obj)
        {
            if (obj is Preset preset)
            {
                //MyLog.Log("Preset.Equals:" + strFileName + "," + preset.strFileName );
                //static MaidPropComparerUtill comparer = new MaidPropComparerUtill();
                //return listMprop.SequenceEqual( preset.listMprop); //이건 정렬된거 한정
                return !listMprop.Except(preset.listMprop, comparer).Any() && !preset.listMprop.Except(listMprop, comparer).Any();
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                foreach (var foo in listMprop)
                {
                    //MyLog.Log("Preset.Mprop.GetHashCode:" + hash);
                    hash = hash * 31 + foo.GetHashCode();
                }
                //MyLog.Log("Preset.listMprop.GetHashCode:" + hash);
                return hash;
            }
            return listMprop.GetHashCode();
        }
    }

    public enum PresetType
    {
        // Token: 0x040014D3 RID: 5331
        Wear,
        // Token: 0x040014D4 RID: 5332
        Body,
        // Token: 0x040014D5 RID: 5333
        All
    }


}
