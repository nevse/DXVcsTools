﻿using System;

namespace DXVcsTools.Core {
    public enum VSTheme {
        Dark, 
        Light, 
        Blue,
        Unknown,
    }
    public interface IDteWrapper {
        SolutionItem BuildTree();
        void OpenSolution(string path);
        void ReloadProject();
        string GetVSTheme(Func<VSTheme, string> getThemeFunc);
    }
}