
using GRP.Services.WaterTankCalculator.Entities.Enums;

namespace GRP.Services.WaterTankCalculator.BLL.Models;
public record CalculateModel(float Width, float Length, float Height, int Quantity, PlinthType PlinthType, PaymentType PaymentType);