using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.IO;

namespace RooStatsSim.Extension
{
    class ResourceExtension
    {
        const string image_not_found = "Resources/image-not-found.png";
        public static Uri GetUri(string imageName)
        {
            if (IsFileExists(imageName))
                return new Uri(imageName);
            else
                return GetResourceUri(null, image_not_found);
        }
        public static bool IsFileExists(string imagePath)
        {
            FileInfo fi = new FileInfo(imagePath);
            if (fi.Exists)
                return true;
            else
                return false;
        }
        public static void CreateFolder(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists == false)
                di.Create();
        }
        #region Assembly Resource
        public static Uri GetAssemblyUri(string resourceName)
        {
            if (ResourceExists(resourceName))
                return GetResourceUri(null, resourceName);
            else return GetResourceUri(null, image_not_found);

        }
        public static bool ResourceExists(string resourcePath)
        {
            var assembly = Assembly.GetExecutingAssembly();

            return ResourceExists(assembly, resourcePath);
        }

        public static bool ResourceExists(Assembly assembly, string resourcePath)
        {
            return GetResourcePaths(assembly)
                .Contains(resourcePath.ToLowerInvariant());
        }

        public static IEnumerable<object> GetResourcePaths(Assembly assembly)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var resourceName = assembly.GetName().Name + ".g";
            var resourceManager = new ResourceManager(resourceName, assembly);

            try
            {
                var resourceSet = resourceManager.GetResourceSet(culture, true, true);

                foreach (System.Collections.DictionaryEntry resource in resourceSet)
                {
                    yield return resource.Key;
                }
            }
            finally
            {
                resourceManager.ReleaseAllResources();
            }
        }

        public static Uri GetResourceUri(string assemblyName, string resourcePath)
        {
            if (string.IsNullOrEmpty(assemblyName))
            {
                return new Uri(string.Format("pack://application:,,,/{0}", resourcePath));
            }
            else
            {
                return new Uri(string.Format("pack://application:,,,/{0};component/{1}", assemblyName, resourcePath));
            }
        }
        #endregion
    }
}
