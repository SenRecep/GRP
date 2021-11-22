using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class EdgeManager : IEdgeService
{
    public CalculatedEdgeModel EdgeCalculate(CalculateModel model)
    {
        Capacity capacity = CalculateCapacity(model);
        Interior interior = CalculateInterior(model);
        Outside outside = CalculateOutside(model);
        float edge_side = MathF.Ceiling(model.Height - 1) < 2 ?
            (MathF.Ceiling(model.Width - 1) + MathF.Ceiling(model.Length - 1) + model.Height * 4) * 2 :
            interior.Side + outside.Side;
        Edge edge = new(
            Top: interior.Top + outside.Top,
            Bottom: interior.Bottom + outside.Bottom,
            Side: edge_side);
        return new(capacity, edge, interior, outside);
    }
    private static Capacity CalculateCapacity(CalculateModel model) => new(model.Width * model.Length * model.Height);
    private static Interior CalculateInterior(CalculateModel model)
    {
        float interior_top_bottom = MathF.Ceiling(model.Width - 1) * model.Length + MathF.Ceiling(model.Length - 1) * model.Width;
        float interior_side = model.Height switch
        {
            1 or 1.5f => (model.Length + model.Width - 2) * 2 * model.Height,
            2 or 2.5f or 3 => (
               (MathF.Ceiling(model.Width - 1) + MathF.Ceiling(model.Length - 1)) * model.Height +
                MathF.Floor(model.Height - 1) * (model.Width + model.Length)) * 2,
            _ => 0
        };
        return new(
            Top: interior_top_bottom,
            Bottom: interior_top_bottom,
            Side: interior_side);
    }
    private static Outside CalculateOutside(CalculateModel model)
    {
        float outside_top_bottom = (model.Width + model.Length) * 2;
        float outside_side = model.Height * MathF.Pow(2, 3);
        return new(
             Top: outside_top_bottom,
             Bottom: outside_top_bottom,
             Side: outside_side);
    }
}
