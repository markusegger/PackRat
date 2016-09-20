using System.Collections.Generic;
using System.Linq;
using NuGet;

namespace CODE.PackRat.Core
{
    public static class NuGet
    {
        private static string PackageSource { get; set; } = "https://packages.nuget.org/api/v2";
        private static string PackageDestination { get; set; } = @"c:\PackRatTest\";

        private static IPackageRepository GetRepository()
        {
            return PackageRepositoryFactory.Default.CreateRepository(PackageSource);
        }


        public static List<IPackage> SearchRepository(string searchTerm)
        {
            return GetRepository().Search(searchTerm, true).ToList();
        }

        public static bool GetPackage(string packageId, string packageVersion, string destinationPath = null)
        {
            if (string.IsNullOrEmpty(destinationPath)) destinationPath = PackageDestination;
            var packageManager = new PackageManager(GetRepository(), destinationPath);
            packageManager.InstallPackage(packageId, SemanticVersion.Parse(packageVersion));
            return true;
        }
    }
}
