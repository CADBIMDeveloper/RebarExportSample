using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;

namespace RebarExport.Entities
{
    public class RevitRebar
    {
        private readonly Rebar rebar;

        public RevitRebar(Rebar rebar)
        {
            this.rebar = rebar;
        }

        public double MassPerUnitLength
        {
            get
            {
                var rebarType = rebar.Document.GetElement(rebar.GetTypeId());

                var parameter = rebarType
                    .get_Parameter(new Guid("001aa5f4-eb83-4eef-9a29-7525c3ad4797"));

                if (parameter == null)
                    throw new InvalidOperationException("Не задан общий параметр Массы 1пм");

                var value = parameter
                    .AsDouble();

                return UnitUtils.ConvertFromInternalUnits(value, DisplayUnitType.DUT_KILOGRAMS_MASS_PER_METER);
            }
        }

        public double Diameter
        {
            get
            {
                var rebarType = rebar.Document.GetElement(rebar.GetTypeId());

                var value = rebarType
                    .get_Parameter(BuiltInParameter.REBAR_BAR_DIAMETER)
                    .AsDouble();

                return UnitUtils.ConvertFromInternalUnits(value, DisplayUnitType.DUT_MILLIMETERS);
            }
        }

        public string Class
        {
            get
            {
                var rebarType = rebar.Document.GetElement(rebar.GetTypeId());

                var parameter = rebarType
                    .get_Parameter(new Guid("d0603bd6-50ea-41a8-9b72-2bb884a15cb7"));

                if (parameter == null)
                    throw new InvalidOperationException("Не задан общий параметр Класса арматуры");

                return parameter.AsValueString();
            }
        }

        public double FullLength
        {
            get
            {
                var value = rebar
                    .get_Parameter(BuiltInParameter.REBAR_ELEM_TOTAL_LENGTH)
                    .AsDouble();

                return UnitUtils.ConvertFromInternalUnits(value, DisplayUnitType.DUT_MILLIMETERS);
            }
        }
    }
}