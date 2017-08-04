using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI.Selection;

namespace RebarExport.Entities
{
    public class RebarSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return elem is Rebar;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}