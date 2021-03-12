using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace COM3D2.PresetUniqueGet
{
    class PresetComparer : IEqualityComparer<Preset>
    {
        public bool Equals([AllowNull] Preset x, [AllowNull] Preset y)
        {
            return x.Equals(y);
        }

        public int GetHashCode([DisallowNull] Preset obj)
        {
            return obj.listMprop.GetHashCode();
        }
    }
    
    class MaidPropComparer : IEqualityComparer<MaidProp>
    {
        public bool Equals([AllowNull] MaidProp x, [AllowNull] MaidProp y)
        {
            //MyLog.Log("Preset.Equals:" + x.strFileName + " ,\t " + y.strFileName + " ,\t " +  x.Equals(y));
            return x.Equals(y);
        }

        public int GetHashCode([DisallowNull] MaidProp obj)
        {
            return obj.GetHashCode();
        }
    }

    public class ListMaidPropComparer<MaidProp> : IEqualityComparer<List<MaidProp>>
    {
        IEqualityComparer<MaidProp> itemComparer;

        public ListMaidPropComparer()
        {
            itemComparer = EqualityComparer<MaidProp>.Default;
        }

        public ListMaidPropComparer(IEqualityComparer<MaidProp> innerComparer)
        {
            itemComparer = innerComparer;
        }

        public bool Equals(List<MaidProp> x, List<MaidProp> y)
        {
            return x.SequenceEqual(y, itemComparer);
        }

        public int GetHashCode(List<MaidProp> obj)
        {
            int somePrimeNumber = 37;

            int result = 1;
            foreach (MaidProp item in obj.Take(5))
            {
                result = (somePrimeNumber * result) + itemComparer.GetHashCode(item);
            }

            return result;
        }
    }

}
