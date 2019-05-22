using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.IO;

namespace LazyLoadInMVC.Models
{
    public class ProjectRepository
    {
        public List<Project> GetProjectList()
        {
            string projectFile = HostingEnvironment.MapPath("~/App_Data/Projects.txt");
            List<Project> tempList = new List<Project>();

            foreach (string line in File.ReadAllLines(projectFile))
            {
                var parts = line.Split('|');
                tempList.Add(new Project()
                {
                    ID = parts[0],
                    Name = parts[1],
                    ManagerName= parts[2],
                    Email = parts[3]
                });
            }

            return tempList;
        }
    }
}