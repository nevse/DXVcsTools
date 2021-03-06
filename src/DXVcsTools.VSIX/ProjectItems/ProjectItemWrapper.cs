﻿namespace DXVcsTools.Core {
    public class ProjectItemWrapper : IProjectItemWrapper {
        public ProjectItemWrapper(EnvDTE.ProjectItem item) {
            Item = item;
        }
        EnvDTE.ProjectItem Item { get; set; }
        public string FullPath { get { return Item.Properties.Item("FullPath").Value.ToString(); }}
        public bool IsSaved {
            get { return Item.Saved; }
        }
        public void Save() {
            if (!IsSaved)
                Item.Save();
        }
        public void Open() {
            if (Item.IsOpen)
                Item.Document.Activate();
            else {
                var win = Item.Open(EnvDTE.Constants.vsViewKindCode);
                win.Visible = true;
                win.SetFocus();
            }
        }
    }
}