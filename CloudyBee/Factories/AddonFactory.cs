using CloudyBeeEngine.Addons;
using CloudyBeeEngine.Constants;
using CloudyBeeEngine.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CloudyBeeEngine.Factories
{
    public static class AddonFactory
    {


        public static List<AddonInfo> GetAddons()
        {
            List<AddonInfo> addons = new List<AddonInfo>();
            List<string> addonsToLoad;

            if (GetAddonsToLoad(out addonsToLoad))
            {
                foreach (string directory in addonsToLoad)
                {
                    AddonInfo addon;

                    if (GetAddon(directory, out addon))
                    {
                        addons.Add(addon);
                    }
                    else
                    {
                        Logger.Instance.LogError(string.Format("Failed to load addon '{0}'.", directory));
                    }
                }
            }
            else
            {
                Logger.Instance.LogError("FATAL : Failed to load any addons.");
            }

            //We want handle all addons in reverse order, so we don't load content that will be later overwritten.
            addons.Reverse();

            return addons;
        }

        public static bool GetAddonsToLoad(out List<string> addonsToLoad)
        {
            bool success = false;
            addonsToLoad = new List<string>();

            string loadOrderPath = Path.Combine(Constant.ADDONS_FOLDER_NAME, Constant.LOAD_ORDER_FILE_NAME);
            string[] loadOrderContents = File.ReadAllLines(loadOrderPath);

            foreach (string addonName in loadOrderContents)
            {
                string addonPath = string.Format("{0}/{1}", Constant.ADDONS_FOLDER_NAME, addonName);

                if (Directory.Exists(addonPath))
                {
                    addonsToLoad.Add(addonPath);
                    success = true;
                }
                else
                {
                    Logger.Instance.LogError(string.Format("Failed to locate addon '{0}'", addonName));
                }
            }

            return success;
        }

        private static bool GetAddon(string addonDirectory, out AddonInfo addon)
        {
            bool success = false;
            addon = null;

            try
            {
                if (GetInfoFile(addonDirectory, out string file))
                {
                    addon = JsonConvert.DeserializeObject<AddonInfo>(file);
                    addon.Directory = addonDirectory;
                    success = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.LogError(string.Format("Failed to parse info file for addon '{0}'.", addonDirectory));
            }

            return success;
        }

        private static bool GetInfoFile(string addonDirectory, out string file)
        {
            bool success = false;
            file = string.Empty;

            string[] infoFiles = Directory.GetFiles(addonDirectory, Constant.ADDON_INFO_FILE_EXTENSION);

            if (infoFiles.Length == 0)
            {
                Logger.Instance.LogError(string.Format("Unable to locate addon info for addon '{0}'.", addonDirectory));
            }
            else
            {
                file = File.ReadAllText(infoFiles[0]);
                success = true;
            }

            return success;
        }
    }
}