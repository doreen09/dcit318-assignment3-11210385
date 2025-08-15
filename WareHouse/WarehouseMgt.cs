﻿using System;
using System.Collections.Generic;

namespace WarehouseInventorySystem
{
    public interface IInventoryItem
    {
        int Id { get; }
        string Name { get; }
        int Quantity { get; set; }
    }




}