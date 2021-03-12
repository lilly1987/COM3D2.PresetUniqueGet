using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace COM3D2.PresetUniqueGet
{
    public static class PresetUtill
    {
        private static string presetDirectory;
        public static string PresetDirectorySub;

        public static string PresetDirectory { 
            get => presetDirectory; 
            set {
                presetDirectory = value;
                PresetDirectorySub = value+@"\bak";
            }
        }

        public static void test()
        {
            List<Preset> list = Preset.PresetListLoad();

            Preset item1 = Preset.PresetLoad(@"F:\COM3D2\Preset\pre_桜井翠里_20210313001622.preset");
            Preset item2 = Preset.PresetLoad(@"F:\COM3D2\Preset\pre_桜井翠里_20210313005101.preset");
            
            //MyLog.Log("프리셋 파일 수" + item1.Equals(item2));//정상
            MyLog.Log("프리셋 파일 수" + list.Contains(item2));//정상

        }

        public static void GetUniqueProc()
        {
            List<Preset> list = Preset.PresetListLoad();

            MyLog.Log("프리셋 파일 수" + list.Count);

            GetUniqueProcSub(list, PresetType.Wear);
            GetUniqueProcSub(list, PresetType.Body);
            GetUniqueProcSub(list, PresetType.All);
        }

        //static PersonComparer comparer = new PersonComparer();

        public static void GetUniqueProcSub(List<Preset> list, PresetType t)
        {
            List<Preset> listt = (
                from p in list
                where p.ePreType == t
                select new Preset(p.strFileName, p.listMprop)
                ).ToList();
            MyLog.Log(t+":" + listt.Count);

            var result1 = (from p in listt select p).Distinct().Select(p => p.strFileName);// 아무것도 ㅇ벗을시 equal 사용
            var result2 = (from p in listt select p).Select(p=>p.strFileName);
            var result3 = result2.Except(result1);
            
            MyLog.Log(t+":" + result1.Count<string>());
            MyLog.Log(t+":" + result2.Count<string>());
            MyLog.Log(t+":" + result3.Count<string>());

            DirectoryInfo d=new DirectoryInfo(PresetDirectorySub+t);
            if (!d.Exists)
            {
                d.Create();
            }

            foreach (var item in result3)
            {
            string source_file = System.IO.Path.Combine(presetDirectory, item);
            string dest_file =   System.IO.Path.Combine(PresetDirectorySub+t, item);

            MyLog.Log(source_file);
            MyLog.Log(dest_file);
            System.IO.File.Move(source_file, dest_file);

            }
        }
    }


}
