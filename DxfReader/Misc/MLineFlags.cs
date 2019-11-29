namespace DxfReader.Misc
{
    /// <summary>
    /// Fır mode information https://knowledge.autodesk.com/search-result/caas/CloudHelp/cloudhelp/2018/ENU/AutoCAD-DXF/files/GUID-590E8AE3-C6D9-4641-8485-D7B3693E432C-htm.html
    /// </summary>
    public enum MLineFlags
    {
        HasAtLeastOneVertex = 1,
        Closed = 2,
        SuppressStartCaps = 4,
        SuppressEndCaps = 8
    }
}