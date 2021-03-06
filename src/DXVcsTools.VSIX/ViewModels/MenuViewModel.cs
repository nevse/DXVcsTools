﻿using System.Reflection;
using System.Windows;
using EnvDTE;
using EnvDTE80;
using Configuration = System.Configuration.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace DXVcsTools.VSIX {
    public class MenuViewModel {
        DTE applicationObject;
        Configuration configuration;

        public void DoConnect(DTE dte) {
            applicationObject = dte;
            configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
        }
        public void DoPort() {
            //string fileName = null;
            //if (!CanHandleActiveDocument(ref fileName))
            //    return;

            //var dxPortConfiguration = new OptionsViewModel();
            //IViewFactory factory = new ViewFactory();

            //var model = new PortViewModel(fileName, applicationObject.ActiveDocument.ProjectItem.ContainingProject.FullName, dxPortConfiguration);

            //IPortWindowView ui = factory.CreatePortWindow();

            //var presenter = new PortWindowPresenter(ui, model);
            //presenter.Initialize();

            //ui.ShowModal();
        }

        string GetClassQualifiedCommandName(string name) {
            return string.Format("{0}.{1}", GetType().FullName, name);
        }

        bool CanHandleActiveDocument(ref string fileName) {
            if (applicationObject.ActiveDocument == null) {
                MessageBox.Show("No current document.", "test", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }

            fileName = applicationObject.ActiveDocument.FullName;
            var sourceControl = (SourceControl2)applicationObject.SourceControl;

            if (!sourceControl.IsItemUnderSCC(fileName)) {
                MessageBox.Show(string.Concat("File ", fileName, " is not under source control."), "test", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }

            return true;
        }
    }
}