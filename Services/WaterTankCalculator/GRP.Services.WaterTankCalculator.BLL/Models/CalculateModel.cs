﻿using GRP.Services.WaterTankCalculator.BLL.Enums;

namespace GRP.Services.WaterTankCalculator.BLL.Models;
public record  CalculateModel(float Width, float Length, float Height,PlinthType PlinthType);