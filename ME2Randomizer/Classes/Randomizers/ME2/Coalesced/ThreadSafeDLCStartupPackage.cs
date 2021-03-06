﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendaryExplorerCore.Misc;

namespace ME2Randomizer.Classes.Randomizers.ME2.Coalesced
{
    public static class ThreadSafeDLCStartupPackage
    {
        private static object syncObj = new object();

        /// <summary>
        /// Adds a startup package to always be loaded in memory. Be extremely careful using this.
        /// </summary>
        /// <param name="packagename"></param>
        /// <returns></returns>
        public static bool AddStartupPackage(string packagename)
        {
            lock (syncObj)
            {
                var engine = CoalescedHandler.GetIniFile("BIOEngine.ini");
                var sp = engine.GetOrAddSection("Engine.StartupPackages");
                if (sp.Entries.Any(x => x.Key == "+DLCStartupPackage" && x.Value == packagename))
                    return true; //It's already been added.
                sp.Entries.Add(new DuplicatingIni.IniEntry("+DLCStartupPackage", packagename));
                return true;
            }
        }
    }
}
