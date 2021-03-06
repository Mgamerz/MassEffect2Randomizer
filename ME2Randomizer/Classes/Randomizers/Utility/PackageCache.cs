﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MassEffectRandomizer.Classes;
using LegendaryExplorerCore.Packages;
using Serilog;

namespace ME2Randomizer.Classes.Randomizers.Utility
{
    /// <summary>
    /// A superset cache package that can cache embedded assets
    /// </summary>
    public class MERPackageCache : PackageCache
    {
        /// <summary>
        /// Returns a cached package. Ensure this cache is synchronized if across threads or you may end up saving two different instances of files to the same location
        /// </summary>
        /// <param name="packageName"></param>
        /// <returns></returns>
        public override IMEPackage GetCachedPackage(string packageName, bool openIfNotInCache = true)
        {
            // May need way to set maximum size of dictionary so we don't hold onto too much memory.
            packageName = Path.GetFileName(packageName); // Ensure we only use filename
            if (Cache.TryGetValue(packageName, out var package))
            {
                return package;
            }

            if (openIfNotInCache)
            {
                var file = MERFileSystem.GetPackageFile(packageName, false);
                if (file != null && File.Exists(file))
                {
                    int i = 3;
                    while (i > 0)
                    {
                        try
                        {
                            i--;
                            package = MERFileSystem.OpenMEPackage(file);
                        }
                        catch (IOException e)
                        {
                            // This is a cheap hack around potential multithreading issues
                            Log.Warning($@"I/O Exception opening {file}: {e.Message}. We have {i} attempts remaining to open this package");
                            Thread.Sleep(1000);
                        }
                    }

                    if (package == null)
                        return null;

                    Cache[packageName] = package;
                    return package;
                }
            }
            return null; //Package could not be found
        }

        /// <summary>
        /// Returns a cached package that references an internally embedded package. Ensure this cache is synchronized if across threads or you may end up saving two different instances of files to the same location
        /// </summary>
        /// <param name="packageName"></param>
        /// <returns></returns>
        public IMEPackage GetCachedPackageEmbedded(string embeddedPath, bool openIfNotInCache = true, bool isFullPath = false)
        {
            // May need way to set maximum size of dictionary so we don't hold onto too much memory.
            if (Cache.TryGetValue(embeddedPath, out var package))
            {
                return package;
            }

            if (openIfNotInCache)
            {
                var embeddedData = MERUtilities.GetEmbeddedStaticFilesBinaryFile(embeddedPath, isFullPath);
                if (embeddedData != null)
                {
                    package = MEPackageHandler.OpenMEPackageFromStream(new MemoryStream(embeddedData));
                    Cache[embeddedPath] = package;
                    return package;
                }
            }
            return null; //Package could not be found
        }

        public IReadOnlyCollection<IMEPackage> GetPackages()
        {
            return new ReadOnlyCollection<IMEPackage>(Cache.Values.ToList());
        }
    }
}
