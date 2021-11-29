#nullable disable
using GRP.Core.Concrete;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.History;

public class EdgeModelHistory : EntityBase
{
    public float Capacity { get; set; }
    public float Edge_Top { get; set; }
    public float Edge_Bottom { get; set; }
    public float Edge_Side { get; set; }

    public float Interior_Top { get; set; }
    public float Interior_Bottom { get; set; }
    public float Interior_Side { get; set; }

    public float Outside_Top { get; set; }
    public float Outside_Bottom { get; set; }
    public float Outside_Side { get; set; }

    public Guid? CalculateModelHistoryId { get; set; }
    public virtual CalculateModelHistory CalculateModelHistory { get; set; }
}
