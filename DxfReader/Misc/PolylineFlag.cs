namespace DxfReader.Misc
{
    /// <summary>
    /// Polyline types,
    /// You can find more information about in this link
    /// https://knowledge.autodesk.com/search-result/caas/CloudHelp/cloudhelp/2018/ENU/AutoCAD-DXF/files/GUID-ABF6B778-BE20-4B49-9B58-A94E64CEFFF3-htm.html
    /// </summary>
    public enum PolylineFlags
    {
        Default = 0,
        ClosedPolyline = 1,
        CurvefitVertices = 2,
        SplineFitVertices = 4,
        Polyline3D = 8,
        PolygonMesh3D = 16,
        ClosedPolygonMesh = 32,
        PolyfaceMesh = 64,
        LinetypePattern = 128
    }
}
