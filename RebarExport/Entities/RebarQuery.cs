using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace RebarExport.Entities
{
    public class RebarQuery
    {
        private readonly UIDocument uiDocument;

        public RebarQuery(UIDocument uiDocument)
        {
            this.uiDocument = uiDocument;
        }

        public Rebar Prompt()
        {
            var filter = new RebarSelectionFilter();

            try
            {
                var reference = uiDocument.Selection
                    .PickObject(ObjectType.Element, filter, "Выбор системной несущей арматуры");

                return (Rebar) uiDocument.Document.GetElement(reference);
            }
            catch (OperationCanceledException)
            {
                return null;
            }
        }
    }
}