using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DingoUnityProjectMastering.StringConfigurator.Core.Utils
{
    public static class InspectorUtils
    {
        public static readonly IReadOnlyList<string> SingleNoneList = new List<string>{StringConstants.NONE};
        
        public static IReadOnlyList<string> CollectOrNone(Func<IReadOnlyList<string>> collectAction)
        {
            try
            {
                var list = collectAction();
                if (list == null || list.Count == 0)
                    return SingleNoneList;
                return list;
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
            }
            return SingleNoneList;
        }

        public static bool IsNoneList(this IReadOnlyList<string> list)
        {
            if (list == null || list.Count == 0)
                return true;

            if (Equals(list, SingleNoneList) || list.Count == 1 && list.FirstOrDefault() == StringConstants.NONE)
                return true;

            return false;
        }
    }
}