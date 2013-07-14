using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerLibrary.Models.Graphs;
using System.Reflection;

namespace ProjectManagerBLL.Report
{
    public class ReportBLL
    {
        public static List<Type> ReportTypes()
        {
            try
            {
                System.Reflection.Assembly[] list = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly assembly in list)
                {
                    AssemblyName assemblyName = new AssemblyName(assembly.FullName);
                    if (assemblyName.Name == "ProjectManagerLibrary")
                    {
                        var type = typeof(ProjectData);
                        List<Assembly> assemblies = new List<Assembly>(1);
                        assemblies.Add(assembly);
                        var types = assemblies.SelectMany(s => s.GetTypes())
                            .Where(p => type.IsAssignableFrom(p) && p.IsInterface == false);

                        return new List<Type>(types.AsEnumerable<Type>());
                    }
                }
            }
            catch (Exception)
            {
            }
            return new List<Type>();
        }
    }

}
