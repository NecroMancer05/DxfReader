namespace DxfReader.Misc
{
    /// <summary>
    /// Curves and smooth surface type
    /// More information https://knowledge.autodesk.com/search-result/caas/CloudHelp/cloudhelp/2018/ENU/AutoCAD-DXF/files/GUID-ABF6B778-BE20-4B49-9B58-A94E64CEFFF3-htm.html
    /// </summary>
    public enum PolylineCurveTypes
    {
        NoSmooth = 0,   //default
        QuadraticBSpline = 5,
        CubicBSpline = 6,
        Bezier = 8
    }
}