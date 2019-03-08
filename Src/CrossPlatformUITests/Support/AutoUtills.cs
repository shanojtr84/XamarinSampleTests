using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using Newtonsoft.Json.Linq;
using Xamarin.UITest;

namespace CrossPlatformUITests.Support
{
    public class AutoUtills
    {
        public JObject ReadJson = null;

        public string TakeScreenShot(string testName, IApp app, Platform platform)
        {
            var screen = app.Screenshot("Welcome Screen");
            int fileNamelength = screen.Name.Length;
            var fileName = screen.Name.Substring(fileNamelength - 1);
            string screenshotName = fileName.Replace("g", platform.ToString() + "_" + testName + "_" + string.Format("{0:dd-MM-yyyy_HH-mm-ss}", DateTime.Now) + ".png");
            var screenShotPath = Path.Combine(GetProjectPath() + "ScreenShots", screenshotName);

            if (File.Exists(screenShotPath))
            {
                File.Delete(screenShotPath);
            }
            screen.MoveTo(screenShotPath);

            return screenShotPath;
        }

        public string GetProjectPath()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin", StringComparison.Ordinal));
            string projectPath = new Uri(actualPath).LocalPath;
            return projectPath;

        }

        public JObject GetJsonObject()
        {
            if (ReadJson == null)
            {
                // ReadJson = JObject.Parse(File.ReadAllText(GetProjectPath() + "TestData/data.json"));
                ReadJson = JObject.Parse(GetEmbeddedResourceString("Testdata.json"));
            }
            return ReadJson;
        }

        public string ReadTestData(params string[] args)
        {
            JObject temp = GetJsonObject();

            if (args.Length == 1)
            {
                return (String)GetJsonObject().GetValue(args[0]);
            }
            else
            {
                for (int i = 0; i < args.Length - 1; i++)
                {
                    temp = (JObject)temp.GetValue(args[i]);
                }
                return (String)temp.GetValue(args[args.Length - 1]);
            }
        }

        public List<String> ReadTestDataList(params string[] args)
        {
            JObject temp = GetJsonObject();
            {
                for (int i = 0; i < args.Length - 1; i++)
                {
                    temp = (JObject)temp.GetValue(args[i]);
                }
                return temp.GetValue(args[args.Length - 1]).ToObject<List<String>>();
            }
        }

        public static string GetEmbeddedResourceString(string resourceFileName)
        {
            return GetEmbeddedResourceString(System.Reflection.Assembly.GetCallingAssembly(), resourceFileName);
        }


        public static string GetEmbeddedResourceString(Assembly assembly, string resourceFileName)
        {
            var stream = GetEmbeddedResourceStream(assembly, resourceFileName);

            using (var streamReader = new StreamReader(stream))
            {
                return streamReader.ReadToEnd();
            }
        }


        public static Stream GetEmbeddedResourceStream(Assembly assembly, string resourceFileName)
        {
            var resourceNames = assembly.GetManifestResourceNames();

            var resourcePaths = resourceNames
                .Where(x => x.EndsWith(resourceFileName, StringComparison.CurrentCultureIgnoreCase))
                .ToArray();

            if (!resourcePaths.Any())
            {
                throw new Exception(string.Format("Resource ending with {0} not found.", resourceFileName));
            }

            if (resourcePaths.Count() > 1)
            {
                throw new Exception(string.Format("Multiple resources ending with {0} found: {1}{2}", resourceFileName, Environment.NewLine, string.Join(Environment.NewLine, resourcePaths)));
            }

            return assembly.GetManifestResourceStream(resourcePaths.Single());
        }


    }
}
