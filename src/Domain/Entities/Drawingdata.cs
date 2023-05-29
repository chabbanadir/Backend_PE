using Backend.Domain.Common;
using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities
{
    public class DrawingData : AuditableEntity
    {
        public new Guid Id { get; set; }
        public string TEPartNumber { get; set; }
        public string CustomerPN { get; set; }
        public string ProjectNumber { get; set; }
        public string OEM { get; set; }
        public string HarnessMaker { get; set; }
        public int NumberOfConnectors { get; set; }
        public List<ComponentWithSide> Components { get; set; }

        public string CDPath { get; set; }
        public string PDPath { get; set; }
        public string ExcelFilePath { get; set; }

        // Other properties and relationships as needed

        public DrawingData()
        {
            // Initialize collections or set default values if needed
            Components = new List<ComponentWithSide>();
        }
    }

    public class ComponentWithSide
    {
        public Guid DrawingDataId { get; set; }
        public Guid ComponentId { get; set; }
        public int Side { get; set; }

        public DrawingData? DrawingData { get; set; }
        public Component? Component { get; set; }
    }

    public enum Side
    {
        Left,
        Right
    }
}
