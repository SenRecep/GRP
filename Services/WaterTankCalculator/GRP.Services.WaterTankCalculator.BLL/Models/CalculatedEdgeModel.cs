using GRP.Services.WaterTankCalculator.Entities.Concrete.History;

namespace GRP.Services.WaterTankCalculator.BLL.Models;
public record CalculatedEdgeModel(Capacity Capacity, Edge Edge, Interior Interior, Outside Outside)
{
    public EdgeModelHistory Map()
    {
        return new EdgeModelHistory()
        {
            Capacity = Capacity.Value,
            Edge_Bottom = Edge.Bottom,
            Edge_Side = Edge.Side,
            Edge_Top = Edge.Top,
            Interior_Bottom = Interior.Bottom,
            Interior_Side = Interior.Side,
            Interior_Top = Interior.Top,
            Outside_Bottom = Outside.Top,
            Outside_Side = Outside.Top,
            Outside_Top = Outside.Top
        };
    }
}