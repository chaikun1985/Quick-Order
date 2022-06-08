using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace Quick_Order
{
    class RecentProjectClass
    {
        public readonly string PROJECT_PROPERTY_SPLITE_STRING = @"^&^";

        public RecentProjectClass()
        {
            CreateProjectTable();
        }

        public DataTable RecentTable = new DataTable();
        public static string COLNAME_RECENTPROJECT_NAME = "ProjectName";
        public static string COLNAME_RECENTPROJECT_PATH = "ProjectPATH";
        public static string COLNAME_RECENTPROJECT_CREATEDTIME = "CreatedTime";
        public static string COLNAME_RECENTPROJECT_EDITEEDTIME = "LastEditTime";
        public static string COLNAME_RECENTPROJECT_OTHER = "Other";

        private void CreateProjectTable()
        {
            RecentTable.Columns.Clear();
            RecentTable.Columns.Add(new DataColumn(COLNAME_RECENTPROJECT_NAME, typeof(string)));
            RecentTable.Columns.Add(new DataColumn(COLNAME_RECENTPROJECT_PATH, typeof(string)));
            RecentTable.Columns.Add(new DataColumn(COLNAME_RECENTPROJECT_CREATEDTIME, typeof(string)));
            RecentTable.Columns.Add(new DataColumn(COLNAME_RECENTPROJECT_EDITEEDTIME, typeof(string)));
            RecentTable.Columns.Add(new DataColumn(COLNAME_RECENTPROJECT_OTHER, typeof(string)));
        }

        public void LoadRecentProjects()
        {
            RecentTable.Rows.Clear();

            AddAProjectRow(Properties.Settings.Default.RecentProject1);
            AddAProjectRow(Properties.Settings.Default.RecentProject2);
            AddAProjectRow(Properties.Settings.Default.RecentProject3);
            AddAProjectRow(Properties.Settings.Default.RecentProject4);
            AddAProjectRow(Properties.Settings.Default.RecentProject5);
            AddAProjectRow(Properties.Settings.Default.RecentProject6);
        }

        private void AddAProjectRow(string recent1)
        {
            string[] recent1Contents = recent1.Split(new string[] { PROJECT_PROPERTY_SPLITE_STRING }, StringSplitOptions.None);
            if (recent1Contents.Length != 4)
            {
                return;
            }
            else
            {
                DataRow newRow = RecentTable.NewRow();
                string projectPath = recent1Contents[0];
                string projectName = System.IO.Path.GetFileNameWithoutExtension(projectPath);
                string createdTime = recent1Contents[1];
                string lastEditedTime = recent1Contents[2];
                newRow[COLNAME_RECENTPROJECT_NAME] = projectName;
                newRow[COLNAME_RECENTPROJECT_PATH] = projectPath;
                newRow[COLNAME_RECENTPROJECT_CREATEDTIME] = createdTime;
                newRow[COLNAME_RECENTPROJECT_EDITEEDTIME] = lastEditedTime;
                newRow[COLNAME_RECENTPROJECT_OTHER] = recent1Contents[3];
                RecentTable.Rows.Add(newRow);
            }
        }

        public void RefreshProjectEditTime(string projectPath)
        {
            bool ProjectExsit = false;
            for (int ii = 0; ii < RecentTable.Rows.Count; ii++)
            {
                string curProjectPath = RecentTable.Rows[ii][COLNAME_RECENTPROJECT_PATH].ToString();
                if (curProjectPath == projectPath)
                {
                    ProjectExsit = true;
                    RecentTable.Rows[ii][COLNAME_RECENTPROJECT_EDITEEDTIME] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            if (ProjectExsit == false)
            {
                AddANewProject(projectPath);
            }

            SaveSettings();
        }

        public void DeleteProjectrow(string projectPath)
        {
            DataRow[] rows = RecentTable.Select(string.Format("ProjectName = '{0}'", Path.GetFileNameWithoutExtension(CommonUsages.CurrentProjectPath)));
            if (rows.Length > 0)
            {
                RecentTable.Rows.Remove(rows[0]);
            }
        }
        public void AddANewProject(string projectPath)
        {
            string projectName = System.IO.Path.GetFileNameWithoutExtension(projectPath);
            if (RecentTable.Rows.Count>=6)
            {
                int oldestIndex = FindOldestRowIndex();
                RecentTable.Rows.RemoveAt(oldestIndex);
            }

            DataRow newRow = RecentTable.NewRow();
            string createdTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string lastEditedTime = createdTime;
            newRow[COLNAME_RECENTPROJECT_NAME] = projectName;
            newRow[COLNAME_RECENTPROJECT_PATH] = projectPath;
            newRow[COLNAME_RECENTPROJECT_CREATEDTIME] = createdTime;
            newRow[COLNAME_RECENTPROJECT_EDITEEDTIME] = lastEditedTime;
            newRow[COLNAME_RECENTPROJECT_OTHER] = "";
            RecentTable.Rows.Add(newRow);

            SaveSettings();
        }

        private int FindOldestRowIndex()
        {
            int index = -1;
            DateTime editTime = new DateTime(2100,12,30,23,59,59);
            for (int ii = 0; ii < RecentTable.Rows.Count; ii++)
            {
                string curTimeString = RecentTable.Rows[ii][COLNAME_RECENTPROJECT_EDITEEDTIME].ToString();
                DateTime curTime;
                if (DateTime.TryParse(curTimeString, out curTime)==false)
                {
                    return ii;
                }
                if (curTime < editTime)
                {
                    editTime = curTime;
                    index = ii;
                }
            }
            return index;
        }

        private void SaveSettings()
        {           
            int currentSetiingIndex = 1;
            for (int ii = 0; ii < RecentTable.Rows.Count; ii++)
            {
                DataRow itemRow = RecentTable.Rows[ii];
                string projectPath = itemRow[COLNAME_RECENTPROJECT_PATH].ToString();
                string cretedTime = itemRow[COLNAME_RECENTPROJECT_CREATEDTIME].ToString();
                string editedTime = itemRow[COLNAME_RECENTPROJECT_EDITEEDTIME].ToString();
                if (projectPath == "" || editedTime == "" || cretedTime == "")
                {
                    continue;
                }

                String saveString = string.Format("{0}{1}{2}{3}{4}{5}{6}", projectPath, PROJECT_PROPERTY_SPLITE_STRING,
                    cretedTime, PROJECT_PROPERTY_SPLITE_STRING,
                    editedTime, PROJECT_PROPERTY_SPLITE_STRING, itemRow[COLNAME_RECENTPROJECT_OTHER]);

                WriteSettings(currentSetiingIndex, saveString);
                currentSetiingIndex++;
            }

            for (int ii = currentSetiingIndex; ii <= 6; ii++)
            {
                WriteSettings(currentSetiingIndex, "");
            }
        }

        private void WriteSettings(int index, string content)
        {
            switch(index)
            {
                case 1:
                    Properties.Settings.Default.RecentProject1 = content;
                    break;
                case 2:
                    Properties.Settings.Default.RecentProject2 = content;
                    break;
                case 3:
                    Properties.Settings.Default.RecentProject3 = content;
                    break;
                case 4:
                    Properties.Settings.Default.RecentProject4 = content;
                    break;
                case 5:
                    Properties.Settings.Default.RecentProject5 = content;
                    break;
                case 6:
                    Properties.Settings.Default.RecentProject6 = content;
                    break;
                default:                    
                    break;
            }

            Properties.Settings.Default.Save();
        }
    }
}
