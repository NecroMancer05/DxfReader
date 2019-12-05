## DxfReader

* Basic .dxf file reader.
* Fast.
* Consumes less memory.
* Only reads 4 entitity types: Polyline, Line, Multiline and Point
* Can read Header and Layers too.
* Example

```c#
static void Main(string[] args)
{
    var dxfContents = DxfContents.Read("dxfFilePath");

    var polylines = dxfContents.Polylines;

    foreach (var point in dxfContents.Points)
    {
        //do whatever you want
    }
}
```
